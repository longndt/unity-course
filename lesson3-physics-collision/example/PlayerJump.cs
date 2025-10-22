using UnityEngine;

/// <summary>
/// Basic jump mechanics implementation
/// Demonstrates ground checking and basic jump functionality
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 400f;
    public LayerMask groundLayer = 1;
    public float groundCheckDistance = 1.1f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void CheckGrounded()
    {
        // Simple raycast ground check
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    void Jump()
    {
        // Reset vertical velocity and add jump force
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        // Visualize ground check in scene view
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}