using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;

    // Ukuran diperkecil ke 64x64 agar ringan
    private int textureSize = 64;

    void Start()
    {
        GenerateCustomBallTexture();
        StartBallMove();
    }

    void GenerateCustomBallTexture()
    {
        // Membuat tekstur kecil
        Texture2D texture = new Texture2D(textureSize, textureSize);

        // Atur agar pixel tidak terlihat pecah/blur (opsional)
        texture.filterMode = FilterMode.Point;

        float center = textureSize / 2f;
        float radius = textureSize / 2.2f; // Sedikit lebih kecil dari frame agar tidak terpotong
        float innerWhiteRadius = textureSize / 5f;

        for (int y = 0; y < textureSize; y++)
        {
            for (int x = 0; x < textureSize; x++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), new Vector2(center, center));

                if (distance < innerWhiteRadius)
                {
                    texture.SetPixel(x, y, Color.white);
                }
                else if (distance < radius)
                {
                    texture.SetPixel(x, y, Color.red);
                }
                else
                {
                    texture.SetPixel(x, y, new Color(0, 0, 0, 0));
                }
            }
        }

        texture.Apply();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            // Pivot diset ke (0.5, 0.5) agar bola berputar di tengah
            sr.sprite = Sprite.Create(texture, new Rect(0, 0, textureSize, textureSize), new Vector2(0.5f, 0.5f));
        }
    }

    void StartBallMove()
    {
        // Menggunakan .normalized agar kecepatan diagonal tidak lebih cepat dari lurus
        Vector2 direction = new Vector2(1, 1).normalized * speed;
        rigidbody.linearVelocity = direction; // ganti linearVelocity dengan velocity
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Menghancurkan block
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }

        // Menghancurkan triangle
        else if (collision.gameObject.CompareTag("Triangle"))
        {
            Destroy(collision.gameObject);
        }
    }
}
