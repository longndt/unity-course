# Theory 1: Unity Fundamentals & Setup

## 🎯 Learning Objectives

- Set up a 2D project and navigate the Unity Editor efficiently
- Understand GameObject/Component model and MonoBehaviour lifecycle
- Create and use prefabs; manage scenes and scene loading
- Use simple debug tools (Gizmos, Logs) to inspect behavior

---

## 🚀 Quick Start

### Web/Mobile vs Game Development

#### **Web Development Pattern**
```javascript
// Web: Event-driven, state-based
class WebComponent {
    constructor() {
        this.state = {};
        this.render();
    }

    handleUserAction() {
        this.state = newState;
        this.render(); // Re-render UI
    }
}
```

#### **Mobile Development Pattern**
```swift
// iOS: App lifecycle, touch events
class ViewController: UIViewController {
    override func viewDidLoad() {
        super.viewDidLoad()
        setupUI()
    }

    @IBAction func buttonTapped(_ sender: UIButton) {
        performAction()
    }
}
```

#### **Game Development Pattern**
```csharp
// Unity: Real-time simulation, continuous updates
public class GameComponent : MonoBehaviour
{
    void Start() {
        // Initialize once
    }

    void Update() {
        // Update every frame (60+ FPS)
    }
}
```

### Unity Editor Overview
Unity uses a **Component-Based Architecture** where GameObjects are containers for Components that define behavior.

**Key Windows:**
- **Scene View**: 3D/2D world editor (like a level designer)
- **Game View**: What the player sees (like browser viewport)
- **Hierarchy**: GameObject tree structure (like DOM tree)
- **Inspector**: Component properties (like CSS properties)
- **Project**: Asset files (like file explorer)
- **Console**: Debug messages and errors

### 2D Project Setup
1. **Unity Hub** → New Project → **2D (URP)** template
2. **Scene View** → Enable 2D mode (top toolbar)
3. **Camera** → Set to Orthographic projection
4. **Gizmos** → Show only 2D elements

---

## 🧩 GameObject & Component System

### GameObject
- **Container** for Components
- Has **Transform** component by default
- Can be **parented** to other GameObjects
- **Active/Inactive** state affects visibility

### Components
- **Modular behaviors** attached to GameObjects
- **Transform**: Position, rotation, scale
- **SpriteRenderer**: Displays 2D images
- **Rigidbody2D**: Physics simulation
- **Scripts**: Custom C# behaviors

### Common 2D Components
```csharp
// Transform - Always present
transform.position = new Vector3(x, y, 0);
transform.rotation = Quaternion.Euler(0, 0, angle);
transform.localScale = Vector3.one;

// SpriteRenderer - For 2D graphics
SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
spriteRenderer.sprite = newSprite;
spriteRenderer.color = Color.white;
spriteRenderer.sortingOrder = 1;
```

---

## 🔄 MonoBehaviour Lifecycle

### Execution Order
```
Awake() → OnEnable() → Start() → Update() → LateUpdate() → OnDisable() → OnDestroy()
```

### When to Use Each
- **Awake()**: Component references, initialization
- **Start()**: Dependencies on other objects
- **Update()**: Input handling, game logic
- **FixedUpdate()**: Physics calculations
- **LateUpdate()**: Camera follow, UI positioning

### Example Lifecycle
```csharp
public class LifecycleDemo : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake: Component initialized");
    }

    void Start()
    {
        Debug.Log("Start: Ready to play");
    }

    void Update()
    {
        Debug.Log("Update: Running every frame");
    }
}
```

---

## 🎬 Scene Management

### Scenes
- **Containers** for GameObjects
- **Levels, menus, cutscenes**
- **Build Settings** must include scenes

### SceneManager API
```csharp
using UnityEngine.SceneManagement;

// Load scene by name
SceneManager.LoadScene("Level1");

// Load scene asynchronously
SceneManager.LoadSceneAsync("Level1");

// Get current scene
string currentScene = SceneManager.GetActiveScene().name;
```

### Scene Workflow
1. **Create Scene**: File → New Scene → 2D
2. **Save Scene**: Ctrl+S, name it appropriately
3. **Add to Build**: File → Build Settings → Add Open Scenes
4. **Load Scene**: Use SceneManager in scripts

---

## 🎭 Prefabs

### What are Prefabs?
- **Reusable GameObject templates**
- **Changes propagate** to all instances
- **Efficient** for repeated objects

### Creating Prefabs
1. **Design GameObject** in scene
2. **Drag to Project window**
3. **Prefab created** (blue cube icon)
4. **Modify prefab** affects all instances

### Using Prefabs in Code
```csharp
public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
```

---

## 🐛 Debug Tools

### Console Logging
```csharp
Debug.Log("Info message");
Debug.LogWarning("Warning message");
Debug.LogError("Error message");
Debug.LogFormat("Player {0} has {1} health", name, health);
```

### Gizmos (Scene View)
```csharp
void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, 1f);
    Gizmos.DrawLine(transform.position, target.position);
}
```

### Inspector Debugging
- **Public fields** show in Inspector
- **SerializeField** for private fields
- **Range** attribute for sliders
- **Header** for organization

---

## ⚡ Performance Tips

### Best Practices
- **Use FixedUpdate()** for physics
- **Use Update()** for input and logic
- **Use LateUpdate()** for camera follow
- **Avoid expensive operations** in Update()
- **Use object pooling** for frequent instantiation

### Common Pitfalls
- **Null Reference**: Check if objects exist
- **Memory Leaks**: Destroy instantiated objects
- **Performance**: Profile with Unity Profiler
- **Build Errors**: Check Build Settings

---

## 🔧 Troubleshooting

### Common Issues
- **Scripts not compiling**: Check syntax and file names
- **Objects not visible**: Check camera position and object Z values
- **Scene not loading**: Add scenes to Build Settings
- **Prefabs not working**: Check prefab references

### Debug Steps
1. **Check Console** for errors
2. **Verify component assignments**
3. **Test in Play mode**
4. **Use Debug.Log()** to track execution

---

## 📚 Reference

- **MonoBehaviour Lifecycle**: See `reference/reference1.md`
- **Unity Manual**: GameObject and Component system
- **API Documentation**: Transform, SpriteRenderer, SceneManager
- **Best Practices**: Unity's official guidelines

---

## 🎯 What's Next

Proceed to [Lesson 2: Sprites & Animation](../lesson2-sprites-animation/) to learn about visual game elements and animation systems.

---

## 💡 Key Takeaways

### **From Web/Mobile to Game Development**
- **State Management**: From Redux/Context to Game State
- **Event Handling**: From DOM events to Input System
- **UI Systems**: From HTML/CSS to Unity UI
- **Data Persistence**: From localStorage/AsyncStorage to Save System

### **Game Development Fundamentals**
- **Real-time**: Games run continuously, not event-driven
- **Physics**: Objects interact with realistic physics
- **Performance**: 60+ FPS is critical for good gameplay
- **Player Agency**: Players have direct control over the game world

---

**💡 Tip**: Focus on understanding the component system and lifecycle first. These are the foundations of Unity development!