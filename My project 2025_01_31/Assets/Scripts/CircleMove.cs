using UnityEngine;

public class CircleMove : MonoBehaviour
{
    // Circle�� ������ ��ġ�� Lerp ��Ű�� ��ũ��Ʈ
    public GameObject Circle;
    Vector3 pos = new Vector3(5, -3, 0);


    void Update()
    {
        // Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos, Time.deltaTime);
        // 0�� �Է��� ��� �������� ����.
        // 1�� �ִ�ġ�̴�.

        // ������ �ӵ��� ��ǥ �������� �̵��ϰ� ����� ��ũ��Ʈ
        // Vector3.MoveTowrds(���� ����, �� ����, �̵� �ӵ�);
        // Circle.transform.position = Vector3.MoveTowards(Circle.transform.position, pos, Time.deltaTime);

        Circle.transform.position = Vector3.Slerp(Circle.transform.position, pos, Time.deltaTime);


    }
}
