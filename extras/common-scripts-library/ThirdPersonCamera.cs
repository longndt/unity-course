using UnityEngine;

/// <summary>
/// Third Person Camera with smooth following and mouse orbit controls
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);

    [Header("Camera Settings")]
    public float followSpeed = 10f;
    public float rotationSpeed = 2f;
    public float mouseSensitivity = 2f;

    [Header("Collision Settings")]
    public LayerMask collisionLayers = -1;
    public float collisionRadius = 0.2f;
    public float minDistance = 1f;
    public float maxDistance = 15f;

    private float currentX = 0f;
    private float currentY = 0f;
    private float currentDistance;
    private Vector3 currentOffset;

    void Start()
    {
        // Find player if no target assigned
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }

        currentDistance = offset.magnitude;
        currentOffset = offset;

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseInput();
    }

    void LateUpdate()
    {
        if (target == null) return;

        HandleCameraPosition();
        HandleCameraRotation();
    }

    void HandleMouseInput()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Update rotation
        currentX += mouseX;
        currentY -= mouseY;

        // Clamp vertical rotation
        currentY = Mathf.Clamp(currentY, -80f, 80f);
    }

    void HandleCameraPosition()
    {
        // Calculate desired position
        Vector3 desiredPosition = target.position + currentOffset;

        // Check for collision
        Vector3 direction = (desiredPosition - target.position).normalized;
        float distance = currentDistance;

        RaycastHit hit;
        if (Physics.SphereCast(target.position, collisionRadius, direction, out hit, currentDistance, collisionLayers))
        {
            distance = Mathf.Max(hit.distance - collisionRadius, minDistance);
        }

        // Apply distance constraint
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Calculate final position
        Vector3 finalPosition = target.position + direction * distance;

        // Smoothly move to position
        transform.position = Vector3.Lerp(transform.position, finalPosition, followSpeed * Time.deltaTime);
    }

    void HandleCameraRotation()
    {
        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Apply rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Update offset based on rotation
        currentOffset = rotation * Vector3.forward * currentDistance;
    }

    void OnDrawGizmosSelected()
    {
        if (target == null) return;

        // Draw camera path
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(target.position, target.position + currentOffset);

        // Draw collision sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target.position + currentOffset, collisionRadius);
    }
}
