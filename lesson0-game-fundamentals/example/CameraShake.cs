using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Settings")]
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;
    private float shakeTimer = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Generate random shake offset
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = originalPosition + randomOffset;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Return to original position
            transform.localPosition = originalPosition;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        shakeTimer = duration;
    }
}
