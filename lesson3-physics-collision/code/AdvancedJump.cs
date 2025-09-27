using UnityEngine;

/// <summary>
/// Advanced jump mechanics with variable height and coyote time
/// Demonstrates professional-grade jump feel improvements
/// </summary>
public class AdvancedJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 400f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Coyote Time")]
    public float coyoteTimeThreshold = 0.1f;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float lastGroundedTime;
    private float jumpBufferCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleCoyoteTime();
        HandleJumpBuffer();
        HandleVariableJump();
    }

    void HandleVariableJump()
    {
        // Apply variable gravity for better jump feel
        if (rb.velocity.y < 0)
        {
            // Falling: increase gravity
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // Rising but not holding jump: cut jump short
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void HandleCoyoteTime()
    {
        // Update grounded status
        bool wasGrounded = isGrounded;
        CheckGrounded();

        // Start coyote time when leaving ground
        if (wasGrounded && !isGrounded)
        {
            lastGroundedTime = Time.time;
        }
    }

    void HandleJumpBuffer()
    {
        // Handle jump input buffering
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Execute jump if conditions met
        bool canCoyoteJump = Time.time - lastGroundedTime <= coyoteTimeThreshold;
        if (jumpBufferCounter > 0f && (isGrounded || canCoyoteJump))
        {
            Jump();
            jumpBufferCounter = 0f; // Consume the buffer
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}