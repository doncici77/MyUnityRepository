using UnityEngine;

public class CreateObject3 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    // ����ȭ
    // �����ͳ� ������Ʈ�� ��ǻ�� ȯ�濡 �����ϰ� �籸���� �� �ִ� ����(����)�� ��ȯ�ϴ� ����
    // ����Ƽ������ �����ϰ� private ������ �����͸� �ν����Ϳ��� ���� �� �ְ� �������شٶ�� �����ϸ��.
    [SerializeField] GameObject sample;

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Table_Body");
        // Resources.Load<T>("������ġ/���¸�"); // ���ҽ� �����ȿ� �ִٴ� ����

        // T�� �������� ���븦 �����ִ� ��ġ�Դϴ�.
        // ���� ��ο� ������ ��� ������ �ȶ�. ����
    }

    void Update()
    {
        // �Է¹޴� Ű�� �����̽��� ���
        // GetKeyDown (Ű 1�� �Է�)
        // GetKeyUp (�Է� �� ���� ���)
        // GetKey (������ �ִ� ����)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();
            // gameObject.AddCoponent<T>
            // ������Ʈ�� ������Ʈ ����� �߰��ϴ� ���
            // GetComponent<T>
            // ������Ʈ�� ������ �ִ� ������Ʈ�� ����� ������ ���
            // ��ũ��Ʈ���� �ش� ������Ʈ�� ����� �����ͼ� ����ϰ� ���� ��� ���

        }
    }
}
