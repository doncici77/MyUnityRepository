using UnityEngine;

public class MovePlat : MonoBehaviour
{
    // Circle�� ������ ��ġ�� Lerp ��Ű�� ��ũ��Ʈ
    public GameObject plat;
    Vector3 pos = new Vector3(4, -0.2f, 0);


    void Update()
    {
        plat.transform.position = Vector3.MoveTowards(plat.transform.position, pos, Time.deltaTime);
    }
}
