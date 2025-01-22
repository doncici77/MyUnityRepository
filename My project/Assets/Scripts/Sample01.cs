using System;
using UnityEngine;

[Flags]
public enum FRUITS
{
    None = 0,
    사과 = 1 << 0,
    딸기 = 1 << 1,
    수박 = 1 << 2,
    귤 = 1 << 3,
    바나나 = 1 << 4
}

public enum RAINBOW
{
    빨,
    주,
    노,
    초,
    파,
    남,
    보
}

//AddComponentMenu로 컴포넌트의 Park의 경로 생성
[AddComponentMenu("Park/Sample01")]
public class Sample01 : MonoBehaviour
{
    //점프 가능여부 bool형
    [Tooltip("체크되면 점프가 가능한 상태임을 의미합니다.")]
    public bool can_jump = false;

    //과일 바구니 열거형 flag로 중복 가능하게 함
    public FRUITS fruit_basket;

    //돈 int 정수형
    [Tooltip("돈의 양을 나타낸다.")]
    public int money = 0;

    //필드 뷰 정수형 Range를 이용
    [Range(0, 100)]
    public int field_of_view;

    //무지개의 색은 중복 가능불가로 가정
    public RAINBOW rainbow;



    private void Start()
    {
        Debug.Log(fruit_basket);
        Debug.Log(rainbow);
    }


}
