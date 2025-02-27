using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ���� �ð� 
    float currentTime;

    // ���� �ð� 
    public float createTime = 1.0f;

    // ������ �� 
    public GameObject enemyFactory;

    float min = 1;
    float max = 5;


    // ������Ʈ Ǯ ����
    public int poolSize = 10;
    GameObject[] enemyObjectPool;

    // ���� ��ġ(�迭)
    public Transform[] spawnPoints;

    private void Start()
    {
        createTime = Random.Range(min, max);

        enemyObjectPool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            var enemy =Instantiate(enemyFactory);
            enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        // 1. �ð��� �帥�� 
        currentTime += Time.deltaTime;

        // 2. ���� �ð��� ���� �ð��� �����Ѵٸ� 
        //    ���� �����Ѵ�. 
        if(currentTime >= createTime)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var enemy = enemyObjectPool[i];

                if(enemy.activeSelf == false)
                {
                    // ���� ����
                    int index = Random.Range(0, spawnPoints.Length);

                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }
            }

            // 3. �ð��� 0���� ���� �Ѵ�. 
            currentTime = 0;
            createTime = Random.Range(min, max);
        }
    }
}
