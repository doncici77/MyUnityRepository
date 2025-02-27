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
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory); // 파티클 생성
        explosion.transform.position = transform.position; // 파티클 위치 변경

        // 부딪힌 물체의 이름에 Bullet이 포함 된다면?
        // 오브젝트 풀로 만들어질 이름은 Bullet(Clone)
        if(collision.gameObject.name.Contains("Bullet"))
        {
            // 해당 충돌체를 비활성화 처리합니다.
            collision.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false); // 적도 비활성화
    }
}
