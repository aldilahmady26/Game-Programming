using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    //Pemain yg akan bertambah skornya jika bola menyentuh dinding ini.
    public PlayerControl player;

    //Akan dipanggil ketika objek lain bercollider (bola) bersentuhan dengan dinding
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.name == "Ball")
        {
            player.IncrementScore();
            if (player.Score < gameManager.maxScore)
            {
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
