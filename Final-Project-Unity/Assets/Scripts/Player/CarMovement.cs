using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float SteerSpeed = 200f;

    private Rigidbody2D rb;
    private float moveInput;
    private float steerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = 0f;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveInput = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveInput = -1f;

        steerInput = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            steerInput = 1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            steerInput = -1f;
    }

    void FixedUpdate()
    {
        // apply rotation
        float rotationAmount = steerInput * SteerSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);

        // apply forward movement
        Vector2 direction = transform.up;  // forward direction in 2D
        rb.MovePosition(rb.position + direction * moveInput * MoveSpeed * Time.fixedDeltaTime);
    }
}