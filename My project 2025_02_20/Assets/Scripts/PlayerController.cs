using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // 애니메이션 이름으로 설정
    public enum ANIME_STATE
    {
        PlayerIDLE,
        PlayerClear,
        PlayerGameover,
        PlayerRun,
        PlayerJump
    }

    Animator animator;
    string current; // 현제 진행 중인 애니메이션
    string previous; // 기존의 진행 중인 애니메이션

    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "playing"; // 현재의 상태(플레이 중)

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

        axisH = Input.GetAxisRaw("Horizontal"); // 수평 이동 // Axis: 입력 축 // Raw: 수치를 1,0,-1

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
            // 벡터가 -로 잡히게 되면 좌우 반전
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
        // 지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접촉하는지를 조사해 true 또는 false로 return해주는 함수
        // up은 Vector 기준으로 (0, 1, 0)입니다.
        // (플레이어의 현재 pivot은 bottom)

        // 지면 위에 있거나 또는 속도가 0이 아닌 경우
        if(onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        // 지면 위에 있는 상태에서 점프 키가 눌린 상황
        if(onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump); // 플레이어가 가진 점프 수치 만큼 백터 설계
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); // 해당 위치로 힘을 가합니다
            goJump = false;
        }


        if(onGround)
        {
            if(axisH == 0)
            {
                current = Enum.GetName(typeof(ANIME_STATE), 0);
                // Enum.GetName(typeof(enum명), 값);
                // 해당 enum에 있는 그 값의 이름을 얻어오는 기능
            }
            else
            {
                current = Enum.GetName(typeof(ANIME_STATE), 3);
            }
        }
        else
        {
            // 공중인 경우
            current = Enum.GetName(typeof(ANIME_STATE), 4);
        }
        
        // 현재의 모션이 이전의 모션과 다른 경우(애니메이션이 바뀐 경우)
        if(current != previous)
        {
            previous = current; // 이전 동작에 대한 세이브
            animator.Play(current); // 현재의 모션 플레이
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
        goJump = true; // 플래그 키는 작업
    }
}
