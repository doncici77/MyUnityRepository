using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Queue<string> stringQueue = new Queue<string>(); // ��ȭ �ؽ�Ʈ�� ������ ť
    public TalkText talkText; // ��ȭ �ؽ�Ʈ�� ����Ʈ
    public UIManager uimanager; // typing �� �ϱ����� �ҷ�����
    public string textData; // ��ȭ ������ ����
    public int count = 0;
    void Start()
    {
        for(int i = 0; i < talkText.TalkTextList.Count; i++) // ť�� ����Ʈ�� �ؽ�Ʈ ����
        {
            stringQueue.Enqueue(talkText.TalkTextList[i]);
        }
    }

    public void NoTalk()
    {
        textData = "��ó�� NPC�� �����ϴ�.";
        uimanager.OutImage();
        uimanager.Typing();
    }

    public void Talk()
    {
        if (stringQueue.Count > 0) // ť�� �ؽ�Ʈ�� ���� ������
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
            textData = "���̻� �� ���� ����....";
            uimanager.NpcImage();
            uimanager.Typing();
        }
    }
}
