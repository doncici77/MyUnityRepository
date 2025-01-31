using UnityEngine;

public class MovePlat : MonoBehaviour
{
    // Circle을 지정된 위치로 Lerp 시키는 스크립트
    public GameObject plat;
    Vector3 pos = new Vector3(4, -0.2f, 0);


    void Update()
    {
        plat.transform.position = Vector3.MoveTowards(plat.transform.position, pos, Time.deltaTime);
    }
}
