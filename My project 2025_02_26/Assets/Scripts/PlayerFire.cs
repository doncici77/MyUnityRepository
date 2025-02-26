using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition; // �Ѿ� �߻� ��ġ

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);
            // �Ѿ� ��ġ ����
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
