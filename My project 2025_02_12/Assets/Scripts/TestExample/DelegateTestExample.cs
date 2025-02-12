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
        Debug.Log("추가");
    }

    void Delete()
    {
        Debug.Log("삭제");
    }
}
