using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    public Score score;
    public Transform padle;
    public Grid grid;
    public GameObject itemPrefab;

    private SpriteRenderer ballRenderer;
    private bool isWhite = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRenderer = GetComponent<SpriteRenderer>();
        ApplyBlackWhiteColor();
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
        isWhite = true;
        ApplyBlackWhiteColor();
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
            ToggleColor();
            Vector2 spawnPos = collision.transform.position;

            Destroy(collision.gameObject);
            score.playerScore++;

            int randomValue = Random.Range(1, 11); // 1 - 10

            // jika genap → spawn item
            if (randomValue % 2 == 0)
            {
                Instantiate(itemPrefab, spawnPos, Quaternion.identity);
            }

            if (score.playerScore >= 18)
            {
                grid.CreateGrid();
                score.playerScore = 0;
            }
        }
    }

    // Fungsi bantu untuk mengubah warna
    void ToggleColor()
    {
        isWhite = !isWhite;
        ApplyBlackWhiteColor();
    }

    void ApplyBlackWhiteColor()
    {
        if (ballRenderer != null)
        {
            ballRenderer.color = isWhite ? Color.white : Color.black;
        }
    }
}
