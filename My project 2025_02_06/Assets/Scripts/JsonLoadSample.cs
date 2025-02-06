using System.IO;
using UnityEngine;
// Json �����
// 1. ���� �� �ִ� ������ ���·� �������.
// 2. ���� ��� ������� json ������ ã�Ƽ� ������ �ؽ�Ʈ�� �о.
// 3. �о �����͸� ���� Ŭ����ȭ�� ����.
// 4. ������ ���� ��.

public class Item01
{ 
    public string name;
    public string description;
}

public class JsonLoadSample : MonoBehaviour
{
    void Start()
    {
        string load_Json = File.ReadAllText(Application.dataPath + "/item01.json");
        // �۾� ������ �ǹ��մϴ�.(����Ƽ���� Assets ���� ��ġ)
        var data = JsonUtility.FromJson<Item01>(load_Json);
        Debug.Log(data.name);

        // ������ ����
        data.name = "������� �ٲ㺸��";
        data.description = "���m��������������";

        // Json ���Ϸ� ��������(Save)
        File.WriteAllText(Application.dataPath + "/item02.json", JsonUtility.ToJson(data));
    }

    void Update()
    {
        
    }
}
