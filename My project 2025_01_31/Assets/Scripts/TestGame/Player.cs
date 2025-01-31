using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5f; //�Ҽ����� ���� ���� �������� f ��ȣ�� ����մϴ�.
    //�Ҽ��� �� 6�ڸ����� ��Ȯ�ϰ� ���

    public double jump_force = 5f; //double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �̰�쿡�� f�� ������ �ʽ��ϴ�.
    //�Ҽ��� �� 15�ڸ� ���� ��Ȯ�ϰ� ���

    public bool isJump = false;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(x, 0, 0) * speed * Time.deltaTime;
        //�ӷ� = ���� * �ӵ�;

        transform.position += velocity; //���� ��ġ += ����Ǵ� ������
    }
    private void Jump()
    {
        //����ڰ� Ű���� SpaceŰ�� �Է��Ѵٸ�
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!isJump) //���� ���°� �ƴ� ���
            {
                isJump = true; //���� ���·� ����
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
            Debug.Log("���� ��ҽ��ϴ�!");
        }
    }
}
