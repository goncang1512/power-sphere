using UnityEngine;

public class Blockspawn : MonoBehaviour
{
    public GameObject blockPrefab;   // Prefab Square
    public int rows = 3;             // jumlah baris
    public int columns = 6;          // jumlah kolom
    public float spacing = 0.3f;     // jarak antar block

    public float rotateSpeed = 60f;  // kecepatan rotasi

    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector2 pos = new Vector2(x * spacing, y * spacing);
                GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);

                // Tambahkan rotasi ke setiap block
                block.AddComponent<BlockRotate>().rotateSpeed = rotateSpeed;
            }
        }
    }
}

// ================= ROTASI BLOK =================
public class BlockRotate : MonoBehaviour
{
    public float rotateSpeed = 60f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
