using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Vector3 target;
    public float speed = 1f;
    System.Random random = new System.Random();
    SpriteRenderer spriteRenderer;

    void Start()
    {
        target = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            int leftORright = random.Next(0, 2);
            int randDistance = random.Next(1, 5);
            Debug.Log("leftORright" + leftORright);
            Debug.Log("randDistance" + randDistance);

            if (leftORright == 0)
            {
                if ((target.x += randDistance) < CameraManager.right_limit)
                {
                    target.x += randDistance;
                    spriteRenderer.flipX = true;
                }
            }
            else if (leftORright == 1)
            {
                if ((target.x -= randDistance) < CameraManager.left_limit)
                {
                    target.x -= randDistance;
                    spriteRenderer.flipX = false;
                }
                target.x -= randDistance;
                spriteRenderer.flipX = false;
            }
        }
    }
}
