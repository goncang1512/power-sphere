using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    public Score score;
    public Transform padle;
    public Grid grid;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Ambil komponen renderer dari objek bulat bawaan Unity
        spriteRenderer = GetComponent<SpriteRenderer>();

        // MENGUBAH WARNA TANPA MENGUBAH BENTUK (Grey)
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.grey;
        }

        startBallMove();
    }

    void startBallMove()
    {
        Vector2 direction = new Vector2(1, 1).normalized;
        rigid.linearVelocity = direction * speed;
    }

    void Update()
    {
        // Jaga kecepatan tetap kencang/liar (Konstan)
        if (rigid.linearVelocity.magnitude != speed && rigid.linearVelocity.magnitude > 0)
        {
            rigid.linearVelocity = rigid.linearVelocity.normalized * speed;
        }

        if (transform.position.y < -6f)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        transform.position = new Vector2(0f, -3.39f);
        padle.transform.position = new Vector2(0f, -4.5f);
        startBallMove();

        if (score.playerScore >= 18)
        {
            grid.CreateGrid();
            score.playerScore = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Paksa kecepatan balik ke asal setelah nabrak agar tidak melambat
        rigid.linearVelocity = rigid.linearVelocity.normalized * speed;

        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            score.playerScore++;

            if (score.playerScore >= 18)
            {
                grid.CreateGrid();
                score.playerScore = 0;
            }
        }
    }
}