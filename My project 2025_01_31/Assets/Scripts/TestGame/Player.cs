using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public TextFade textFade; // 외부 스크립트 호출
    public GameObject player; // 플레이어 오브젝트
    private float speed = 5f; // 움직임의 속도
    private float jump_force = 5f; // 점프 높이
    private bool isJump = false; // 점프 가능 여부
    private Rigidbody2D rigid; // 리지드 바디의 컴포넌트를 사용

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); // 좌우 입력 받기
        Vector3 velocity = new Vector3(x, 0, 0) * speed * Time.deltaTime; // 좌우 이동 거리 계산
        transform.position += velocity; // 좌우 이동 실행
    }
    private void Jump()
    {
        //사용자가 키보드 Space키를 입력한다면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump) //점프 상태가 아닌 경우
            {
                isJump = true; //점프 상태로 변경
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
            Debug.Log("땅을 밟았습니다!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boom")
        {
            player.transform.position = new Vector3(-8, 0.7f, 0); // 플레이어 위치 이동(리스폰)
        }

        if (collision.gameObject.tag == "Finish")
        {
            textFade.EndGame(); // 외부 스크립트에 있는 엔딩 텍스트 페이드인 함수 호출
        }
    }
}
