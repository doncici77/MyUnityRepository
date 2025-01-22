using System;
using UnityEngine;
//�÷��̾��� �̵�(������ٵ�)

//�ش����� ���� �� ��ũ��Ʈ�� ������Ʈ�Խ� ����� ���
//������� ������Ʈ�� �䱸�ϰ� �˴ϴ�.
//1. �ش� ������Ʈ�� ���� ������Ʈ�� ������ ��� ���� �ڵ����� ������ ���� ���ݴϴ�.
//2. �� ��ũ��Ʈ�� ����� ���¶�� �� ������Ʈ�� ����� ������Ʈ�� ������ �� �����ϴ�.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; //�Ҽ����� ���� ���� �������� f ��ȣ�� ����մϴ�.
    //�Ҽ��� �� 6�ڸ����� ��Ȯ�ϰ� ���

    public double jump_force = 3.5; //double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �̰�쿡�� f�� ������ �ʽ��ϴ�.
    //�Ҽ��� �� 15�ڸ� ���� ��Ȯ�ϰ� ���

    public bool isJump = false;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //�ش� ������Ʈ�� ���� ������ ���
        //T �κп��� ������Ʈ�� ���¸� �ۼ����ݴϴ�.
        //������Ʈ�� ���°� �ٸ��ٸ� ���� �߻�
        //�ش絥���Ͱ� �������� ���� ����� null(�� ����)�� ��ȯ�ϰ� �˴ϴ�.

    }

    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw("Ű �̸�"); �� ��ǲ �Ŵ����� Ű�� �����鼭 Ŭ���� ���� -1, 0 ,1�� ��ġ�� ���� ���ɴϴ�.

        //Horizontal : �����̵� a, d Ű�� Ű������ ����, ������Ű
        //Vertical : �����̵� w, s Ű�� Ű������ ����, �Ʒ���Ű

        //���� �ڵ带 ���� ������ ������ ����մϴ�.
        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        //�ӷ� = ���� * �ӵ�;

        transform.position += velocity; //���� ��ġ += ����Ǵ� ������
    }
    private void Jump()
    {
        //����ڰ� Ű���� SpaceŰ�� �Է��Ѵٸ�
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if(!isJump) //���� ���°� �ƴ� ���
            {
                isJump = true; //���� ���·� ����
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
                //type casting(Ÿ�� ĳ����)
                //(Ÿ�� �̸�) ������ ���� �ش� ������ ������ Ÿ������ ���氡��
                //�� ĳ������ ������ ���������� ���� �� �� ����
                
                //�ַ� int -> float ���� ���� ����
                //������ Ÿ���� ���� ȣȯ���� �ʴ� ����� ��� �Ұ�

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("����!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����Ƽ���� ũ�⸦ ���ϴ� ������
        //a == b : a�� b�� ũ�Ⱑ ����.(���� ����)
        //a != b : a�� b�� ũ�Ⱑ �ٸ���.(���� �ٸ���)
        //a > b, a < b, a >= b, a <= b
        
        //�浹ü�� ���� ������Ʈ�� ���̾ 7�� �������� ũ�Ⱑ ���ٸ�
        if(collision.gameObject.layer == 7)
        {
            isJump = false;
        }
        Debug.Log("���� ��ҽ��ϴ�!");
    }

}
