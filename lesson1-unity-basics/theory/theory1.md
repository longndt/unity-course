# Theory 01: Unity 2D Basics

## Learning Objectives

After completing this lesson, students will be able to:
- Understand Unity Engine and its applications in 2D game development
- Get familiar with the Unity Editor interface
- Master basic concepts of 2D GameObjects
- Use Sprite Renderer and manage Sprites
- Understand the Transform system in 2D space

---

## 1. Introduction to Unity Engine

### What is Unity Engine?

Unity is a cross-platform **game engine** developed by Unity Technologies. It is one of the most popular game development tools available today.

### Why Choose Unity for 2D Game Development?

**Advantages:**
- ✅ **Easy to Learn**: Intuitive interface with large community support
- ✅ **Cross-Platform**: Easy deployment to PC, Mobile, Web, Console
- ✅ **2D Native Support**: Built-in 2D graphics and physics support
- ✅ **Visual Scripting**: Can code with C# or visual scripting
- ✅ **Asset Store**: Massive library of resources

**Disadvantages:**
- ❌ Build files are relatively large compared to specialized 2D engines
- ❌ Requires understanding of Component System for effective use

### Unity 2D vs 3D

| Aspect | Unity 2D | Unity 3D |
|--------|----------|----------|
| **Camera** | Orthographic | Perspective |
| **Physics** | Physics2D (Box2D) | Physics3D |
| **Rendering** | Sprite Renderer | Mesh Renderer |
| **Coordinates** | X, Y | X, Y, Z |
| **Lighting** | 2D Lights | 3D Lights |

---

## 2. Unity Hub and Unity Editor

### Unity Hub

Unity Hub is the **management tool** for Unity versions and projects.

**Main Features:**
- 📁 **Projects**: Manage all Unity projects
- 🔧 **Installs**: Install and manage Unity versions
- 🎓 **Learn**: Access tutorials and learning resources
- 👥 **Community**: Connect with Unity community

### Unity Editor Interface

Unity Editor consists of main **panels (windows)**:

#### 2.1 Scene View
- **Purpose**: View and edit scene during development
- **Controls**:
  - `Middle Mouse`: Pan (move camera)
  - `Mouse Wheel`: Zoom in/out
  - `Alt + Left Mouse`: Orbit (only in 3D mode)

#### 2.2 Game View
- **Purpose**: View game as player will see it
- **Settings**:
  - **Aspect Ratio**: Free Aspect, 16:9, 16:10, etc.
  - **Resolution**: Test game resolution

#### 2.3 Hierarchy
- **Purpose**: Display all GameObjects in current scene
- **Structure**: Tree hierarchy (parent-child relationships)

#### 2.4 Project
- **Purpose**: Manage all assets in project
- **Folders**: Scripts, Sprites, Audio, Materials, etc.

#### 2.5 Inspector
- **Purpose**: Display properties and components of selected object
- **Function**: Edit values, add/remove components

#### 2.6 Console
- **Purpose**: Display logs, warnings, errors from scripts
- **Types**:
  - `Debug.Log()`: Information
  - `Debug.LogWarning()`: Warning
  - `Debug.LogError()`: Error

---

## 3. 2D Project Setup

### Template Selection

When creating a new project, choose **"2D (URP)"** template:

**2D (URP) includes:**
- ✅ Scene View in 2D mode
- ✅ Orthographic Camera setup
- ✅ 2D Physics enabled
- ✅ Universal Render Pipeline optimized for 2D
- ✅ 2D Lighting system

### Project Structure Best Practices

```
Assets/
├── Art/
│   ├── Characters/
│   ├── Environment/
│   ├── UI/
│   └── Effects/
├── Audio/
│   ├── Music/
│   ├── SFX/
│   └── Voice/
├── Scripts/
│   ├── Player/
│   ├── Enemies/
│   ├── UI/
│   └── Managers/
├── Scenes/
├── Prefabs/
└── Materials/
```

---

## 4. GameObjects and Components

