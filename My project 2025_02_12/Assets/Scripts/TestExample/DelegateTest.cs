using UnityEngine;

public interface DelegateTest
{
    void Edit();
}

public class AddNum : DelegateTest
{
    public void Edit()
    {
        Debug.Log("�߰�");
    }
}

public class DeleteNum : DelegateTest
{
    public void Edit()
    {
        Debug.Log("����");
    }
}
