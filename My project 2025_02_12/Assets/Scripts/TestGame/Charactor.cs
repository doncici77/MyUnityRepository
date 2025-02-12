using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

interface Charactor
{
    void Move();

    void Talk();
}

public class Player : Charactor
{
    public void Move()
    {

    }

    public void Talk()
    {

    }
}

public class BadGuys : Charactor
{
    public void Move()
    {

    }

    public void Talk()
    {

    }
}

public class Npc : Charactor
{
    public void Move()
    {

    }

    public void Talk()
    {

    }
}
