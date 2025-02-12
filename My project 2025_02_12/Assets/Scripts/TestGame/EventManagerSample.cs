using System;
using UnityEngine;
using UnityEngine.UI;

class BoomEvent
{
    public delegate void BoomEventHandler(string message);
    public event BoomEventHandler boomhandler;

    public int hp = 5;

    public void BoomText()
    {
        if(hp > 1)
        {
            hp--;
            Debug.Log($"³²Àº hp: {hp}");
            boomhandler($"³²Àº hp: {hp}");
        }
        else
        {
            Debug.Log("ºÕ!!!!!!!!!");
            boomhandler("ºÕ!!!!!!!!!");
            hp = 5;
        }
    }
}

public class EventManagerSample : MonoBehaviour
{
    public GameObject enemy;
    public Text messageUI;
    BoomEvent boom = new BoomEvent();

    void Start()
    {
        boom.boomhandler += BoomEffect;
    }

    private void BoomEffect(string message)
    {
        messageUI.text = message;
    }

    void Update()
    {
        
    }

    public void OnBoomtButtonEnter()
    {
        if(boom.hp == 1)
        {
            Boom();
        }
        boom.BoomText();
    }

    public void Boom()
    {
        enemy.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(enemy, 1f);
    }

}
