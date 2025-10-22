# Lesson 1 Reference - Unity Fundamentals

## MonoBehaviour Lifecycle Order

```csharp
// Execution order (per GameObject):
Awake()     // Called before Start, even if disabled
OnEnable()  // Called when GameObject becomes active
Start()     // Called once before first Update
Update()    // Called every frame
LateUpdate() // Called after all Updates
OnDisable() // Called when GameObject becomes inactive
OnDestroy() // Called when GameObject is destroyed
```

## Common Unity APIs

### Transform
```csharp
transform.position = new Vector3(x, y, z);
transform.rotation = Quaternion.Euler(x, y, z);
transform.localScale = Vector3.one;
transform.Translate(Vector3.right * speed * Time.deltaTime);
```

### GameObject
```csharp
GameObject.Find("Name");
GameObject.FindWithTag("Player");
Instantiate(prefab, position, rotation);
Destroy(gameObject, delay);
SetActive(true/false);
```

### Scene Management
```csharp
using UnityEngine.SceneManagement;

SceneManager.LoadScene("SceneName");
SceneManager.LoadSceneAsync("SceneName");
SceneManager.GetActiveScene().name;
```

## Debug Tools

### Console Logging
```csharp
Debug.Log("Message");
Debug.LogWarning("Warning");
Debug.LogError("Error");
Debug.LogFormat("Player {0} has {1} health", name, health);
```

### Gizmos (Scene View)
```csharp
void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, radius);
    Gizmos.DrawLine(start, end);
}
```

## Project Setup Checklist

- [ ] Unity 6 LTS installed via Unity Hub
- [ ] 2D project template selected
- [ ] URP (Universal Render Pipeline) enabled if needed
- [ ] Input System package installed
- [ ] Git LFS configured for large assets
- [ ] IDE configured with Unity debugger

## Common Pitfalls

- **Null Reference**: Check if GameObject exists before accessing components
- **Execution Order**: Use `Awake()` for initialization, `Start()` for dependencies
- **Scene Loading**: Use `LoadSceneAsync()` for large scenes
- **Memory**: Destroy instantiated objects to prevent leaks
