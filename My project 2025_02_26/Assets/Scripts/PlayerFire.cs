using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition; // �Ѿ� �߻� ��ġ

    #region ������Ʈ Ǯ
    public int poolSize = 10;

    GameObject[] bulletObjectPool;
    #endregion


    private void Start()
    {
        // 1. ������ ũ�⸸ŭ Ǯ�� ������Ʈ ����
        bulletObjectPool = new GameObject[poolSize];

        // 2. ����ŭ �ݺ��� �Ѿ� ����

        for(int i = 0; i < poolSize; i++)
        {
            // �Ѿ� ����
            var bullet = Instantiate(bulletFactory);
            // Ǯ�� ���
            bulletObjectPool[i] = bullet;
            // ��Ȱ��ȭ( �ʿ��� �� Ȱ��ȭ�մϴ�. )
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < poolSize; i++)
            {
                // �Ѿ� ����
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
