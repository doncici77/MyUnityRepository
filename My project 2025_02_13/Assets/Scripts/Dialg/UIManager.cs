using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text; // 텍스트 오브젝트
    public TalkManager talkManager; // 텍스트 내용을 가져오기 위함
    float delay = 0.1f; // 읽는 속도
    public GameObject playerImage;
    public GameObject npcImage;

    public void PlayerImage()
    {
        playerImage.SetActive(true);
        npcImage.SetActive(false);
    }

    public void NpcImage()
    {
        playerImage.SetActive(false);
        npcImage.SetActive(true);
    }

    public void OutImage()
    {
        playerImage.SetActive(false);
        npcImage.SetActive(false);
    }

    public void Typing()
    {
        StartCoroutine("TalkText");
    }

    IEnumerator TalkText()
    {
        text.text = ""; // 텍스트 초기화
        int typing_count = 0; // 타이핑 카운트를 0으로 설정합니다.
        // 현제 카운트가 컨텐츠의 길이와 다르다면
        while (typing_count != talkManager.textData.Length)
        {
            if (typing_count < talkManager.textData.Length)
            {
                text.text += talkManager.textData[typing_count].ToString();
                // 현제 카운트에 해당하는 단어 하나를 메세지 텍스트 UI에 전달
                typing_count++;
                // 카운트를 1 증가
            }
            yield return new WaitForSeconds(delay);
            // 현제의 딜레이만큼 대기
        }
        yield return null;
    }
}
