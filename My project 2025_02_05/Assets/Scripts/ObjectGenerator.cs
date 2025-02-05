using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // 1. 이 클래스는 오브젝트르르 생성하는 기능을 가지고 있습니다.
    // 2. 마우스 버튼을 눌렀을때, 카메라의 스크린 지점을 통해 물체의 방향을 설정합니다.
    // 3. 물체를 방향에 맞춰 발사하는 기능을 호출해보겠습니다.

    public GameObject prefab; // 오브젝트 프리팹 등록
    public float power = 1000f; // 발사할 힘의 세기

    void Update()
    {
        // ~ down : 클릭 시 1번
        // ~ up : 버튼을 놓았을때 1번
        // : 클릭하고 있는 동안 지속

        // 마우스 0번 버튼을 눌렀을때
        // 마우스 버튼
        // 0 : 왼쪽
        // 1 : 오른쪽
        // 2 : 휠
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을때
        {
            var thrown = Instantiate(prefab); // 프리팹을 복제하여 새로운 오브젝트 생성
            // as GameObject는 Instantiate와 같이 사용하면 게임오브젝트로써 생성하라는 의미

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라가 바라보는 화면의 마우스 위치를 Ray로 변환
            // 레이(Ray)
            // 가상의 레이저 선으로, 발사되는 시작 지점과 방향을 가지고 있습니다.
            // 일반적인 Ray는 Vector3의 값을 가지고, Ray2D는 Vector2의 값을 가집니다.
            
            // 일반적인 레이 만드는 방법
            // Vector3 origin = new Vector3(0, 0, 0); // 레이의 시작점을 저장
            // Vector3 vect_dir = Vector3.forward; // 레이의 방향을 저장
            // Ray newRay = new Ray(origin, vect_dir); // 레이 생성

            Vector3 direction = ray.direction; // 레이의 방향을 저장

            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power); // 발사하는 기능 호출
            
            // normalized : 방향을 표준화하여 1로 만들어주는 기능
        }
    }
}
