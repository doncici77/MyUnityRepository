using UnityEngine;

//Ŭ���� �ȿ� ������ �� �����ʹ� Ŭ���� �ȿ����� ��밡������
public enum Rainbow
{
    ��,
    ��,
    ��,
    ��,
    ��,
    ��,
    ��
}

[AddComponentMenu("Park/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool jumpable;
    public string[] basket; //� ������ ���� �𸣴ϱ� �������� �����ϴ� ����Ʈ�� ������� ����.
    public int money;
    [Range(1, 99)] public float fieldofView; //�Ҽ����� �����ϴ� float�� �����غþ����.
    public Rainbow rainbow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
