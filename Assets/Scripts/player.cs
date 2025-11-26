using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rigidbody;

    private float boundary;
    private float xMove;

    void Start()
    {
        // Hitung boundary berdasarkan kamera + ukuran sprite paddle
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float paddleHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        boundary = halfWidth - paddleHalfWidth;
    }

    void Update()
    {
        // Input kiri-kanan
        xMove = 0;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            xMove = -1;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            xMove = 1;

        rigidbody.linearVelocity = new Vector2(xMove * speed, 0);

        // Batasi paddle agar tidak keluar layar
        if (transform.position.x < -boundary)
            transform.position = new Vector2(-boundary, transform.position.y);
        else if (transform.position.x > boundary)
            transform.position = new Vector2(boundary, transform.position.y);
    }
}
