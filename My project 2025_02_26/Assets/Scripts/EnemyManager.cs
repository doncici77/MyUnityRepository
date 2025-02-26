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

    private void Start()
    {
        createTime = Random.Range(min, max);
    }

    private void Update()
    {
        // 1. �ð��� �帥�� 
        currentTime += Time.deltaTime;

        // 2. ���� �ð��� ���� �ð��� �����Ѵٸ� 
        //    ���� �����Ѵ�. 
        if(currentTime >= createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            // 3. �ð��� 0���� ���� �Ѵ�. 
            currentTime = 0;
            createTime = Random.Range(min, max);
        }
    }
}
