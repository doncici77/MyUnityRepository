using System;
using System.Collections.Generic;
using UnityEngine;
// 1. �迭 / List ���·� ����Ǿ� �ִ� json ������ ����ϴ� ����
// 2. Resources ������ �̿��� ������ �ε� ����� ���

// �����ȿ� �ִ� ������ �ϳ��� ���� ǥ��
[Serializable]
public class Item
{
    public string item_name; // json ���Ͽ��� ����ϰ� �ִ� �̸��� �״�� ���
    public int item_count;
}


//������ ���� ǥ��
[Serializable]
public class Inventory
{
    public List<Item> inventory; // json ���Ͽ��� ����ϰ� �ִ� �̸��� �״�� ���
    // public Item[] inventoy; ����Ƽ������ �迭�� ����Ʈ�� ���� ���
}

public class JsonArraySample : MonoBehaviour
{
    void Start()
    {
        // Resources ������ �ִ� item_inventory.json ������ �о����
        TextAsset textAsset = Resources.Load<TextAsset>("item_inventory");

        // json ������ �о Ŭ����ȭ
        Inventory invertory = JsonUtility.FromJson<Inventory>(textAsset.text);

        int total = 0; // ������ ���� ����

        // foreach(Ÿ�� ���� in �迭/����Ʈ)
        // �迭�̳� ����Ʈ�� ������ �ִ� ������ ������ŭ �ݺ��� �����ϴ� ���� ����
        foreach (Item item in invertory.inventory)
        {
            total += item.item_count;
        }

        Debug.Log(total);

        // �迭�� ���
        /*for(int i = 0; i < invertory.invetory.Count; i++)
        {
            total += invetory.invetory[i].item_count
        }*/
    }

    void Update()
    {
        
    }
}
