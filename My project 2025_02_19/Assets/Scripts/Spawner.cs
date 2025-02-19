using System.Collections;
using System.Collections.Generic;
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

    public static List<Monster> monster_list = new List<Monster>(); // ������ ���� ��
    public static List<Player> player_list = new List<Player>(); // ������ ĳ���� ��

    private void Start()
    {
        StartCoroutine("SpawnMonsterPooling");
    }

    // �Ϲ����� ���� ���
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

    // ������Ʈ Ǯ�� ������� ����� ���
    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos;// ���� ��ǥ

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            // insideUnitSphere ������ 1�� ������� ���� ��ȯ
            pos.y = 0.0f; // ������ ������ �ʿ� ���� �����ϱ� ���� ����

            // �ʹ� ������ �������� �������� ��� ���Ҵ�
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            // var go = Manager.POOL.PoolObject("Monster").GetGameObject();
            // ������ �Լ��� ���� ��� (�Ϲݻ���)

            // �׼��� ���� ��� ó��
            var go = Manager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
                // result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                monster_list.Add(result.GetComponent<Monster>());
                // ������ ������ ���� ����Ʈ�� �߰�

            }); // ������ �Լ��� �ִ� ���(Action<GameObject>)

            // StartCoroutine(ReturnMonsterPooling(go));
            // Ǯ���� ���� ���� �ݳ�
        }

        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonsterPooling");
    }

    // ���� Ǯ���� ���� ���� ���� �ڵ�
    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(1.0f);
        Manager.POOL.pool_dict["Monster"].ObjectReturn(ob);
    }
}
