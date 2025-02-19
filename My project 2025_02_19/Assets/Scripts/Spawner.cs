using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 몬스터(monster_prefab)는 맵에 특정 마리수(monster_count)를 몇 초(monster_spawn_time)마다
    // 반복(코루틴)해서 소환합니다.

    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 5.0f; // 해당 수치를 수정할 경우 생성되는 영역(구)의 위치 값이 점점 넓어집니다.
    public float re_rate = 2.0f; // 생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.

    public static List<Monster> monster_list = new List<Monster>(); // 생성된 몬스터 들
    public static List<Player> player_list = new List<Player>(); // 생성된 캐릭터 들

    private void Start()
    {
        StartCoroutine("SpawnMonsterPooling");
    }

    // 일반적인 생성 방법
    IEnumerator SpawnMonster()
    {
        Vector3 pos;// 생성 좌표

        for(int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate; 
            // insideUnitSphere 반지름 1의 구모양의 값을 반환
            pos.y = 0.0f; // 생성된 유닛이 맵에 재대로 존재하기 위해 설정

            // 너무 근접한 범위에서 생성됬을 경우 재할당
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

    // 오브젝트 풀링 기법으로 만드는 방법
    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos;// 생성 좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            // insideUnitSphere 반지름 1의 구모양의 값을 반환
            pos.y = 0.0f; // 생성된 유닛이 맵에 재대로 존재하기 위해 설정

            // 너무 근접한 범위에서 생성됬을 경우 재할당
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            // var go = Manager.POOL.PoolObject("Monster").GetGameObject();
            // 전달할 함수가 없는 경우 (일반생성)

            // 액션을 통해 기능 처리
            var go = Manager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
                // result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                monster_list.Add(result.GetComponent<Monster>());
                // 생성한 유닛을 몬스터 리스트에 추가

            }); // 전달할 함수가 있는 경우(Action<GameObject>)

            // StartCoroutine(ReturnMonsterPooling(go));
            // 풀링한 값에 대한 반납
        }

        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonsterPooling");
    }

    // 몬스터 풀링한 값에 대한 리턴 코드
    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(1.0f);
        Manager.POOL.pool_dict["Monster"].ObjectReturn(ob);
    }
}
