using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // 총알 프리팹
    public GameObject firePosition; // 총알 발사 위치

    #region 오브젝트 풀
    public int poolSize = 10;

    GameObject[] bulletObjectPool;
    #endregion


    private void Start()
    {
        // 1. 설정된 크기만큼 풀에 오브젝트 생성
        bulletObjectPool = new GameObject[poolSize];

        // 2. 수만큼 반복해 총알 생성

        for(int i = 0; i < poolSize; i++)
        {
            // 총알 생성
            var bullet = Instantiate(bulletFactory);
            // 풀에 등록
            bulletObjectPool[i] = bullet;
            // 비활성화( 필요할 때 활성화합니다. )
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < poolSize; i++)
            {
                // 총알 생성
                var bullet = bulletObjectPool[i];

                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }
        }
    }
}
