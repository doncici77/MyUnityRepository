using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    Vector3 dir; // �̵� ����

    public GameObject explosionFactory; // ��ƼŬ ���

    private void Start()
    {
        // ���� ���� ����
        int rand = Random.Range(0, 9); // 0 ~ 9 ���� ���� �� �ϳ� ������

        // 10�� �߿��� 3���̹Ƿ� �� 30% Ȯ���̶�� �� �� ����.
        if (rand < 3)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                var target = GameObject.FindGameObjectWithTag("Player");

                dir = target.transform.position - transform.position;

                dir.Normalize(); // ������ ũ�⸦ 1�� ����
                                 // ���� ����(Vecter3.up, Vecter3.down, Vecter3.left ....)
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
        GameObject explosion = Instantiate(explosionFactory); // ��ƼŬ ����
        explosion.transform.position = transform.position; // ��ƼŬ ��ġ ����

        Destroy(collision.gameObject); // �� ��ü�� �浹�� ������Ʈ �ı�
        Destroy(gameObject);
    }
}
