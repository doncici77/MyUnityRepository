using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text startText; // 시작 텍스트 오브젝트
    public Text endText; // 엔드 텍스트 오브젝트
    float fadeoutCount; // 페이드아웃을 위한 변수
    float fadeinCount; // 페이드인을 위한 변수

    private void Start()
    {
        fadeinCount = 0;
        fadeoutCount = 1;
        StartCoroutine("FadeOutStart"); // 시작시 스타트 텍스트 페이드 아웃
    }

    IEnumerator FadeOutStart()
    {
        while (fadeoutCount > 0)
        {
            fadeoutCount -= 0.01f;
            startText.color = new Color(255, 255, 255, fadeoutCount);
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void EndGame() // 스크립트 외부에서의 호출 가능하게 public 사용
    {
        StartCoroutine("FadeInEnd");
    }

    IEnumerator FadeInEnd()
    {
        while (fadeoutCount < 1)
        {
            fadeinCount += 0.01f;
            endText.color = new Color(255, 249, 0, fadeinCount);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
