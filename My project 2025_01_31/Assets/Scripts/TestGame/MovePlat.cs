using System.Collections;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public GameObject plat; // �÷��� ������Ʈ
    Vector3 pos = new Vector3(4, -0.2f, 0); // �̵� ��ǥ ��ǥ
    bool move = false; // ������ ����

    private void Update()
    {
        if (move == true)
        {
            // ������ �ӵ��� �����̵�
            plat.transform.position = Vector3.MoveTowards(plat.transform.position, pos, Time.deltaTime);

            if(plat.transform.position == pos) // ��ǥ ���� �����ϸ�
            {
                StartCoroutine("RespawnPlat"); // ���� ������ ����
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // �÷��̾ �ö�Ÿ��
        {
            move = true; // �������� �����ϰ� �ٲ�
            Debug.Log("�÷��� �̵�");
        }
    }

    IEnumerator RespawnPlat()
    {
        move = false; // ���� �������ϸ� �������� ���ϰ���
        yield return new WaitForSeconds(2);
        plat.transform.position = new Vector3(-4, -0.2f, 0);
    }
}
