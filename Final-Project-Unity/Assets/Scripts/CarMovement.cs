using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class CarMovement : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float SteerSpeed = 100f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float move = Keyboard.current switch
        {
            { wKey: { isPressed: true } } or { upArrowKey: { isPressed: true } } => 1f,
            { sKey: { isPressed: true } } or { downArrowKey: { isPressed: true } } => -1f,
            _ => 0f
        };

        float steer = Keyboard.current switch
        {
            { aKey: { isPressed: true } } or { leftArrowKey: { isPressed: true } } => 1f,
            { dKey: { isPressed: true } } or { rightArrowKey: { isPressed: true } } => -1f,
            _ => 0f
        };

        float rotation = steer * SteerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, 0, rotation);

        float moveAmount = move * MoveSpeed * Time.fixedDeltaTime;
        transform.Translate(0, moveAmount, 0);
    }
} 
