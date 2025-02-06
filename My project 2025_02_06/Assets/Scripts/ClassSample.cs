using UnityEngine;
// �⺻���� ����Ƽ Class ����

class Unit
{
    // Ŭ�������� �ش� Ŭ������ ���� ��ü�� ������ �ۼ���.
    public string unit_name;

    // Ŭ�������� �ش� Ŭ������ ���� ��ü�� ����, ����� �ۼ��� �� ����. (�޼ҵ�)
    public static void UnitAction()
    {
        Debug.Log("������ �����մϴ�.");
    }

    public void Cry()
    {
        Debug.Log("������ ���¢�����ϴ�.");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit; // Unit Ŭ���� �������� ���� unit ��ü(object)

    void Start()
    {
        unit.unit_name = "MiniGun";
        // Ŭ����������.�ʵ带 ���� Ŭ������ ������ �ִ� �ʵ�(����)�� ����� �� ����.

        unit.Cry();
        // �ν��Ͻ���.�޼ҵ�()�� ���� Ŭ������ ������ �ִ� �޼ҵ�(�Լ�)�� ����� �� ����.

        // Ŭ���� ������� ���� ��Ī
        // ��ü: ���� ������, Ŭ������ �� ��ü�� ����� ���� ���ø� ����
        // ex) Animal cat; (��ü)
        //      Animal cat = new Animal(); (��ü)

        // ���۷���: ��ü�� �޸� �󿡼��� ��ġ�� ����Ű�� ��
        // Ŭ������ �迭, �������̽� � �ش�

        // �ν��Ͻ�: ��ü�� ����Ʈ����� ��üȭ�� ��(new �� ���� ����������� �ν��ͽ�)
        // ex) Animal cat = new Animal();

        Unit.UnitAction();
        // static�� ���� ������ �Լ��� ��ü�� �������� �ʰ� Ŭ�������� �ٷ� �� ����� ������ �����.

    }

    void Update()
    {
        
    }
}
