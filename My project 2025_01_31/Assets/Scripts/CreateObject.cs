using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Instantiate(prefab);
        // ���� ��� Instantiate()
        // ����س��� ������ �״�� ������.

        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);// (� ����, � ��ġ, � ȸ����)
        // ����س��� �����հ� ��ġ�� ȸ�� ������ �� ������ ������ ����.
        // Quaternion.identity = ȸ�� �� 0

        // Vector3: ����� ũ�⸦ �����ϴ� ����
        // ĳ������ position, ������Ʈ�� �̵��ӵ�, ���������� �Ÿ� ���� ����� �� ����ϴ� Ŭ����
        // 2D Vector2 (x, y)
        // 3D Vector3 (x, y, z)

        // Quaternion: ���� ������Ʈ�� 3���� ������ ����, �� ���⿡�� �ٸ� ���������� ������� ȸ�� ��
        // ����� ȸ���� �� ǥ���� �� �ִ� Ŭ����
        // 180�� ���� ū ���� ���� ǥ���� �Ҽ� ����.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
