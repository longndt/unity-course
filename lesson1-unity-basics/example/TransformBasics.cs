using UnityEngine;

/// <summary>
/// Basic Transform operations in Unity 2D
/// Demonstrates how to access and modify GameObject transforms
/// </summary>
public class TransformBasics : MonoBehaviour
{
    void Start()
    {
        // Access Transform in code
        Transform myTransform = transform;
        myTransform.position = new Vector3(5f, 2f, 0f);
        myTransform.localScale = new Vector3(2f, 2f, 1f);
    }
}