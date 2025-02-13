using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text talkText; // 대화 텍스트
    public Text stateText; // 진행상황 텍스트
    public Text questNameText; // 퀘스트 제목 텍스트
    public Quest Quest;
    public Reward Reward;
    public Requirement Requirement;
    
    public GameObject talkButton; // 대화 버튼
    public GameObject acceptButon; // 수락 버튼
    public GameObject cancelButon; // 거절 버튼
    public GameObject killMonButton; // 몬스터 킬 버튼
    public GameObject successButton; // 성공 버튼
    public GameObject rewardButton; // 보상 버튼
    public GameObject questText; // 퀘스트 제목 텍스트
    public int cancelCount = 1; // 거절 횟수

    private void Start()
    {
        talkText.text = " 나 좀 도와주지 않겠나?";
        talkButton.SetActive(true);
        TextState(Quest.성공, Quest.진행상태, Quest.퀘스트유형);
    }

    public void OnClickAcceptQuest() // 수락 버튼 눌렀을때
    {
        Debug.Log("퀘스트 수락");
        OffButton(); // 퀘스트 버튼 비활성화
        Quest.진행상태 = true;
        Talk(Quest.내용.ToString());
        killMonButton.SetActive(true); // 킬몬스터 버튼 출력
        TextState(Quest.성공, Quest.진행상태, Quest.퀘스트유형);
        questText.SetActive(true);
    }

    public void OnClickCancelQuest() // 거절 버튼 눌렀을때
    {
        cancelCount++;
        StartCoroutine("CancelQuest");
    }

    IEnumerator CancelQuest() // 거절 버튼 로직
    {
        Debug.Log("퀘스트 거절");
        Talk("서운하구만...");
        OffButton(); // 퀘스트 버튼 비활성화
        yield return new WaitForSeconds(2f);
        Talk(" 나 좀 도와주지 않겠나? " + cancelCount.ToString() + "트");
        talkButton.SetActive(true);

    }

    public void OnClickTalk() // 대화 진행 버튼 눌렀을때
    {
        Debug.Log("대화 진행");
        Talk(Quest.설명.ToString());
        OnButton(); // 퀘스트 버튼 활성화
        talkButton.SetActive(false);
    }

    public void OnClickReward() // 보상받기 버튼 눌렀을때
    {
        Talk("보상 경험치: " + Reward.경험치.ToString() + "\n" + 
            "보상 골드: " + Reward.돈.ToString());
        rewardButton.SetActive(false);
    }

    public void OnClickSuccess() // 성공 버튼 눌렀을때
    {
        Talk(" 퀘스트를 완료하셨습니다! ");
        successButton.SetActive(false);
        killMonButton.SetActive(false);
        rewardButton.SetActive(true);
        Quest.성공 = true;
        Quest.진행상태 = false;
        TextState(Quest.성공, Quest.진행상태 , Quest.퀘스트유형);
        questNameText.text = Quest.제목;
    }

    public void OnClickKillMonster() // 몬스터 킬 버튼 눌렀을 때
    {
        Requirement.현제잡은몬스터수++;
        Debug.Log($"{Requirement.현제잡은몬스터수} 마리");
        Talk("목표: " + Requirement.목표몬스터수.ToString() + " 마리" + "\n" +
            "현제: " + Requirement.현제잡은몬스터수.ToString() + " 마리");
        if(Requirement.현제잡은몬스터수 >= Requirement.목표몬스터수)
        {
            successButton.SetActive(true);
        }
    }

    void OnButton() // 퀘스트 수락 버튼 활성화
    {
        cancelButon.SetActive(true);
        acceptButon.SetActive(true);
    }

    void OffButton() // 퀘스트 수락 버튼 비활성화
    {
        cancelButon.SetActive(false);
        acceptButon.SetActive(false);
    }

    public void TextState(bool success, bool state , QuestType questType)
    {
        stateText.text = "성공여부: " + success.ToString() + "\n"
            + "진행중: " + state.ToString() + "\n" 
            + "퀘스트 유형: " + questType;
    }

    public void Talk(string text) // 텍스트 출력
    {
        talkText.text = text; // 대화 텍스트 출력
    }


}
