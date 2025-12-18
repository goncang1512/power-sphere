using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigid;
    public float boundary = 8.37f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xMove = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xMove = 1f;

        rigid.linearVelocity = new Vector2(xMove * speed, rigid.linearVelocity.y);

        if (transform.position.x > boundary)
            transform.position = new Vector2(boundary, transform.position.y);
        else if (transform.position.x < -boundary)
            transform.position = new Vector2(-boundary, transform.position.y);
    }
}
