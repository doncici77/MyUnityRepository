using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioEvent audioEvent;
    public Item item;

    void Start()
    {
        audioEvent.OnPlay += PlaySound;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            audioEvent.Play("등장 배경음");
        }
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            DropItem();
        }
    }

    private void DropItem()
    {
        var item_Object = item.gameObject;
        Instantiate(item_Object, transform.position, Quaternion.identity);
    }

    public void PlaySound(string soundName)
    {
        Debug.Log(soundName + " 플레이 중입니다.");
    }
}
