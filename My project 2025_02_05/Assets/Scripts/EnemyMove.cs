using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject playerBody; // PlayerBody ���� ������Ʈ�� ������ ����

    void Start()
    {
        playerBody = GameObject.Find("PlayerBody"); // PlayerBody ���� ������Ʈ�� ã�Ƽ� �Ҵ�
    }

    private void Update()
    {
        // Enemy�� ��ġ�� PlayerBody�� ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerBody.transform.position.x, transform.position.y, playerBody.transform.position.z), Time.deltaTime* 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBody") // �浹�� ������Ʈ�� �̸��� "PlayerBody"�� ��
        {
            Destroy(gameObject); // Enemy ������Ʈ�� ����
        }
    }

    private void OnCollisionEnter(Collision collision) // �浹��   
    {
        if (collision.gameObject.tag == "Bullet") // �浹�� ������Ʈ�� �̸��� "PlayerBody"�� ��
        {
            Destroy(gameObject); // Enemy ������Ʈ�� ����
        }
    }
}
