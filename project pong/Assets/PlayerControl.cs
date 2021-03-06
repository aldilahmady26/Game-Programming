using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private Rigidbody2D rigidBody2D;
    private int score;
    private ContactPoint2D lastContactPoint;
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dapatkan kecepatan raket sekarang
        Vector2 velocity = rigidBody2D.velocity;
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else 
        {
            velocity.y = 0.0f;
        }
        rigidBody2D.velocity = velocity;
        //Dapatkan posisi raket sekarang
        Vector3 position = transform.position;
        if (position.y > yBoundary) 
        {
            position.y = yBoundary;
        }
        else if(position.y<-yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;
    }
    //menaikkan skor
    public void IncrementScore()
    {
        score++;
    }
    //mengembalikan score menajdi 0
    public void ResetScore()
    {
        score = 0;
    }
    //mendapatkan nilai score
    public int Score
    {
        get { return score; }
    }
}
