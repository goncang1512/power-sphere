using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public GameObject block;
    public float spacing;
    public List<GameObject> blocks = new List<GameObject>();

    void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            Destroy(blocks[i]);
            blocks.Remove(blocks[i]);
        }

        for(int x = 0; x < 6; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                GameObject obj = Instantiate(block, new Vector2(x * spacing, y * 1f), Quaternion.identity, transform);
                obj.transform.localPosition = new Vector2(x * spacing, y * 1f);

                SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.color = Color.black; // Mengatur warna awal menjadi hitam
                }

                blocks.Add(obj);
            }
        }
    }
}
