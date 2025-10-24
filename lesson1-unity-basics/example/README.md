# Lesson 1 Example: Unity Fundamentals

## 🎯 What This Example Teaches

This example demonstrates Unity's core concepts:
- **GameObject/Component System**: How Unity organizes game objects
- **MonoBehaviour Lifecycle**: Awake, Start, Update execution order
- **Scene Management**: Loading and switching between scenes
- **Debug Tools**: Using Console, Gizmos, and Debug.Log
- **Transform Operations**: Moving, rotating, and scaling objects

## 🚀 How to Use This Example

### Step 1: Setup the Scene
1. Create a new 2D scene in Unity
2. Create several empty GameObjects with different names
3. Add the example scripts to different GameObjects

### Step 2: Add the Scripts
1. **TransformBasics.cs** → Add to a GameObject to test movement
2. **CameraControl.cs** → Add to Main Camera for camera controls
3. **SceneManagement.cs** → Add to an empty GameObject for scene switching
4. **DebugTools.cs** → Add to any GameObject for debug utilities
5. **NamingConventions.cs** → Reference for proper naming

### Step 3: Test Each Component
1. **TransformBasics**: Use arrow keys to move the object
2. **CameraControl**: Use mouse to control camera
3. **SceneManagement**: Press keys to switch scenes
4. **DebugTools**: Check Console for debug messages

### Step 4: Observe the Lifecycle
1. Press Play and watch the Console
2. Notice the order: Awake → Start → Update
3. Try enabling/disabling GameObjects to see OnEnable/OnDisable

## 🔧 Troubleshooting

**Scripts don't work**: Make sure all required components are attached
**Console errors**: Check that scenes exist for SceneManagement
**No movement**: Verify Input System is enabled
**Lifecycle issues**: Check Console for execution order

## 💡 Learning Points

- **GameObject**: Container for components
- **Component**: Modular functionality (Transform, Script, etc.)
- **MonoBehaviour**: Base class for Unity scripts
- **Lifecycle**: Awake → Start → Update → LateUpdate
- **Scene Management**: Loading and switching scenes
- **Debug Tools**: Console, Gizmos, Debug.Log
