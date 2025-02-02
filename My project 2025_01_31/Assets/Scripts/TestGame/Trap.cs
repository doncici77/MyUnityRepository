using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Trap : MonoBehaviour
{
    public GameObject trap; // 트랩 오브젝트
    Vector3 posDown; // 아래이동 좌표
    Vector3 posUp;  // 위이동 좌표
    bool moveDown = true; // 위아래 방향 설정

    void Start()
    {
        posDown = new Vector3(trap.transform.position.x, -3.5f, 0); // 트랩 아래로 이동할 좌표
        posUp = new Vector3(trap.transform.position.x, 3.5f, 0); // 트랩 위로 이동할 좌표
    }

    void Update()
    {
        if (moveDown)
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, posDown, Time.deltaTime); // 트랩 아래이동

            if (trap.transform.position.y < -3.3f)
            {
                moveDown = false;
            }

        }
        else
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, posUp, Time.deltaTime); // 트랩 위이동

            if (trap.transform.position.y > 3.3f)
            {
                moveDown = true;
            }
        }      
    }
}
