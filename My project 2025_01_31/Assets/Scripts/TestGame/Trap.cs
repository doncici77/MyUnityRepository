using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Trap : MonoBehaviour
{
    public GameObject trap;

    void Start()
    {

        StartCoroutine("CountPlus");

    }

    IEnumerator CountPlus()
    {
        Vector3 posDown = new Vector3(-2.5f, -3.5f, 0);
        Vector3 posUp = new Vector3(trap.transform.position.x, 3.5f, 0);
        while (true)
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, posDown, Time.deltaTime * 10);
            yield return new WaitForSeconds(5); // ���� �ڵ�(����)�� ������ �ִ°���
            // ���� �������� �Ѿ�ϴ�
            trap.transform.position = Vector3.Lerp(trap.transform.position, posUp, Time.deltaTime * 10);
            yield return new WaitForSeconds(5);
        }

    }

}
