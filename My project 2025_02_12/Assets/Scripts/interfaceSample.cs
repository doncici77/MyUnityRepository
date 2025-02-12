using UnityEngine;

// ����Ƽ �������̽�(interface)
// �������� Ư¡�� ���� ���� ���� �� ȿ�����̴�.
// �Լ��� ������Ƽ ���� ���Ǹ� �������� ������ �� �ֵ��� �����ִ� ����̴�.
// �������̽��� ��ø� �ϱ� ������, ����ϱ� ���ؼ��� �ݵ�� ����� ���� �籸���� ������.

public interface ICountAble // �����ִ�
{
    // int a = 0; �������̽� �������� ���� ������.
    int Count { get; set; }

    void CountPlus();
}

public interface IUseAble // ����� �� �ִ�
{
    void Use();
}

class Item
{

}

// �������̽��� ���ó�� ����� �� �ִ�.
// �������̽��� ��� ���� ����� ������.
class Potion : Item, ICountAble, IUseAble
{
    private int count;
    private string name;

    public int Count 
    {
        get
        {
            return count;
        } 
        set
        {
            if(count > 99)
            {
                Debug.Log("count�� �ִ� 99���Դϴ�");
                count = 99;
            }

            count = value;
        }
    }

    public string Name 
    { 
        get => name; 
        set => name = value; 
    }

    public void CountPlus()
    {
        Count++;
    }

    public void Use()
    {
        Debug.Log($"{Name}�� ����߽��ϴ�.");
        Count--;
    }
}

public class interfaceSample : MonoBehaviour
{
    Potion potion = new Potion();

    void Start()
    {
        // �ϼ��� Ŭ���� ���
        potion.Count = 99;
        potion.Name = "���� ����";
        potion.CountPlus();
        potion.Use();
    }

    void Update()
    {
        
    }
}
