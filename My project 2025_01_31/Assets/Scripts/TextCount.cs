using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour
{
    // �ؽ�Ʈ�� ī��Ʈ�� ����ϴ� ����� ����
    // ī��Ʈ�� ��� 1�� �����ϴ� ���·� ó��
    public Text countText;
    private int count;


    void Start()
    {
        // �ڷ�ƾ ��� ���
        // StartCoroutine("�Լ��� �̸�(IEnumerator ������ �Լ�)");
        // 1. ���ڿ��� ���� �Լ��� ã�Ƽ� �����ϴ� ���
        // StopCoroutine()�� ���� �ܺο��� �����ϴ� ���� ����

        // StartCoroutine(�Լ��� �̸�());
        // 2. �ش� �Լ��� ȣ���� ���� ����� ��ȯ�޴� ����
        // >> ��Ÿ �߻� �� ���� üũ ����
        // �� ������δ� StopCoroutine()�� ���� �ܺο����� ���� ����� ��� �� �� ����.

        StartCoroutine("CountPlus");
        // �ش� �ڷ�ƾ ���� ���� ����
        // StopCoroutine("CountPlus");

        // StartCoroutine(CountPlus());
        // �Լ� ���� ���� ���
    }

    IEnumerator CountPlus()
    {
        while(true)
        {
            count++;
            countText.text = count.ToString("N0");
            // C#�� ToString()�� ���� ���� ���·� ������ ����
            // N0�� ���� 3�ڸ� �������� ,�� ǥ���ϴ� format�Դϴ�. 1000 -> 1,000
            yield return new WaitForSeconds(1);
            // ���� �������� �Ѿ�ϴ�
        }        

        /*Debug.Log("�ƾ� ����ũ �׽�Ʈ");
        yield return new WaitForSeconds(1);
        // yield�� �Ͻ������� cpu�� ������ �ٸ� �Լ��� �����ϴ� Ű����
        Debug.Log("�丸 �԰� �ð�");
        yield return new WaitForSeconds(5);
        Debug.Log("�ٽ� ���� �غ���?");*/
    }
}
