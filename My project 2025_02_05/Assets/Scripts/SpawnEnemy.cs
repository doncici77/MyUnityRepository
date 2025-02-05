using System;
using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy ���� ������Ʈ�� ������ ����
    public GameObject[] enemySpawnyPoint; // ���� ������ ��ġ

    void Start()
    {
        StartCoroutine("SpawnEnenmy"); // SpawnEnemy �ڷ�ƾ ����
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
