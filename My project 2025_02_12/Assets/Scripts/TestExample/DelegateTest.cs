using UnityEngine;

public interface DelegateTest
{
    void Edit();
}

public class AddNum : DelegateTest
{
    public void Edit()
    {
        Debug.Log("추가");
    }
}

public class DeleteNum : DelegateTest
{
    public void Edit()
    {
        Debug.Log("삭제");
    }
}
