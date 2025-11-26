using UnityEngine;

public class Blockspawn : MonoBehaviour
{
    public GameObject blockPrefab;   // Prefab Square
    public int rows = 3;             // jumlah baris
    public int columns = 6;          // jumlah kolom
    public float spacing = 0.3f;     // jarak antar block

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                Instantiate(blockPrefab, pos, Quaternion.identity);
            }
        }
    }
}
