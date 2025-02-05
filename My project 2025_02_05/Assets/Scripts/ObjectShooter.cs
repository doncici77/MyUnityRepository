using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    // 발사 기능을 제공해주는 클래스스 
    // 충돌시 오브젝트를 고정시켜주는 역할도 진행합니다. 
    GameObject objectGenerator; // 오브젝트 생성기
    //ObjectGenerator obj;

    void Start()
    {
        objectGenerator = GameObject.Find("ObjectGenerator"); // 오브젝트 탐색
        // == 오브젝트 탐색 기능 ==
        // 씬에서 해당오브젝트를 가진 게임오브젝트를 찿아 그 값을 얻어오는 GameObjecr.Find() 기능
        // objectGenerator = GameObject.FindWithTag("Generator"); // Generator 태그를 가직 오브젝트를 탐색
        // obj = FindObjectOfType<ObjectGenerator>(); <> 안에 넣어준 타입에 맞는 오브젝트를 탐색

        // 가장쉬운건 Find()
        // 하지만 검색 범위가 너무 많아지면 불필요하게 성능저하가 발생할수 있음
        // 따라서 그때부터 Tag나 Type 등으로 검색범위를 제한해서 찾는 방식을 사용

        // 씬에 해당 값이 없으면 null
    }

    /// <summary>
    /// 물체를 발사하는 기능을 가진 함수(메소드)
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(Vector3 direction) // 발사하는 기능을 가진 함수
    {
        GetComponent<Rigidbody>().AddForce(direction); // 물체에 힘을 가해 발사
        Debug.Log("발사!");
    }

    private void OnCollisionEnter(Collision collision) // 충돌시
    {
        GetComponent<Rigidbody>().isKinematic = true; // 충돌시 물체를 고정
        Debug.Log("맞았습니다");
        GetComponentInChildren<ParticleSystem>().Play(); // 파티클 재생

        if(collision.gameObject.tag == "terrain") // 충돌한 오브젝트의 태그가 terrain이면
        {
            Destroy(gameObject, 1.0f); // 1초 뒤에 오브젝트 삭제
        }
        else // 과녁인 경우
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10); // 점수 획득
        }
    }
}
