using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string itemName;
    [TextArea] public string itemDescription;

    public ItemData(string itemName, string itemDescription)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
    }

    string GetData()
    {
        return $"{itemName},{itemDescription}";
    }
}
