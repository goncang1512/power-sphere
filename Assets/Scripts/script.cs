using UnityEngine;

public class script : MonoBehaviour
{
    public float rotationSpeed = 180f; // derajat per detik

    void Update()
    {
        // Rotasi di tempat pada sumbu Z (2D)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
