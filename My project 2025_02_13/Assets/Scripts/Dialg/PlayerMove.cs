using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed; // 이동속도
    public TalkManager manager;
    bool stateTalk = false; // 대화 가능 상태
    bool canMove = true; // 대화할때 움직임 통제

    void Update()
    {
        if(canMove == true)
        {
            Move();
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TalkAbout();
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(x, 0, z) * speed * Time.deltaTime;


        transform.position += velocity; 
    }

    void TalkAbout()
    {
        if (stateTalk == true)
        {
            manager.Talk();
            canMove = false;

            if(manager.stringQueue.Count <= 0)
            {
                canMove = true;
            }
        }
        else if (stateTalk == false)
        {
            manager.NoTalk();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zone")
        {
            stateTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Zone")
        {
            stateTalk = false;
        }
    }
}
