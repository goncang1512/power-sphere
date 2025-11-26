using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;

    void Start()
    {
        StartBallMove();
    }

    void StartBallMove()
    {
        float xMove = 1;
        float yMove = 1;
        Vector2 direction = new Vector2(xMove, yMove) * speed;
        rigidbody.linearVelocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
    }
}
