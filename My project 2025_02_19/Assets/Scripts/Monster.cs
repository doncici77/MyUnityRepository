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
        // ���� �������� �ü� ����

        // ���� ����
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);

        if(target_distance <= rate)
        {
            SetMotionChange("isMOVE", false); // ���ϸ����� ����
        }
        else // �Ϲ����� ��쿡�� �������� �����Ѵ�.
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monster_speed);
            // ��������, ������ �ӵ���ŭ ������ �̵��մϴ�.
            SetMotionChange("isMOVE", true); // ���ϸ����� ����
        }
    }

    private void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);
    }
}
