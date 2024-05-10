using UnityEngine;

public enum PlayerID
{
    Player1,
    Player2
}

public class MultiplayerScriptHope : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to set the movement speed
    public float fallForce = 2f; // Adjust this to set the fall force
    public float dashSpeed = 10f; // Adjust this to set the dash speed
    public float dashDuration = 0.2f; // Adjust this to set the dash duration

    public PlayerID playerID;
    private KeyCode[] playerKeys;
    private KeyCode dashKey;

    private Rigidbody2D rb;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject

        // Assign keys based on player ID
        if (playerID == PlayerID.Player1)
        {
            playerKeys = new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
            dashKey = KeyCode.Keypad0;
        }
        else if (playerID == PlayerID.Player2)
        {
            playerKeys = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };
            dashKey = KeyCode.Space;
        }
    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        // Check input for the player
        if (Input.GetKey(playerKeys[0]))
            movement.y = 1;
        if (Input.GetKey(playerKeys[1]))
            movement.y = -1;
        if (Input.GetKey(playerKeys[2]))
            movement.x = -1;
        if (Input.GetKey(playerKeys[3]))
            movement.x = 1;

        // Apply movement
        if (!isDashing)
        {
            rb.velocity = movement.normalized * moveSpeed;
        }

        // Apply falling force when not moving
        if (movement == Vector2.zero)
        {
            // Apply constant downward force
            rb.AddForce(Vector2.down * fallForce);
        }

        // Check for dash input
        if (Input.GetKeyDown(dashKey))
        {
            Dash(playerKeys[2], playerKeys[3]);
        }
    }

    void Dash(KeyCode leftKey, KeyCode rightKey)
    {
        if (!isDashing)
        {
            Vector2 dashDirection = Vector2.zero;
            if (Input.GetKey(leftKey))
                dashDirection = Vector2.left;
            else if (Input.GetKey(rightKey))
                dashDirection = Vector2.right;

            if (dashDirection != Vector2.zero)
            {
                isDashing = true;
                rb.velocity = dashDirection.normalized * dashSpeed;
                Invoke("EndDash", dashDuration);
            }
        }
    }

    void EndDash()
    {
        isDashing = false;
    }
}
