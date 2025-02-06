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
        nameInputField.onEndEdit.AddListener(ValueChanged); // �����۸� �Է� ��������
        // �� �ʵ带 public���� ����Ұ�� ��Ŭ��Ʈ�� �ν����Ϳ��� �����ؾ��� �۵��� �ȵǴ� ��쵵 �ִ�.
        // �� ������� ����� ����� ����Ƽ �ν����Ϳ��� ������ �ʽ��ϴ�.

        itemDescriptionInuputField.onEndEdit.AddListener(ValueChangedDescription); // ������ ���� �Է� �������� �Է��ѳ��� ����

        loadButton.interactable = interactable;
        // ��ư�� interactable�� ����ڿ��� ��ȣ�ۿ� ���θ� ������ �� ����ϴ� ���Դϴ�.
    }

    private void Update()
    {
        LoadCheck();
    }

    // 1. public���� ���� �Լ��� ����Ƽ �ν����Ϳ��� ���� �����ϰڽ��ϴ�.
    // 2. public�� �ƴ� �Լ��� ��ũ��Ʈ �ڵ带 ���� ����� �����ϰڽ��ϴ�.

    public void Sample()
    {
        Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
    }

    /// <summary>
    /// ���� ��ư �������� Ű�� ����
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
            Debug.Log("������ �Է����ּ���");
        }
    }
    
    /// <summary>
    /// �ε��ư Ȱ��ȭ ����
    /// </summary>
    void LoadCheck()
    {
        if (PlayerPrefs.HasKey("ItemName") && PlayerPrefs.HasKey("ItemDescription")) // ������ Ű�� �����Ҷ�
        {
            loadButton.interactable = true;
        }
        else
        {
            loadButton.interactable = false;
        }
    }

    

    /// <summary>
    /// ������ ����
    /// </summary>
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("ItemName");
        PlayerPrefs.DeleteKey("ItemDescription");
    }

    /// <summary>
    /// �۾��� ������ �Ǿ��� �� �ش� ������ �Է������� �˷��ִ� �Լ�
    /// </summary>
    /// <param name="text">����</param>
     void ValueChanged(string text)
    {
        Debug.Log($"{text} �Է��߽��ϴ�");
        itemName = text;
    }

     void ValueChangedDescription(string text)
    {
        Debug.Log($"{text} �Է��߽��ϴ�");
        itemDesciption = text;
    }
}
