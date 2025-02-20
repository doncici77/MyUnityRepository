using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // �ִϸ��̼� �̸����� ����
    public enum ANIME_STATE
    {
        PlayerIDLE,
        PlayerClear,
        PlayerGameover,
        PlayerRun,
        PlayerJump
    }

    Animator animator;
    string current; // ���� ���� ���� �ִϸ��̼�
    string previous; // ������ ���� ���� �ִϸ��̼�

    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "playing"; // ������ ����(�÷��� ��)

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        state = "playing";
    }

    void Update()
    {
        if(state != "playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal"); // ���� �̵� // Axis: �Է� �� // Raw: ��ġ�� 1,0,-1

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
            // ���Ͱ� -�� ������ �Ǹ� �¿� ����
        }

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (state != "playing")
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        // ������ �� ���� �����ϴ� ������ ���� ���� ������Ʈ�� �����ϴ����� ������ true �Ǵ� false�� return���ִ� �Լ�
        // up�� Vector �������� (0, 1, 0)�Դϴ�.
        // (�÷��̾��� ���� pivot�� bottom)

        // ���� ���� �ְų� �Ǵ� �ӵ��� 0�� �ƴ� ���
        if(onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        // ���� ���� �ִ� ���¿��� ���� Ű�� ���� ��Ȳ
        if(onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump); // �÷��̾ ���� ���� ��ġ ��ŭ ���� ����
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); // �ش� ��ġ�� ���� ���մϴ�
            goJump = false;
        }


        if(onGround)
        {
            if(axisH == 0)
            {
                current = Enum.GetName(typeof(ANIME_STATE), 0);
                // Enum.GetName(typeof(enum��), ��);
                // �ش� enum�� �ִ� �� ���� �̸��� ������ ���
            }
            else
            {
                current = Enum.GetName(typeof(ANIME_STATE), 3);
            }
        }
        else
        {
            // ������ ���
            current = Enum.GetName(typeof(ANIME_STATE), 4);
        }
        
        // ������ ����� ������ ��ǰ� �ٸ� ���(�ִϸ��̼��� �ٲ� ���)
        if(current != previous)
        {
            previous = current; // ���� ���ۿ� ���� ���̺�
            animator.Play(current); // ������ ��� �÷���
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 2));
    }

    private void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 1));
    }

    private void Jump()
    {
        goJump = true; // �÷��� Ű�� �۾�
    }
}