### GameObject

**GameObject** is the basic **building block** of Unity:
- 📦 Container that holds **Components**
- 🔗 Can have **parent-child relationships**
- 📍 Has **Transform component** by default

### Component System

Unity uses **Entity-Component-System (ECS)** architecture:

```
GameObject = Entity
├── Transform Component (required)
├── Sprite Renderer Component
├── Box Collider 2D Component
└── Custom Script Component
```

### Common 2D Components

#### 4.1 Transform
- **Position**: Position in world space (X, Y, Z)
- **Rotation**: Rotation angle (degrees)
- **Scale**: Size scale (X, Y, Z)

```csharp
// Access Transform in code
Transform myTransform = transform;
myTransform.position = new Vector3(5f, 2f, 0f);
myTransform.localScale = new Vector3(2f, 2f, 1f);
```

#### 4.2 Sprite Renderer
- **Sprite**: 2D image to display
- **Color**: Color tint applied to sprite
- **Sorting Layer**: Layer for render order arrangement
- **Order in Layer**: Order within same layer

---

## 5. Sprites and 2D Graphics

### What is a Sprite?

**Sprite** is a **2D image/texture** used in 2D games:
- 🖼️ **Single Sprite**: One individual image
- 📋 **Sprite Sheet**: Multiple sprites in one file
- 🎬 **Atlas**: Collection of optimized sprites

### Sprite Import Settings

When importing images into Unity, configure:

#### 5.1 Texture Type
- **Sprite (2D and UI)**: For 2D sprites
- **Default**: For regular textures

#### 5.2 Pixels Per Unit (PPU)
- **Definition**: Number of pixels corresponding to 1 Unity unit
- **Default**: 100 PPU
- **Example**: 100x100 pixel sprite = 1x1 Unity units

#### 5.3 Filter Mode
- **Point (no filter)**: Pixel art, retro games
- **Bilinear**: Smooth scaling
- **Trilinear**: Smooth with mipmaps

#### 5.4 Compression
- **None**: Highest quality, large file size
- **Low Quality**: High compression, low quality
- **Normal Quality**: Balance between quality and size

---

## 6. 2D Coordinate System

### World Space vs Screen Space

#### World Space
- **Center**: (0, 0) at center of scene
- **Unit**: Unity units (not pixels)
- **X Axis**: Left (-) → Right (+)
- **Y Axis**: Down (-) → Up (+)
- **Z Axis**: Far (-) → Near (+) to camera

#### Screen Space
- **Center**: (0, 0) at bottom-left of screen
- **Unit**: Pixels
- **Resolution dependent**: Depends on resolution

### Camera Setup for 2D

#### Orthographic vs Perspective
- **Orthographic**: No perspective distortion, parallel projection
- **Perspective**: 3D depth, far objects smaller than near objects

#### Orthographic Size
- **Definition**: Half-height of camera view in Unity units
- **Example**: Size = 5 → camera sees from -5 to +5 on Y axis

```csharp
// Change camera size in code
Camera.main.orthographicSize = 8f;
```

---

## 7. Sorting and Layering

### Sorting Layers

**Sorting Layers** determine render order between object groups:

#### Creating Sorting Layers:
1. **Edit** → **Project Settings** → **Tags and Layers**
2. **Sorting Layers** section
3. **Add** layers in order: Background → Environment → Player → UI

#### Common Sorting Layer Setup:
```
Background     (Order: 0)
Environment    (Order: 1)
Enemies        (Order: 2)
Player         (Order: 3)
Effects        (Order: 4)
UI             (Order: 5)
```

### Order in Layer

**Order in Layer** determines render order within same Sorting Layer:
- **Higher values**: Render later (on top)
- **Lower values**: Render earlier (behind)
- **Range**: -32768 to 32767

---

## 8. Scene Management

### What is a Scene?

**Scene** is a **level or area** in the game:
- 🏠 **Main Menu**: Scene for main menu
- 🎮 **Game Level**: Scene for gameplay
- 🏆 **Game Over**: Scene when game ends

