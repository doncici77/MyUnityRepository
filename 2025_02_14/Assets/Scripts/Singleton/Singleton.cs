using UnityEngine;

// ����Ƽ�� ������ ���� �ڵ�: singleton

// ���������� ���Ǵ� �����͸� �ϳ��� ��ü(�ν��Ͻ�)�� �������ڽ��ϴ�.

public class Tester : MonoBehaviour
{
    int point = 0;

    private void Start()
    {
        point = Singleton.Instance.point; // �̵��濡 �ִ� ������Ƽ
        Singleton.Instance.PointPlus(); 
        // �Ǵ� �޼ҵ带 ���� Ŭ���� ������ ��ü�� �����ؼ� ��ü�� ������ �ִ� ������ ����� �� �ֽ��ϴ�.

        // �̱��� ������ ������ ������ ������ �ʿ���� �ٷ� �� ����� ����� �� ����.
        // ��� �̵��� �������� ������ �ν��Ͻ��� �ʹ� ���� �����͸� �����ϴ� �����
        // ������ ��ư� �׽�Ʈ�� ��ٷο�����.
    }
}

public class Singleton : MonoBehaviour
{
    // 1. �ν��Ͻ��̸鼭 �������� ������ �� �ְ� �����Ѵ�.
    private static Singleton _instance;

    // 2. Ŭ���� ���ο� ǥ���� ���� �����մϴ�.
    public int point = 0;

    public void PointPlus()
    {
        point++;
    }

    public void ViewPoint()
    {
        Debug.Log("���� ����Ʈ: " + point);
    }

    // �޼ҵ带 ���ؼ� ����
    public static Singleton GetInstance()
    {
        if(_instance == null) // ���� ���� ��� �ִٸ�
        {
            _instance = new Singleton(); // ���Ӱ� �Ҵ��մϴ�.
        }
        return _instance; // �Ϲ����� ����� ������ �ν��Ͻ��� return�մϴ�.
    }

    // ������Ƽ�� �����ϴ� �͵� �����ϴ�.
    public static Singleton Instance
    {
        get
        {
            if( _instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
