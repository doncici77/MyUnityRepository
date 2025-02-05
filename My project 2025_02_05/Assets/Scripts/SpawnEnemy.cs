using System;
using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy 게임 오브젝트를 저장할 변수
    public GameObject[] enemySpawnyPoint; // 적이 생성될 위치

    void Start()
    {
        StartCoroutine("SpawnEnenmy"); // SpawnEnemy 코루틴 시작
    }

    IEnumerator SpawnEnenmy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int rand = UnityEngine.Random.Range(0, enemySpawnyPoint.Length);
            Instantiate(enemyPrefab, enemySpawnyPoint[rand].transform.position, Quaternion.identity);
        }
    }
}
