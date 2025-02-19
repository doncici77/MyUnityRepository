using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ����(monster_prefab)�� �ʿ� Ư�� ������(monster_count)�� �� ��(monster_spawn_time)����
    // �ݺ�(�ڷ�ƾ)�ؼ� ��ȯ�մϴ�.

    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 5.0f; // �ش� ��ġ�� ������ ��� �����Ǵ� ����(��)�� ��ġ ���� ���� �о����ϴ�.
    public float re_rate = 2.0f; // ���� ��ġ�� �������� �����Ǵ� ����(��)�� ������ �� �ֽ��ϴ�.

    private void Start()
    {
        StartCoroutine("SpawnMonster");
    }

    IEnumerator SpawnMonster()
    {
        Vector3 pos;// ���� ��ǥ

        for(int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate; 
            // insideUnitSphere ������ 1�� ������� ���� ��ȯ
            pos.y = 0.0f; // ������ ������ �ʿ� ���� �����ϱ� ���� ����

            // �ʹ� ������ �������� �������� ��� ���Ҵ�
            while(Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonster");
    }
}
