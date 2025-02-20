using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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

    }

    private void Jump()
    {
        goJump = true; // �÷��� Ű�� �۾�
    }
}
