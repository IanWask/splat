using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Gamepad gamepad;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gamepad = Gamepad.current;
    }

    void Update()
    {
        if (gamepad == null)
            return;

        // Read input from the left stick for movement
        moveDirection = gamepad.leftStick.ReadValue();

        // Check for jump input (Button South, typically A button on Xbox controllers)
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            Jump();
        }
    }

void FixedUpdate()
{
    // Check if there's movement input
    if (moveDirection != Vector2.zero)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        // Move the player
        rb.velocity = moveDirection * moveSpeed;

    }
    else // If there's no movement input
    {
        // Apply a slight downward force
        rb.velocity += Vector2.down * 15f * Time.fixedDeltaTime; // Adjust the value as needed for desired gravity effect

        // Cap the downward velocity
        float maxDownwardVelocity = -500f; // Adjust as needed
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, maxDownwardVelocity));
    }
}


    void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

