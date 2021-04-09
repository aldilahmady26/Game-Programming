using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //rigidbody bola
    private Rigidbody2D rigidBody2D;

    //Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;

    void ResetBall()
    {
        //reset posisi
        transform.position = Vector2.zero;
        //reset kecepatan
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        //tentukan nilai acak antara 0 (inklusif) dan 2 (ekslusif)
        float randomDirection = Random.Range(0, 2);
        //jika nilainya dibawah 1, bola bergerak ke kiri
        //jika tidak bola bergerak ke kanan
        if (randomDirection < 1.0f)
        //gaya untuk bola bergerak
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else 
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        //mengembalikan bola ke posisi semula
        ResetBall();
        //setelah 2 detik beri gaya pada bola
        Invoke("PushBall", 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
