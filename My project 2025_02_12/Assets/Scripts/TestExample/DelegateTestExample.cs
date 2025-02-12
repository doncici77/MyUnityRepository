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
        Add();
    }

    public void OnClickDelete()
    {
        Delete();
    }

    void Add()
    {
        
    }
    void Delete()
    {

    }
}
