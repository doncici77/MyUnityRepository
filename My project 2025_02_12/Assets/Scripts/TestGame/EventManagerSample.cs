using System;
using UnityEngine;
using UnityEngine.EventSystems;

class BoomEvent
{
    int hp = 10;

    public event EventHandler boomhandler;

    public void Boom()
    {
        if(hp > 0)
        {
            hp--;
            Debug.Log($"³²Àº hp: {hp}");
        }
        else
        {
            Debug.Log("ºÕ!!!!!!!!!");
            hp = 10;
            boomhandler(this, EventArgs.Empty);
        }
    }
}

public class EventManagerSample : MonoBehaviour
{
    BoomEvent boom = new BoomEvent();

    void Start()
    {
        boom.boomhandler += new EventHandler(BoomEffect);
    }

    private void BoomEffect(object sender, EventArgs e)
    {

    }

    void Update()
    {
        
    }

}
