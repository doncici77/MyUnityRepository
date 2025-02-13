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
    public GameObject acceptButon; // ���� ��ư
    public GameObject cancelButon; // ���� ��ư
    public GameObject killMonButton; // ���� ų ��ư
    public GameObject successButton; // ���� ��ư
    public GameObject rewardButton; // ���� ��ư
    public GameObject questText; // ����Ʈ ���� �ؽ�Ʈ
    public int cancelCount = 1; // ���� Ƚ��

    private void Start()
    {
        talkText.text = " �� �� �������� �ʰڳ�?";
        talkButton.SetActive(true);
        TextState(Quest.����, Quest.�������, Quest.����Ʈ����);
    }

    public void OnClickAcceptQuest() // ���� ��ư ��������
    {
        Debug.Log("����Ʈ ����");
        OffButton(); // ����Ʈ ��ư ��Ȱ��ȭ
        Quest.������� = true;
        Talk(Quest.����.ToString());
        killMonButton.SetActive(true); // ų���� ��ư ���
        TextState(Quest.����, Quest.�������, Quest.����Ʈ����);
        questText.SetActive(true);
    }

    public void OnClickCancelQuest() // ���� ��ư ��������
    {
        cancelCount++;
        StartCoroutine("CancelQuest");
    }

    IEnumerator CancelQuest() // ���� ��ư ����
    {
        Debug.Log("����Ʈ ����");
        Talk("�����ϱ���...");
        OffButton(); // ����Ʈ ��ư ��Ȱ��ȭ
        yield return new WaitForSeconds(2f);
        Talk(" �� �� �������� �ʰڳ�? " + cancelCount.ToString() + "Ʈ");
        talkButton.SetActive(true);

    }

    public void OnClickTalk() // ��ȭ ���� ��ư ��������
    {
        Debug.Log("��ȭ ����");
        Talk(Quest.����.ToString());
        OnButton(); // ����Ʈ ��ư Ȱ��ȭ
        talkButton.SetActive(false);
    }

    public void OnClickReward() // ����ޱ� ��ư ��������
    {
        Talk("���� ����ġ: " + Reward.����ġ.ToString() + "\n" + 
            "���� ���: " + Reward.��.ToString());
        rewardButton.SetActive(false);
    }

    public void OnClickSuccess() // ���� ��ư ��������
    {
        Talk(" ����Ʈ�� �Ϸ��ϼ̽��ϴ�! ");
        successButton.SetActive(false);
        killMonButton.SetActive(false);
        rewardButton.SetActive(true);
        Quest.���� = true;
        Quest.������� = false;
        TextState(Quest.����, Quest.������� , Quest.����Ʈ����);
        questNameText.text = Quest.����;
    }

    public void OnClickKillMonster() // ���� ų ��ư ������ ��
    {
        Requirement.�����������ͼ�++;
        Debug.Log($"{Requirement.�����������ͼ�} ����");
        Talk("��ǥ: " + Requirement.��ǥ���ͼ�.ToString() + " ����" + "\n" +
            "����: " + Requirement.�����������ͼ�.ToString() + " ����");
        if(Requirement.�����������ͼ� >= Requirement.��ǥ���ͼ�)
        {
            successButton.SetActive(true);
        }
    }

    void OnButton() // ����Ʈ ���� ��ư Ȱ��ȭ
    {
        cancelButon.SetActive(true);
        acceptButon.SetActive(true);
    }

    void OffButton() // ����Ʈ ���� ��ư ��Ȱ��ȭ
    {
        cancelButon.SetActive(false);
        acceptButon.SetActive(false);
    }

    public void TextState(bool success, bool state , QuestType questType)
    {
        stateText.text = "��������: " + success.ToString() + "\n"
            + "������: " + state.ToString() + "\n" 
            + "����Ʈ ����: " + questType;
    }

    public void Talk(string text) // �ؽ�Ʈ ���
    {
        talkText.text = text; // ��ȭ �ؽ�Ʈ ���
    }


}
