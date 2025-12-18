using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public Rigidbody2D rigid;
    public float boundary = 8.37f;

    [Header("Boost Settings")]
    public float speedMultiplier = 1.8f;
    public float sizeMultiplierBig = 1.5f;
    public float sizeMultiplierSmall = 0.6f;
    public float boostDuration = 5f;

    private float defaultSpeed;
    private Vector3 defaultScale;

    void Start()
    {
        defaultSpeed = speed;
        defaultScale = transform.localScale;
    }

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

    // =====================
    // POWER UP SYSTEM
    // =====================

    public void ActivateRandomBoost()
    {
        StopAllCoroutines();

        int randomBoost = Random.Range(0, 3);
        // 0 = speed, 1 = big, 2 = small

        switch (randomBoost)
        {
            case 0:
                StartCoroutine(SpeedBoost());
                break;
            case 1:
                StartCoroutine(SizeBoost(sizeMultiplierBig));
                break;
            case 2:
                StartCoroutine(SizeBoost(sizeMultiplierSmall));
                break;
        }
    }

    private IEnumerator SpeedBoost()
    {
        speed = defaultSpeed * speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        speed = defaultSpeed;
    }

    private IEnumerator SizeBoost(float multiplier)
    {
        transform.localScale = new Vector3(
            defaultScale.x * multiplier,
            defaultScale.y,
            defaultScale.z
        );

        yield return new WaitForSeconds(boostDuration);
        transform.localScale = defaultScale;
    }
}
