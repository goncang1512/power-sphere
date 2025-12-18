using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float rotateSpeed = 180f;
    public float fallSpeed = 2f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Padel"))
        {
            Movement paddle = other.GetComponent<Movement>();

            if (paddle != null)
            {
                paddle.ActivateRandomBoost();
            }

            Destroy(gameObject);
        }
    }
}
