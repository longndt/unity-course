using UnityEngine;

/// <summary>
/// Top-Down Player Controller with 4-directional movement and rotation
/// </summary>
public class TopDownPlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Input Settings")]
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Set up for top-down movement
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleInput()
    {
        // Get input
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        // Create movement vector
        movement = new Vector2(horizontal, vertical).normalized;

        // Store last movement for rotation
        if (movement.magnitude > 0.1f)
        {
            lastMovement = movement;
        }
    }

    void HandleMovement()
    {
        // Apply movement
        rb.velocity = movement * moveSpeed;
    }

    void HandleRotation()
    {
        // Only rotate if there's movement
        if (lastMovement.magnitude > 0.1f)
        {
            // Calculate target rotation
            float targetAngle = Mathf.Atan2(lastMovement.y, lastMovement.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards target
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.fixedDeltaTime);

            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw movement direction
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)lastMovement * 2f);

        // Draw forward direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 2f);
    }
}
