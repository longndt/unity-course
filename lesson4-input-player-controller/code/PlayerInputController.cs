using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Modern Input System implementation using Player Input component
/// Demonstrates the new Input System approach with Input Actions
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Rigidbody2D rb;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();

        // Get references to actions
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void OnEnable()
    {
        // NEW WAY - Event-driven input (recommended)
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        jumpAction.started += OnJumpStarted;      // Key down
        jumpAction.performed += OnJumpPerformed;  // Key pressed
        jumpAction.canceled += OnJumpCanceled;    // Key up

        // Enable actions
        moveAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        // Unsubscribe from events
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
        jumpAction.started -= OnJumpStarted;
        jumpAction.performed -= OnJumpPerformed;
        jumpAction.canceled -= OnJumpCanceled;
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    void OnJumpStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Jump started");
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Jump performed (New Input System)");
    }

    void OnJumpCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Jump released");
    }
}