using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    Animator animator;
    public float monster_speed;
    public float rate = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(Vector3.zero);
        // 영점 기준으로 시선 병경

        // 간격 설정
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);

        if(target_distance <= rate)
        {
            SetMotionChange("isMOVE", false); // 에니메이터 설정
        }
        else // 일반적인 경우에는 움직임을 진행한다.
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monster_speed);
            // 영점으로, 몬스터의 속도만큼 앞으로 이동합니다.
            SetMotionChange("isMOVE", true); // 에니메이터 설정
        }
    }

    private void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);
    }
}
