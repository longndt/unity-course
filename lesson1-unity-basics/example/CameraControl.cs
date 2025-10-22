using UnityEngine;

/// <summary>
/// Camera control for 2D games
/// Demonstrates orthographic camera size adjustment
/// </summary>
public class CameraControl : MonoBehaviour
{
    void Start()
    {
        // Change camera size in code
        Camera.main.orthographicSize = 8f;
    }
}