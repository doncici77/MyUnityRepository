using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5f; //소수점을 적을 때는 마지막에 f 기호를 사용합니다.
    //소수점 약 6자리까지 정확하게 계산

    public double jump_force = 5f; //double도 실수를 표현하는 자료형이며 이경우에는 f를 붙이지 않습니다.
    //소수점 약 15자리 까지 정확하게 계산

    public bool isJump = false;

    private Rigidbody2D rigid;

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
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(x, 0, 0) * speed * Time.deltaTime;
        //속력 = 방향 * 속도;

        transform.position += velocity; //현제 위치 += 변경되는 움직임
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
}
