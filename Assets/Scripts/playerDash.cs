using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Dash settings
    private bool canDash = true; // Can the player dash?
    private bool isDashing = false; // Is the player currently dashing?
    private float dashingPower = 24f; // Power of the dash, can be adjusted for game feel
    private float dashingTime = 0.2f; // How long the dash lasts
    private float dashingCooldown = 1f; // How long before player can dash again

    // Components and physics
    [SerializeField] private Rigidbody2D rb; // Rigidbody component for physics interaction

    private void Update()
    {
        // Handle dashing: Ignore other input if dashing
        if (!isDashing)
        {
            // Dash logic - listens for 'W' key
            if (Input.GetKeyDown(KeyCode.W) && canDash)
            {
                StartCoroutine(Dash()); // Start dash coroutine
            }
        }
    }

    // Coroutine for handling the dashing mechanism
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        Vector2 dashDirection = new Vector2(transform.localScale.x * dashingPower, rb.velocity.y); // Adds horizontal dash force
        rb.velocity = dashDirection; // Apply the new velocity vector
        yield return new WaitForSeconds(dashingTime); // Wait for dash duration
        isDashing = false; // Dash ends
        yield return new WaitForSeconds(dashingCooldown); // Wait for cooldown
        canDash = true; // Re-enable dashing
    }
}

