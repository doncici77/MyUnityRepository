using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text startText; // ���� �ؽ�Ʈ ������Ʈ
    public Text endText; // ���� �ؽ�Ʈ ������Ʈ
    float fadeoutCount; // ���̵�ƿ��� ���� ����
    float fadeinCount; // ���̵����� ���� ����

    private void Start()
    {
        fadeinCount = 0;
        fadeoutCount = 1;
        StartCoroutine("FadeOutStart"); // ���۽� ��ŸƮ �ؽ�Ʈ ���̵� �ƿ�
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

    public void EndGame() // ��ũ��Ʈ �ܺο����� ȣ�� �����ϰ� public ���
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
