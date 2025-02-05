using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject playerBody; // PlayerBody 게임 오브젝트를 저장할 변수

    void Start()
    {
        playerBody = GameObject.Find("PlayerBody"); // PlayerBody 게임 오브젝트를 찾아서 할당
    }

    private void Update()
    {
        // Enemy의 위치를 PlayerBody의 위치로 이동
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerBody.transform.position.x, transform.position.y, playerBody.transform.position.z), Time.deltaTime* 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBody") // 충돌한 오브젝트의 이름이 "PlayerBody"일 때
        {
            Destroy(gameObject); // Enemy 오브젝트를 삭제
        }
    }

    private void OnCollisionEnter(Collision collision) // 충돌시   
    {
        if (collision.gameObject.tag == "Bullet") // 충돌한 오브젝트의 이름이 "PlayerBody"일 때
        {
            Destroy(gameObject); // Enemy 오브젝트를 삭제
        }
    }
}
