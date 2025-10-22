using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene management basics
/// Demonstrates how to load scenes programmatically
/// </summary>
public class SceneManagement : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Load scene in code
        SceneManager.LoadScene(sceneName);
    }
}