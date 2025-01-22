using System;
using UnityEngine;
//플레이어의 이동(리지드바디)

//해당기능을 통해 이 스크립트를 컴포넌트롯써 사용할 경우
//적어놓은 컴포넌트를 요구하게 됩니다.
//1. 해당 컴포넌트가 없는 오브젝트에 연결할 경우 에는 자동으러 연결을 진행 해줍니다.
//2. 이 스크립트가 연결된 상태라면 그 오브젝트는 대상의 컴포넌트를 제거할 수 없습니다.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; //소수점을 적을 때는 마지막에 f 기호를 사용합니다.
    //소수점 약 6자리까지 정확하게 계산

    public double jump_force = 3.5; //double도 실수를 표현하는 자료형이며 이경우에는 f를 붙이지 않습니다.
    //소수점 약 15자리 까지 정확하게 계산

    public bool isJump = false;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //해당 컴포넌트가 값을 얻어오는 기능
        //T 부분에는 컴포넌트의 형태를 작성해줍니다.
        //컴포넌트의 형태가 다르다면 오류 발생
        //해당데이터가 존재하지 않을 경우라면 null(값 없음)을 반환하게 됩니다.

    }

    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw("키 이름"); 은 인풋 매니저의 키를 얻어오면서 클릭에 따라 -1, 0 ,1의 수치로 값을 얻어옵니다.

        //Horizontal : 수평이동 a, d 키나 키보드의 왼쪽, 오른쪽키
        //Vertical : 수직이동 w, s 키나 키보드의 위쪽, 아래쪽키

        //위의 코드를 통해 움직일 방향을 계산합니다.
        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        //속력 = 방향 * 속도;

        transform.position += velocity; //현제 위치 += 변경되는 움직임
    }
    private void Jump()
    {
        //사용자가 키보드 Space키를 입력한다면
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if(!isJump) //점프 상태가 아닌 경우
            {
                isJump = true; //점프 상태로 변경
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
                //type casting(타입 캐스팅)
                //(타입 이름) 변수를 통해 해당 변수를 설정한 타입으로 변경가능
                //단 캐스팅이 가능한 범위에서만 진행 할 수 있음
                
                //주로 int -> float 같은 경우는 가능
                //데이터 타입이 서로 호환되지 않는 경우라면 사용 불가

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("골인!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //유니티에서 크기를 비교하는 연산자
        //a == b : a는 b와 크기가 같다.(값이 같다)
        //a != b : a는 b와 크기가 다르다.(값이 다르다)
        //a > b, a < b, a >= b, a <= b
        
        //충돌체의 게임 오브젝트의 레이어가 7과 비교했을때 크기가 같다면
        if(collision.gameObject.layer == 7)
        {
            isJump = false;
        }
        Debug.Log("땅을 밟았습니다!");
    }

}
