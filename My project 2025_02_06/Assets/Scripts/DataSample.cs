using UnityEngine;

public class DataSample : MonoBehaviour
{
    // 1. ����Ƽ �������� ����
    // ������ ���� �������� ���� �ٽ��� �Ǵ� �κ�(������)

    // �Ϲ����� �۾� ��, �÷��� �ϴ� ��쿡�� ���� ���� �����ǰ�
    // �ٽ� �÷����ϸ� ������ ��ϵ��� ���ŵ�.

    // ���� ���ο� ���� �÷����Ҷ� ������ ������ ������ �����ϴ� ���ӵ� ����

    // PlayerPrefs�� �ַ� �÷��̾ ���� ȯ�� ������ �����Ҷ� ���Ǵ� Ŭ����
    // �ش� Ŭ������ ���忭, �Ǽ�, ������ ������� �÷��� ������Ʈ���� ������ �� ����.

    // PlayerPrefs��  Key�� Value�� �����Ǿ� �ִ� ������(c#�� Dictionary)


    // Key�� Value�� �����ϱ� ���� ������(���� �������� ��ġ)
    // Value�� Key�� ���� ������ �� �ִ� �������� ��

    // ex) userID : current147���� ����Ǿ��ִٸ�, userID��� Key, current147�̶�� Value�� ������ �� ����.

    public UserData userData;
    // 1. ����Ƽ �����Ϳ��� ���� usearData�� ���� ���� �ۼ�.
    // 2. ������Ʈ���� �ִ� Ű ���� �˻�
    // 3. Ű ��ü ����

    private void Start()
    {
        /*PlayerPrefs.SetString("ID", userData.UserID);
        PlayerPrefs.SetString("UserName", userData.UserName);
        PlayerPrefs.SetString("Password", userData.UserPassword);
        PlayerPrefs.SetString("E-mail", userData.UserEmail);*/

        // Debug.Log("�����Ͱ� ����Ǿ����ϴ�.");

        //Debug.Log(PlayerPrefs.GetString("ID"));

        //PlayerPrefs.DeleteAll(); // ��ü ����
        //Debug.Log("�����͸� ���� �����߽��ϴ�.");
    }
}
