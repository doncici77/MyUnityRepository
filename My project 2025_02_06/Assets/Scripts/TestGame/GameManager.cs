using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBox
{
    public int box_Level;
    public int upgradePercent;
    public Color boxColor;
}


public class GameManager : MonoBehaviour
{
    public TMP_Text box_Level_Text;
    public TMP_Text upgradePercent_Text;
    public Image boxColor_Image;
    int box_Level_Data;
    int upgradePercent_Data;
    Color boxColor_Data;
    UpgradeBox upgradeBoxJson;

    // 10가지 색상 배열 (빨, 주, 노, 초, 파, 남, 보 + 추가 색상)
    Color[] colors = 
    {
        Color.red,        // 빨강
        new Color(1f, 0.5f, 0f), // 주황
        Color.yellow,     // 노랑
        Color.green,      // 초록
        Color.cyan,       // 하늘색 
        Color.blue,       // 파랑
        new Color(0.5f, 0f, 0.5f), // 남색 
        Color.magenta,    // 보라
        Color.white,      // 흰색 
        Color.gray        // 회색 
    };

    void Start()
    {
        string load_Json = File.ReadAllText(Application.dataPath + "/UpgradeBox.json");
        upgradeBoxJson = JsonUtility.FromJson<UpgradeBox>(load_Json);
        Debug.Log("파일 불러오기 성공: " + upgradeBoxJson.boxColor);

        SetFirst();
    }

    void LoadData()
    {
        string load_Json = File.ReadAllText(Application.dataPath + "/UpgradeBox.json");
        upgradeBoxJson = JsonUtility.FromJson<UpgradeBox>(load_Json);

        box_Level_Data = upgradeBoxJson.box_Level;
        upgradePercent_Data = upgradeBoxJson.upgradePercent;
        boxColor_Data = upgradeBoxJson.boxColor;

        box_Level_Text.text = "레벨: " + box_Level_Data;
        upgradePercent_Text.text = "업그레이드 퍼센트: " + upgradePercent_Data + "%";
        boxColor_Image.color = boxColor_Data;
    }

    void SetFirst()
    {
        // UI 초기화
        box_Level_Text.text = "레벨: " + 1.ToString();
        upgradePercent_Text.text = "업그레이드 퍼센트: " + 100.ToString() + "%";
        boxColor_Image.color = colors[0];

        // 데이터 초기화
        box_Level_Data = 1;
        upgradePercent_Data = 100;
        boxColor_Data = colors[0];
    }

    void SetUpgrade()
    {

        box_Level_Data++;
        upgradePercent_Data -= 10;
        boxColor_Data = colors[box_Level_Data - 1];

        box_Level_Text.text = "레벨: " + box_Level_Data;
        upgradePercent_Text.text = "업그레이드 퍼센트: " + upgradePercent_Data + "%";
        boxColor_Image.color = boxColor_Data;
    }

    public void OnClickUpgrade()
    {
        int random = UnityEngine.Random.Range(1, 101);
        if(random < upgradePercent_Data)
        {
            SetUpgrade();
        }
        else
        {
            SetFirst();
        }
    }

    public void OnClickSave()
    {
        upgradeBoxJson.box_Level = box_Level_Data;
        upgradeBoxJson.upgradePercent = upgradePercent_Data;
        upgradeBoxJson.boxColor = boxColor_Data;

        string dataJson = JsonUtility.ToJson(upgradeBoxJson, true);
        File.WriteAllText(Application.dataPath + "/UpgradeBox.json", dataJson);

        Debug.Log($"저장 완료! 파일 경로: {Application.dataPath + "/UpgradeBox.json"}");
    }

    public void OnClickLoad()
    {
        LoadData();
    }

    public void OnClickDelete()
    {
        SetFirst();
        upgradeBoxJson.box_Level = box_Level_Data;
        upgradeBoxJson.upgradePercent = upgradePercent_Data;
        upgradeBoxJson.boxColor = boxColor_Data;
    }
}
