using System.Collections;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public GameObject plat; // 플렛폼 오브젝트
    Vector3 pos = new Vector3(4, -0.2f, 0); // 이동 목표 좌표
    bool move = false; // 움직임 여부

    private void Update()
    {
        if (move == true)
        {
            // 일정한 속도로 발판이동
            plat.transform.position = Vector3.MoveTowards(plat.transform.position, pos, Time.deltaTime);

            if(plat.transform.position == pos) // 목표 지점 도착하면
            {
                StartCoroutine("RespawnPlat"); // 발판 리스폰 실행
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // 플레이어가 올라타면
        {
            move = true; // 움직임이 가능하게 바꿈
            Debug.Log("플렛폼 이동");
        }
    }

    IEnumerator RespawnPlat()
    {
        move = false; // 발판 리스폰하면 움직이지 못하게함
        yield return new WaitForSeconds(2);
        plat.transform.position = new Vector3(-4, -0.2f, 0);
    }
}
