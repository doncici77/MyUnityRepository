using UnityEngine;

//클래스 안에 넣으면 이 데이터는 클래스 안에서만 사용가능해짐
public enum Rainbow
{
    빨,
    주,
    노,
    초,
    파,
    남,
    보
}

[AddComponentMenu("Park/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool jumpable;
    public string[] basket; //어떤 과일이 들어갈지 모르니까 자율성을 보장하는 리스트를 사용방법도 있음.
    public int money;
    [Range(1, 99)] public float fieldofView; //소수점도 가능하니 float도 생각해봤어야함.
    public Rainbow rainbow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
