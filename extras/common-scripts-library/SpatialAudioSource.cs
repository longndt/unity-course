using UnityEngine;

/// <summary>
/// 3D Spatial Audio Source with distance-based volume and 3D positioning
/// </summary>
public class SpatialAudioSource : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip audioClip;
    public bool playOnStart = false;
    public bool loop = false;

    [Header("3D Settings")]
    public float minDistance = 1f;
    public float maxDistance = 500f;
    public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;

    [Header("Doppler Settings")]
    public float dopplerLevel = 1f;
    public float pitch = 1f;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float volume = 1f;

    private AudioSource audioSource;
    private Transform player;

    void Start()
    {
        // Get or create audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure audio source
        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        // Configure 3D settings
        audioSource.spatialBlend = 1f; // Full 3D
        audioSource.rolloffMode = rolloffMode;
        audioSource.minDistance = minDistance;
        audioSource.maxDistance = maxDistance;
        audioSource.dopplerLevel = dopplerLevel;

        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        // Play on start
        if (playOnStart && audioClip != null)
        {
            Play();
        }
    }

    void Update()
    {
        // Update volume based on distance to player
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            float volumeMultiplier = CalculateVolumeByDistance(distance);
            audioSource.volume = volume * volumeMultiplier;
        }
    }

    float CalculateVolumeByDistance(float distance)
    {
        if (distance <= minDistance)
        {
            return 1f;
        }
        else if (distance >= maxDistance)
        {
            return 0f;
        }
        else
        {
            switch (rolloffMode)
            {
                case AudioRolloffMode.Linear:
                    return 1f - (distance - minDistance) / (maxDistance - minDistance);

                case AudioRolloffMode.Logarithmic:
                    return Mathf.Log10(1f + (maxDistance - distance) / maxDistance);

                default:
                    return 1f;
            }
        }
    }

    public void Play()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
        }
    }

    public void Stop()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void Pause()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void UnPause()
    {
        if (audioSource != null)
        {
            audioSource.UnPause();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void SetPitch(float newPitch)
    {
        pitch = newPitch;
        if (audioSource != null)
        {
            audioSource.pitch = pitch;
        }
    }

    public void SetClip(AudioClip newClip)
    {
        audioClip = newClip;
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw min distance
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minDistance);

        // Draw max distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);

        // Draw line to player
        if (player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}
