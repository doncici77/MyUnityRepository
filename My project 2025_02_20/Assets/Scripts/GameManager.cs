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
        // 1초 뒤에 해당함수를 호출 함니다.
        Invoke("InactiveImage", 1.0f);
        //패널 비활성화
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
            // 이미지 활성화
            main_image.SetActive(true);
            // 패널 활성화
            panel.SetActive(true);
            // 다시 시작 버튼에 대한 비활성화(게임 클리어 했으니까)
            restartButton.GetComponent<Button>().interactable = false;
            // 메인 이미지를 게임 클리어 이미지로 변경
            main_image.GetComponent<Image>().sprite = game_clear_sprite;
            // 플레이어 컨트롤러 상태를 end로 변경
            PlayerController.state = "end";
        }
        else if(PlayerController.state == "gameover")
        {
            // 이미지 활성화
            main_image.SetActive(true);
            // 패널 활성화
            panel.SetActive(true);
            // 다음 버튼에 대한 비활성화(게임을 클리어하지 못했으니까)
            nextButton.GetComponent<Button>().interactable = false;
            // 메인 이미지를 게임 오버 이미지로 변경
            main_image.GetComponent<Image>().sprite = game_over_sprite;
            // 플레이어 컨트롤러 상태를 end로 변경
            PlayerController.state = "end";
        }
        else if(PlayerController.state == "playing")
        {
            // 게임 진행 시에 대한 추가 처리를 구현하는 자리
        }
    }
}
