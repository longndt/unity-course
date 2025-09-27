using UnityEngine;

/// <summary>
/// Basic 2D character movement with animation integration
/// Demonstrates movement and animator parameter control
/// </summary>
public class Character2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        UpdateAnimations();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(horizontal * moveSpeed, rb2D.velocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    void UpdateAnimations()
    {
        // Speed parameter for blend trees
        float speed = Mathf.Abs(rb2D.velocity.x);
        animator.SetFloat("Speed", speed);

        // Ground check for jump/fall states
        bool grounded = CheckGrounded();
        animator.SetBool("IsGrounded", grounded);

        // Jump trigger
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            animator.SetTrigger("JumpTrigger");
        }
    }

    bool CheckGrounded()
    {
        // Simple ground check implementation
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
    }

    // Local vs World position examples
    void PositionExamples()
    {
        // Local position (relative to parent)
        transform.localPosition = new Vector3(1f, 0f, 0f);

        // World position (absolute)
        transform.position = new Vector3(5f, 3f, 0f);
    }
}