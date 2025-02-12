using UnityEngine;

// 유니티 인터페이스(interface)
// 공통적인 특징에 대한 관리 구현 시 효과적이다.
// 함수와 프로퍼티 등의 정의를 구현없이 진행할 수 있도록 도와주는 기능이다.
// 인터페이스는 명시만 하기 때문에, 사용하기 위해서는 반드시 상속을 통한 재구현을 진행함.

public interface ICountAble // 셀수있는
{
    // int a = 0; 인터페이스 내에서는 선언만 진행함.
    int Count { get; set; }

    void CountPlus();
}

public interface IUseAble // 사용할 수 있는
{
    void Use();
}

class Item
{

}

// 인터페이스는 상속처럼 등록할 수 있다.
// 인터페이스의 경우 다중 상속이 가능함.
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
                Debug.Log("count는 최대 99개입니다");
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
        Debug.Log($"{Name}을 사용했습니다.");
        Count--;
    }
}

public class interfaceSample : MonoBehaviour
{
    Potion potion = new Potion();

    void Start()
    {
        // 완성된 클래스 사용
        potion.Count = 99;
        potion.Name = "빨간 포션";
        potion.CountPlus();
        potion.Use();
    }

    void Update()
    {
        
    }
}
