using UnityEngine;

public class Player : Character
{
    Vector3 start_pos;
    Quaternion rotation;

    protected override void Start()
    {
        // 캐릭터 클래스의 Start 시작
        base.Start();

        // # 시작 값 설정
        start_pos = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {
        if(target == null) // 타겟이 없을때
        {
            // 가까운 타겟 조사
            TargetSearch(Spawner.monster_list.ToArray());
            // 리스트명.ToArray()를 통해 list -> array

            float pos = Vector3.Distance(transform.position, start_pos);
            if(pos > 0.1f) // 시작 지점으로 돌아감
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
            return; // 작업 종료
        }

        float distance = Vector3.Distance (transform.position, target.position);

        // 타겟 범위보다 작으면서 공격 범위보다 높은 경우
        if(distance <= target_range && distance > attak_range)
        {
            SetMotionChange("isATTACK" , false);
            // 타겟 지점으로 이동
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        // 공격 범위 안에 들어온 경우
        else if(distance <= attak_range)
        {
            transform.LookAt(target);
            //공격 자세로 넘어갑니다.
            SetMotionChange("isATTACK", true);
        }
    }
}
