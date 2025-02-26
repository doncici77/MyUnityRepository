using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    Vector3 dir; // 이동 방향

    public GameObject explosionFactory; // 파티클 등록

    private void Start()
    {
        // 적의 방향 설정
        int rand = Random.Range(0, 9); // 0 ~ 9 사이 랜덤 값 하나 가져옴

        // 10개 중에서 3개이므로 약 30% 확률이라고 볼 수 있음.
        if (rand < 3)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                var target = GameObject.FindGameObjectWithTag("Player");

                dir = target.transform.position - transform.position;

                dir.Normalize(); // 방향의 크기를 1로 설정
                                 // 방향 벡터(Vecter3.up, Vecter3.down, Vecter3.left ....)
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory); // 파티클 생성
        explosion.transform.position = transform.position; // 파티클 위치 변경

        Destroy(collision.gameObject); // 이 객체와 충돌한 오브젝트 파괴
        Destroy(gameObject);
    }
}
