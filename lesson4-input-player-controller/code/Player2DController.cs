using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Complete 2D Player Controller with advanced features
/// Demonstrates professional movement mechanics with Input System
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player2DController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float airControl = 0.5f;

    [Header("Jump Settings")]
    public float jumpHeight = 4f;
    public float jumpTimeToApex = 0.5f;
    public float coyoteTime = 0.1f;
    public float jumpBufferTime = 0.1f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayerMask = 1;

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveInput;
    private bool isGrounded;
    private float lastGroundedTime;
    private float jumpBufferCounter;
    private float jumpForce;
    private float gravity;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

        CalculateJumpPhysics();
    }

    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        jumpAction.performed += OnJump;

        moveAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        jumpAction.performed -= OnJump;
    }

    void Update()
    {
        CheckGrounded();
        HandleCoyoteTime();
        HandleJumpBuffer();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        jumpBufferCounter = jumpBufferTime;
    }

    void HandleMovement()
    {
        float targetSpeed = moveInput.x * moveSpeed;
        float currentSpeed = rb.velocity.x;

        float speedDifference = targetSpeed - currentSpeed;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        if (!isGrounded)
            accelRate *= airControl;

        float movement = speedDifference * accelRate;
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    void CheckGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);

        if (wasGrounded && !isGrounded)
        {
            lastGroundedTime = Time.time;
        }
    }

    void HandleCoyoteTime()
    {
        // Coyote time allows jumping shortly after leaving ground
        // This makes platforming feel more forgiving
    }

    void HandleJumpBuffer()
    {
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;

            bool canCoyoteJump = Time.time - lastGroundedTime <= coyoteTime;
            if (isGrounded || canCoyoteJump)
            {
                Jump();
                jumpBufferCounter = 0f;
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void CalculateJumpPhysics()
    {
        // Calculate jump force based on desired height and time to apex
        gravity = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);
        jumpForce = Mathf.Abs(gravity) * jumpTimeToApex;

        rb.gravityScale = gravity / Physics2D.gravity.y;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}