### Scene Operations

#### 8.1 Create Scene
```csharp
// Create new scene
File → New Scene
// Or Ctrl+N
```

#### 8.2 Save Scene
```csharp
// Save current scene
File → Save
// Or Ctrl+S
```

#### 8.3 Load Scene
```csharp
// Load scene in code
using UnityEngine.SceneManagement;

SceneManager.LoadScene("SceneName");
```

### Build Settings

**Build Settings** manage scenes to be built:
1. **File** → **Build Settings**
2. **Add Open Scenes**: Add current scene
3. **Drag & Drop**: Drag scenes from Project window
4. **Scene Index**: Order of scenes (scene 0 is first scene)

---

## 9. Best Practices for 2D Development

### 9.1 Asset Organization

```
📁 Structured Folders:
├── 📁 Art/
│   ├── 📁 Characters/
│   │   ├── player_idle.png
│   │   └── player_run.png
│   ├── 📁 Environment/
│   │   ├── background.png
│   │   └── tiles.png
│   └── 📁 UI/
│       ├── button.png
│       └── icon.png
├── 📁 Scripts/
│   ├── PlayerController.cs
│   └── GameManager.cs
└── 📁 Scenes/
    ├── MainMenu.unity
    └── GameLevel.unity
```

### 9.2 Naming Conventions

**GameObjects:**
```
PascalCase: PlayerCharacter, MainCamera, GameManager
```

**Scripts:**
```
PascalCase: PlayerController.cs, HealthSystem.cs
```

**Variables:**
```csharp
// Public fields: PascalCase
public float MovementSpeed;
public GameObject PlayerPrefab;

// Private fields: camelCase
private bool isGrounded;
private int currentHealth;
```

### 9.3 Performance Tips

#### Sprite Optimization:
- ✅ **Atlas textures** when possible
- ✅ **Power of 2** sizes (64x64, 128x128, 256x256)
- ✅ **Appropriate compression** settings
- ✅ **Disable Read/Write** if not needed

#### Scene Optimization:
- ✅ **Static batching** for non-moving objects
- ✅ **Object pooling** for frequently created/destroyed objects
- ✅ **Culling** objects outside camera view

---

## 10. Troubleshooting and Debugging

### Common Issues

#### 10.1 Sprite not visible
**Possible causes:**
- ❌ Missing Sprite Renderer component
- ❌ Empty Sprite field
- ❌ Wrong Sorting Layer/Order
- ❌ Camera not seeing object

**Solution:**
```csharp
// Check in Inspector:
1. Sprite Renderer component exists?
2. Sprite field assigned?
3. Color alpha = 1?
4. Correct Sorting Layer?
```

#### 10.2 Objects not interactive
**Possible causes:**
- ❌ Missing Collider component
- ❌ No Rigidbody2D for physics
- ❌ Layer collision matrix settings

### Debug Tools

#### Console Logs:
```csharp
Debug.Log("Player position: " + transform.position);
Debug.LogWarning("Health is low!");
Debug.LogError("Player not found!");
```

#### Gizmos:
```csharp
void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, 1f);
}
```

---

## Chapter Summary

### Core Knowledge:
1. ✅ **Unity Editor Interface**: Scene, Game, Hierarchy, Project, Inspector
2. ✅ **GameObject-Component System**: How Unity organizes objects
3. ✅ **2D Coordinate System**: World space, screen space, camera setup
4. ✅ **Sprites**: Import, configure, render 2D graphics
5. ✅ **Sorting System**: Layers and order to control render order
6. ✅ **Scene Management**: Create, save, load scenes

### Preparation for Next Lesson:
- 🎬 **Animation System**: Create animations for 2D characters
- 🎮 **Component Scripting**: Write C# scripts to control behavior
- 🔄 **State Management**: Manage character states (idle, walk, jump)

### Practice:
Complete **Lab 01** to apply all knowledge learned about creating your first 2D scene with sprites and basic objects.