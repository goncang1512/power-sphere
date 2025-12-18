using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigid;
    public float boundary = 8.37f;

    [Header("Auto Resize Settings")]
    public float minWidth = 0.8f;     // Ukuran paling pendek
    public float maxWidth = 2.5f;     // Ukuran paling panjang
    public float resizeSpeed = 2f;    // Kecepatan perubahan ukuran

    private SpriteRenderer spriteRenderer;
    private float resizeTime;

    void Start()
    {
        // Mengambil komponen SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ================= MEWARNAI PAPAN JADI MERAH =================
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }
    }

    void Update()
    {
        // ================= LOGIKA PERGERAKAN =================
        float xMove = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xMove = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xMove = 1f;

        rigid.linearVelocity = new Vector2(xMove * speed, rigid.linearVelocity.y);

        // ================= LOGIKA AUTO RESIZE (SKALA) =================
        // Menggunakan Sinus agar nilai berayun naik turun secara halus
        resizeTime += Time.deltaTime * resizeSpeed;

        // Menghasilkan nilai antara minWidth dan maxWidth
        float scaleX = Mathf.Lerp(
            minWidth,
            maxWidth,
            (Mathf.Sin(resizeTime) + 1f) / 2f
        );

        // Terapkan ke skala objek (sumbu X)
        transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);

        // ================= PEMBATAS LAYAR (BOUNDARY) =================
        if (transform.position.x > boundary)
            transform.position = new Vector2(boundary, transform.position.y);
        else if (transform.position.x < -boundary)
            transform.position = new Vector2(-boundary, transform.position.y);
    }
}