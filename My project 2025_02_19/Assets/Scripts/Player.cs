using UnityEngine;

public class Player : Character
{
    Vector3 start_pos;
    Quaternion rotation;

    protected override void Start()
    {
        // ĳ���� Ŭ������ Start ����
        base.Start();

        // # ���� �� ����
        start_pos = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {
        if(target == null) // Ÿ���� ������
        {
            // ����� Ÿ�� ����
            TargetSearch(Spawner.monster_list.ToArray());
            // ����Ʈ��.ToArray()�� ���� list -> array

            float pos = Vector3.Distance(transform.position, start_pos);
            if(pos > 0.1f) // ���� �������� ���ư�
            {
                transform.position = Vector3.MoveTowards(transform.position, start_pos, Time.deltaTime * 2.0f);
                transform.LookAt(start_pos);
                SetMotionChange("isMOVE", true);
            }
            else
            {
                transform.rotation = rotation;
                SetMotionChange("isMOVE", false);
            }
            return; // �۾� ����
        }

        float distance = Vector3.Distance (transform.position, target.position);

        // Ÿ�� �������� �����鼭 ���� �������� ���� ���
        if(distance <= target_range && distance > attak_range)
        {
            SetMotionChange("isATTACK" , false);
            // Ÿ�� �������� �̵�
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        // ���� ���� �ȿ� ���� ���
        else if(distance <= attak_range)
        {
            transform.LookAt(target);
            //���� �ڼ��� �Ѿ�ϴ�.
            SetMotionChange("isATTACK", true);
        }
    }
}
