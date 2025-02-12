using System;
using UnityEngine;

public class DelegateTestExample : MonoBehaviour
{
    delegate void TestDelegate();

    void Start()
    {
        TestDelegate test = new TestDelegate(Add);
        
    }

    public void OnClickAdd()
    {
        TestDelegate test = new TestDelegate(Add);
        test += Add;
    }

    public void OnClickDelete()
    {
        TestDelegate test = new TestDelegate(Delete);
    }

    void Add()
    {
        Debug.Log("�߰�");
    }

    void Delete()
    {
        Debug.Log("����");
    }
}
