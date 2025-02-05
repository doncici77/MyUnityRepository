using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    // �߻� ����� �������ִ� Ŭ������ 
    // �浹�� ������Ʈ�� ���������ִ� ���ҵ� �����մϴ�. 
    GameObject objectGenerator; // ������Ʈ ������
    //ObjectGenerator obj;

    void Start()
    {
        objectGenerator = GameObject.Find("ObjectGenerator"); // ������Ʈ Ž��
        // == ������Ʈ Ž�� ��� ==
        // ������ �ش������Ʈ�� ���� ���ӿ�����Ʈ�� �O�� �� ���� ������ GameObjecr.Find() ���
        // objectGenerator = GameObject.FindWithTag("Generator"); // Generator �±׸� ���� ������Ʈ�� Ž��
        // obj = FindObjectOfType<ObjectGenerator>(); <> �ȿ� �־��� Ÿ�Կ� �´� ������Ʈ�� Ž��

        // ���彬��� Find()
        // ������ �˻� ������ �ʹ� �������� ���ʿ��ϰ� �������ϰ� �߻��Ҽ� ����
        // ���� �׶����� Tag�� Type ������ �˻������� �����ؼ� ã�� ����� ���

        // ���� �ش� ���� ������ null
    }

    /// <summary>
    /// ��ü�� �߻��ϴ� ����� ���� �Լ�(�޼ҵ�)
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(Vector3 direction) // �߻��ϴ� ����� ���� �Լ�
    {
        GetComponent<Rigidbody>().AddForce(direction); // ��ü�� ���� ���� �߻�
        Debug.Log("�߻�!");
    }

    private void OnCollisionEnter(Collision collision) // �浹��
    {
        GetComponent<Rigidbody>().isKinematic = true; // �浹�� ��ü�� ����
        Debug.Log("�¾ҽ��ϴ�");
        GetComponentInChildren<ParticleSystem>().Play(); // ��ƼŬ ���

        if(collision.gameObject.tag == "terrain") // �浹�� ������Ʈ�� �±װ� terrain�̸�
        {
            Destroy(gameObject, 1.0f); // 1�� �ڿ� ������Ʈ ����
        }
        else // ������ ���
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10); // ���� ȹ��
        }
    }
}
