using UnityEngine;

/// <summary>
/// A simple bouncing ball that demonstrates basic Unity 2D physics and effects.
/// Perfect for beginners to understand GameObject/Component model and collision detection.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BouncingBall : MonoBehaviour
{
    [Header("Ball Settings")]
    [SerializeField] private float initialSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float maxSpeed = 15f;

    [Header("Effects")]
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private GameObject bounceEffect;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        // Get components with null checks
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("BouncingBall requires a Rigidbody2D component!");
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add AudioSource component if missing
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set initial velocity in random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * initialSpeed;

        Debug.Log("Ball started! Speed: " + initialSpeed);
    }

    void Update()
    {
        // Only update if we have a valid Rigidbody2D
        if (rb == null) return;

        // Increase speed over time (but cap at maxSpeed)
        float currentSpeed = rb.velocity.magnitude;
        if (currentSpeed < maxSpeed)
        {
            float newSpeed = currentSpeed + speedIncrease * Time.deltaTime;
            rb.velocity = rb.velocity.normalized * newSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play bounce sound
        if (audioSource && bounceSound)
        {
            audioSource.PlayOneShot(bounceSound);
        }

        // Create particle effect
        if (bounceEffect)
        {
            Instantiate(bounceEffect, transform.position, Quaternion.identity);
        }

        // Add screen shake effect
        Camera.main.GetComponent<CameraShake>()?.Shake(0.1f, 0.1f);

        Debug.Log("Ball bounced off: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("Ball reached goal!");
            // Add scoring logic here
        }
    }
}
