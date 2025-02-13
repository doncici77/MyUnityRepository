using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed; // �̵��ӵ�
    public TalkManager manager;
    bool stateTalk = false; // ��ȭ ���� ����
    bool canMove = true; // ��ȭ�Ҷ� ������ ����

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
