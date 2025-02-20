using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject main_image;
    public Sprite game_over_sprite;
    public Sprite game_clear_sprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image image;

    void Start()
    {
        // 1�� �ڿ� �ش��Լ��� ȣ�� �Դϴ�.
        Invoke("InactiveImage", 1.0f);
        //�г� ��Ȱ��ȭ
        panel.SetActive(false);
    }

    void InactiveImage()
    {
        main_image.SetActive(false);
    }

    void Update()
    {
        if(PlayerController.state == "gameclear")
        {
            // �̹��� Ȱ��ȭ
            main_image.SetActive(true);
            // �г� Ȱ��ȭ
            panel.SetActive(true);
            // �ٽ� ���� ��ư�� ���� ��Ȱ��ȭ(���� Ŭ���� �����ϱ�)
            restartButton.GetComponent<Button>().interactable = false;
            // ���� �̹����� ���� Ŭ���� �̹����� ����
            main_image.GetComponent<Image>().sprite = game_clear_sprite;
            // �÷��̾� ��Ʈ�ѷ� ���¸� end�� ����
            PlayerController.state = "end";
        }
        else if(PlayerController.state == "gameover")
        {
            // �̹��� Ȱ��ȭ
            main_image.SetActive(true);
            // �г� Ȱ��ȭ
            panel.SetActive(true);
            // ���� ��ư�� ���� ��Ȱ��ȭ(������ Ŭ�������� �������ϱ�)
            nextButton.GetComponent<Button>().interactable = false;
            // ���� �̹����� ���� ���� �̹����� ����
            main_image.GetComponent<Image>().sprite = game_over_sprite;
            // �÷��̾� ��Ʈ�ѷ� ���¸� end�� ����
            PlayerController.state = "end";
        }
        else if(PlayerController.state == "playing")
        {
            // ���� ���� �ÿ� ���� �߰� ó���� �����ϴ� �ڸ�
        }
    }
}
