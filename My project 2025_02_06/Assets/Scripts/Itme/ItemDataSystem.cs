using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField itemDescriptionInuputField;
    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;
    public bool interactable;
    static string itemDesciption;
    static string itemName;

    void Start()
    {
        nameInputField.onEndEdit.AddListener(ValueChanged); // 아이템명 입력 끝냈을때
        // 이 필드를 public으로 등록할경우 스클립트를 인스펙터에서 수정해야해 작동이 안되는 경우도 있다.
        // 이 방식으로 등록한 기능은 유니티 인스펙터에서 보이지 않습니다.

        itemDescriptionInuputField.onEndEdit.AddListener(ValueChangedDescription); // 아이템 설명 입력 끝냈을때 입력한내용 저장

        loadButton.interactable = interactable;
        // 버튼의 interactable은 사용자와의 상호작용 여부를 제어할 때 사용하는 값입니다.
    }

    private void Update()
    {
        LoadCheck();
    }

    // 1. public으로 만든 함수는 유니티 인스펙터에서 직접 연결하겠습니다.
    // 2. public이 아닌 함수는 스크립트 코드를 통해 기능을 연결하겠습니다.

    public void Sample()
    {
        Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
    }

    /// <summary>
    /// 저장 버튼 눌렀을때 키값 저장
    /// </summary>
    public void SaveData()
    {
        if(itemDesciption != "" && itemName != "")
        {
            PlayerPrefs.SetString("ItemName", itemName);
            PlayerPrefs.SetString("ItemDescription", itemDesciption);
        }
        else
        {
            Debug.Log("내용을 입력해주세요");
        }
    }
    
    /// <summary>
    /// 로드버튼 활성화 여부
    /// </summary>
    void LoadCheck()
    {
        if (PlayerPrefs.HasKey("ItemName") && PlayerPrefs.HasKey("ItemDescription")) // 아이템 키가 존재할때
        {
            loadButton.interactable = true;
        }
        else
        {
            loadButton.interactable = false;
        }
    }

    

    /// <summary>
    /// 데이터 삭제
    /// </summary>
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("ItemName");
        PlayerPrefs.DeleteKey("ItemDescription");
    }

    /// <summary>
    /// 작업이 마무리 되었을 때 해당 문구를 입력했음을 알려주는 함수
    /// </summary>
    /// <param name="text">문구</param>
     void ValueChanged(string text)
    {
        Debug.Log($"{text} 입력했습니다");
        itemName = text;
    }

     void ValueChangedDescription(string text)
    {
        Debug.Log($"{text} 입력했습니다");
        itemDesciption = text;
    }
}
