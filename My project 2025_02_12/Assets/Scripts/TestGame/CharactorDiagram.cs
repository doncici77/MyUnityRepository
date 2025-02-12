using UnityEngine;

public class CharactorDiagram : MonoBehaviour
{
    private void Start()
    {
        Charactor player = new Player();
        Charactor npc = new Npc();
        Charactor badguy = new BadGuys();

        player.Talk();
        npc.Talk();
        badguy.Move();
    }
}
