using UnityEngine;

// using System�� ����ϸ鼭 ����Ƽ�� ������ ����ϰ� ���� ���
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // ������ ��� ���̺�
    public DropTable DropTable;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Dead();
        }
    }

    private void Dead()
    {
        GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0, DropTable.drop_table.Count)];
        // Random.Range(�ּ�, �ִ�)�� ����Ƽ���� �������ִ� ���� ����
        // �ּ� ������ �ִ� -1������ ������ �� �� �ϳ��� �������� �����Ѵ�.

        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
