using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Trap : MonoBehaviour
{
    public GameObject trap; // Ʈ�� ������Ʈ
    Vector3 posDown; // �Ʒ��̵� ��ǥ
    Vector3 posUp;  // ���̵� ��ǥ
    bool moveDown = true; // ���Ʒ� ���� ����

    void Start()
    {
        posDown = new Vector3(trap.transform.position.x, -3.5f, 0); // Ʈ�� �Ʒ��� �̵��� ��ǥ
        posUp = new Vector3(trap.transform.position.x, 3.5f, 0); // Ʈ�� ���� �̵��� ��ǥ
    }

    void Update()
    {
        if (moveDown)
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, posDown, Time.deltaTime); // Ʈ�� �Ʒ��̵�

            if (trap.transform.position.y < -3.3f)
            {
                moveDown = false;
            }

        }
        else
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, posUp, Time.deltaTime); // Ʈ�� ���̵�

            if (trap.transform.position.y > 3.3f)
            {
                moveDown = true;
            }
        }      
    }
}
