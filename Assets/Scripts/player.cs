using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rigidbody;

    [Header("Auto Resize")]
    public float minWidth = 0.8f;
    public float maxWidth = 2.2f;
    public float resizeSpeed = 2f;

    private float boundary;
    private float xMove;
    private SpriteRenderer spriteRenderer;
    private float resizeTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ================= WARNA PUTIH =================
        spriteRenderer.color = Color.white;

        UpdateBoundary();
    }

    void Update()
    {
        // ================= MOVE =================
        xMove = 0;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            xMove = -1;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            xMove = 1;

        rigidbody.linearVelocity = new Vector2(xMove * speed, 0);

        // ================= AUTO RESIZE =================
        resizeTime += Time.deltaTime * resizeSpeed;

        float scaleX = Mathf.Lerp(
            minWidth,
            maxWidth,
            (Mathf.Sin(resizeTime) + 1f) / 2f
        );

        transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);

        // Update boundary karena ukuran berubah
        UpdateBoundary();

        // ================= BOUNDARY =================
        if (transform.position.x < -boundary)
            transform.position = new Vector2(-boundary, transform.position.y);
        else if (transform.position.x > boundary)
            transform.position = new Vector2(boundary, transform.position.y);
    }

    void UpdateBoundary()
    {
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float paddleHalfWidth = spriteRenderer.bounds.size.x / 2;
        boundary = halfWidth - paddleHalfWidth;
    }
}
