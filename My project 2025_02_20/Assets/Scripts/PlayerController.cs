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

    }

    private void Jump()
    {
        goJump = true; // 플래그 키는 작업
    }
}
