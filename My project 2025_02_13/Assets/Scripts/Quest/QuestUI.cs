using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text talkText; // ��ȭ �ؽ�Ʈ
    public Text stateText; // �����Ȳ �ؽ�Ʈ
    public Text questNameText; // ����Ʈ ���� �ؽ�Ʈ
    public Quest Quest;
    public Reward Reward;
    public Requirement Requirement;

    public GameObject talkButton; // ��ȭ ��ư
    public GameObject acceptButton; // ���� ��ư
    public GameObject cancelButton; // ���� ��ư
    public GameObject killMonButton; // ���� ų ��ư
    public GameObject successButton; // ���� ��ư
    public GameObject rewardButton; // ���� ��ư
    public GameObject questText; // ����Ʈ ���� �ؽ�Ʈ
    public int cancelCount = 1; // ���� Ƚ��

    private void Start()
    {
        talkText.text = "�� �� �������� �ʰڳ�?";
        talkButton.SetActive(true);
        UpdateStateText();
    }

    public void OnClickAcceptQuest() // ���� ��ư
    {
        DisableButtons();
        Quest.������� = true;
        Talk(Quest.����);
        killMonButton.SetActive(true);
        questText.SetActive(true);
    }

    public void OnClickCancelQuest() // ���� ��ư
    {
        cancelCount++;
        StartCoroutine(CancelQuest());
    }

    IEnumerator CancelQuest() // ���� ����
    {
        Talk("�����ϱ���...");
        DisableButtons();
        yield return new WaitForSeconds(2f);
        Talk($"�� �� �������� �ʰڳ�? {cancelCount}Ʈ");
        talkButton.SetActive(true);
    }

    public void OnClickTalk() // ��ȭ ��ư
    {
        Talk(Quest.����);
        EnableButtons();
        talkButton.SetActive(false);
    }

    public void OnClickReward() // ���� ��ư
    {
        Talk($"���� ����ġ: {Reward.����ġ}\n���� ���: {Reward.��}");
        rewardButton.SetActive(false);
    }

    public void OnClickSuccess() // ���� ��ư
    {
        Talk("����Ʈ�� �Ϸ��ϼ̽��ϴ�!");
        successButton.SetActive(false);
        killMonButton.SetActive(false);
        rewardButton.SetActive(true);
        Quest.���� = true;
        Quest.������� = false;
        UpdateStateText();
        questNameText.text = Quest.����;
    }

    public void OnClickKillMonster() // ���� ų ��ư
    {
        Requirement.�����������ͼ�++;
        Talk($"��ǥ: {Requirement.��ǥ���ͼ�} ����\n����: {Requirement.�����������ͼ�} ����");
        if (Requirement.�����������ͼ� >= Requirement.��ǥ���ͼ�)
        {
            successButton.SetActive(true);
        }
    }

    void EnableButtons() // ��ư Ȱ��ȭ
    {
        cancelButton.SetActive(true);
        acceptButton.SetActive(true);
    }

    void DisableButtons() // ��ư ��Ȱ��ȭ
    {
        cancelButton.SetActive(false);
        acceptButton.SetActive(false);
    }

    void UpdateStateText() // ���� �ؽ�Ʈ ������Ʈ
    {
        stateText.text = $"��������: {Quest.����}\n������: {Quest.�������}\n����Ʈ ����: {Quest.����Ʈ����}";
    }

    void Talk(string text) // ��ȭ �ؽ�Ʈ ���
    {
        talkText.text = text;
    }
}