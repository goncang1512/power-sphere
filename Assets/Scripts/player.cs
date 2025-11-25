using UnityEngine;
using UnityEngine.InputSystem; // <- penting

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        //Debug.Log("Player has entered the scene");
        transform.position = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Arrow keys / WASD dengan Input System baru
        if (Keyboard.current.leftArrowKey.isPressed) moveX = -1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX = 1f;

        if (Keyboard.current.upArrowKey.isPressed) moveY = 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY = -1f;

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
