using System;
using UnityEngine;

[Flags]
public enum FRUITS
{
    None = 0,
    ��� = 1 << 0,
    ���� = 1 << 1,
    ���� = 1 << 2,
    �� = 1 << 3,
    �ٳ��� = 1 << 4
}

public enum RAINBOW
{
    ��,
    ��,
    ��,
    ��,
    ��,
    ��,
    ��
}

//AddComponentMenu�� ������Ʈ�� Park�� ��� ����
[AddComponentMenu("Park/Sample01")]
public class Sample01 : MonoBehaviour
{
    //���� ���ɿ��� bool��
    [Tooltip("üũ�Ǹ� ������ ������ �������� �ǹ��մϴ�.")]
    public bool can_jump = false;

    //���� �ٱ��� ������ flag�� �ߺ� �����ϰ� ��
    public FRUITS fruit_basket;

    //�� int ������
    [Tooltip("���� ���� ��Ÿ����.")]
    public int money = 0;

    //�ʵ� �� ������ Range�� �̿�
    [Range(0, 100)]
    public int field_of_view;

    //�������� ���� �ߺ� ���ɺҰ��� ����
    public RAINBOW rainbow;



    private void Start()
    {
        Debug.Log(fruit_basket);
        Debug.Log(rainbow);
    }


}
