using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public TextFade textFade; // �ܺ� ��ũ��Ʈ ȣ��
    public GameObject player; // �÷��̾� ������Ʈ
    private float speed = 5f; // �������� �ӵ�
    private float jump_force = 5f; // ���� ����
    private bool isJump = false; // ���� ���� ����
    private Rigidbody2D rigid; // ������ �ٵ��� ������Ʈ�� ���

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
        float x = Input.GetAxisRaw("Horizontal"); // �¿� �Է� �ޱ�
        Vector3 velocity = new Vector3(x, 0, 0) * speed * Time.deltaTime; // �¿� �̵� �Ÿ� ���
        transform.position += velocity; // �¿� �̵� ����
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boom")
        {
            player.transform.position = new Vector3(-8, 0.7f, 0); // �÷��̾� ��ġ �̵�(������)
        }

        if (collision.gameObject.tag == "Finish")
        {
            textFade.EndGame(); // �ܺ� ��ũ��Ʈ�� �ִ� ���� �ؽ�Ʈ ���̵��� �Լ� ȣ��
        }
    }
}
