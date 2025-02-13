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
    public GameObject acceptButton; // 수락 버튼
    public GameObject cancelButton; // 거절 버튼
    public GameObject killMonButton; // 몬스터 킬 버튼
    public GameObject successButton; // 성공 버튼
    public GameObject rewardButton; // 보상 버튼
    public GameObject questText; // 퀘스트 제목 텍스트
    public int cancelCount = 1; // 거절 횟수

    private void Start()
    {
        talkText.text = "나 좀 도와주지 않겠나?";
        talkButton.SetActive(true);
        UpdateStateText();
    }

    public void OnClickAcceptQuest() // 수락 버튼
    {
        DisableButtons();
        Quest.진행상태 = true;
        Talk(Quest.내용);
        killMonButton.SetActive(true);
        questText.SetActive(true);
    }

    public void OnClickCancelQuest() // 거절 버튼
    {
        cancelCount++;
        StartCoroutine(CancelQuest());
    }

    IEnumerator CancelQuest() // 거절 로직
    {
        Talk("서운하구만...");
        DisableButtons();
        yield return new WaitForSeconds(2f);
        Talk($"나 좀 도와주지 않겠나? {cancelCount}트");
        talkButton.SetActive(true);
    }

    public void OnClickTalk() // 대화 버튼
    {
        Talk(Quest.설명);
        EnableButtons();
        talkButton.SetActive(false);
    }

    public void OnClickReward() // 보상 버튼
    {
        Talk($"보상 경험치: {Reward.경험치}\n보상 골드: {Reward.돈}");
        rewardButton.SetActive(false);
    }

    public void OnClickSuccess() // 성공 버튼
    {
        Talk("퀘스트를 완료하셨습니다!");
        successButton.SetActive(false);
        killMonButton.SetActive(false);
        rewardButton.SetActive(true);
        Quest.성공 = true;
        Quest.진행상태 = false;
        UpdateStateText();
        questNameText.text = Quest.제목;
    }

    public void OnClickKillMonster() // 몬스터 킬 버튼
    {
        Requirement.현제잡은몬스터수++;
        Talk($"목표: {Requirement.목표몬스터수} 마리\n현재: {Requirement.현제잡은몬스터수} 마리");
        if (Requirement.현제잡은몬스터수 >= Requirement.목표몬스터수)
        {
            successButton.SetActive(true);
        }
    }

    void EnableButtons() // 버튼 활성화
    {
        cancelButton.SetActive(true);
        acceptButton.SetActive(true);
    }

    void DisableButtons() // 버튼 비활성화
    {
        cancelButton.SetActive(false);
        acceptButton.SetActive(false);
    }

    void UpdateStateText() // 상태 텍스트 업데이트
    {
        stateText.text = $"성공여부: {Quest.성공}\n진행중: {Quest.진행상태}\n퀘스트 유형: {Quest.퀘스트유형}";
    }

    void Talk(string text) // 대화 텍스트 출력
    {
        talkText.text = text;
    }
}