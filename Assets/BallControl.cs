using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Randomly select direction to move next ball
    void BallStart()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
            rb2d.AddForce(new Vector2(20, -15));
        else
            rb2d.AddForce(new Vector2(-20, -15));
    }

    // Reset Ball at (0,0)
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Handle the next game
    void RestartGame()
    {
        ResetBall();
        Invoke("BallStart", 1);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.collider.CompareTag("Player")) // check to see if ball hits Player (paddle)
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("BallStart", 2); // Waits 2 second to invoke the function
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
