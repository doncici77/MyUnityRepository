using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Queue<string> stringQueue = new Queue<string>(); // 대화 텍스트를 저장할 큐
    public TalkText talkText; // 대화 텍스트의 리스트
    public UIManager uimanager; // typing 을 하기위해 불러오기
    public string textData; // 대화 데이터 저장
    public int count = 0;
    void Start()
    {
        for(int i = 0; i < talkText.TalkTextList.Count; i++) // 큐에 리스트의 텍스트 삽입
        {
            stringQueue.Enqueue(talkText.TalkTextList[i]);
        }
    }

    public void NoTalk()
    {
        textData = "근처에 NPC가 없습니다.";
        uimanager.OutImage();
        uimanager.Typing();
    }

    public void Talk()
    {
        if (stringQueue.Count > 0) // 큐에 텍스트가 남아 있을때
        {
            textData = stringQueue.Dequeue();
            if (count == 2)
            {
                uimanager.PlayerImage();
            }
            else
            {
                uimanager.NpcImage();
            }
            uimanager.Typing();
            count++;
        }
        else
        {
            textData = "더이상 할 말이 없네....";
            uimanager.NpcImage();
            uimanager.Typing();
        }
    }
}
