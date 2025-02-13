using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text; // �ؽ�Ʈ ������Ʈ
    public TalkManager talkManager; // �ؽ�Ʈ ������ �������� ����
    float delay = 0.1f; // �д� �ӵ�
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
        text.text = ""; // �ؽ�Ʈ �ʱ�ȭ
        int typing_count = 0; // Ÿ���� ī��Ʈ�� 0���� �����մϴ�.
        // ���� ī��Ʈ�� �������� ���̿� �ٸ��ٸ�
        while (typing_count != talkManager.textData.Length)
        {
            if (typing_count < talkManager.textData.Length)
            {
                text.text += talkManager.textData[typing_count].ToString();
                // ���� ī��Ʈ�� �ش��ϴ� �ܾ� �ϳ��� �޼��� �ؽ�Ʈ UI�� ����
                typing_count++;
                // ī��Ʈ�� 1 ����
            }
            yield return new WaitForSeconds(delay);
            // ������ �����̸�ŭ ���
        }
        yield return null;
    }
}
