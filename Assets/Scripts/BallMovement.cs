using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    public Score score;
    public Transform padle;
    public Grid grid;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startBallMove();
    }

    void startBallMove()
    {
        float xDirection = 1;
        float yDirection = 1;
        Vector2 direction = new Vector2(xDirection, yDirection) * speed;
        rigid.linearVelocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position .y < -6f)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        transform.position = new Vector2(0f, -3.39f);
        padle.transform.position = new Vector2(0f, -4.5f);
        startBallMove();
        if(score.playerScore >= 18)
        {
            grid.CreateGrid();
            score.playerScore = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            score.playerScore++; 

            if(score.playerScore >= 18)
            {
                grid.CreateGrid();
                score.playerScore = 0;
            }
        }
    }
}
