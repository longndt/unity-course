# Lab 1: Unity Fundamentals & Project Setup

## 🎯 Learning Objectives

- Set up a 2D project and navigate the Unity Editor efficiently
- Understand GameObject/Component model and MonoBehaviour lifecycle
- Compare game development patterns with web/mobile development
- Create and use prefabs; manage scenes and scene loading
- Use simple debug tools (Gizmos, Logs) to inspect behavior

## 🎮 Playtest Criteria

**Complete when you can:**
- [ ] Create a 2D project and navigate Unity Editor confidently
- [ ] Build a scene with 3+ GameObjects using different components
- [ ] Create a prefab and instantiate it in the scene
- [ ] Switch between 2 scenes using SceneManager
- [ ] Use Debug.Log() to track MonoBehaviour lifecycle order
- [ ] Scene runs without errors and displays correctly in Game view

---

## 🚀 Quick Start

### Step 1: Create New 2D Project

1. Open Unity Hub → New Project → **2D (URP)** template
2. Project name: `Lesson1-Fundamentals`
3. Create project and wait for Unity to load

### Step 2: Explore the Example

1. Open the `example/` folder in your lesson
2. Import the provided scripts into your project
3. Create a new scene: `File → New Scene → 2D`
4. Add the example scripts to GameObjects and test them

---

## 🎯 Lab Tasks

### Task 1: Web/Mobile vs Game Development Analysis

1. **Compare Development Patterns**
   - Think about a web app you've built (e.g., todo list, blog)
   - Think about a mobile app you've used (e.g., social media, productivity)
   - Compare with the Unity game development pattern

2. **Document Key Differences**
   - **Web**: Event-driven, state management, request/response
   - **Mobile**: App lifecycle, touch events, platform-specific
   - **Game**: Real-time simulation, physics, player agency

3. **Create a simple comparison chart**
   - Use a text file or draw on paper
   - Note how each platform handles user interaction
   - Identify which concepts transfer between platforms

### Task 2: MonoBehaviour Lifecycle Demo

1. Create an empty GameObject named "LifecycleDemo"
2. Add the `TransformBasics.cs` script from `example/`
3. Press Play and observe the Console logs
4. **Verify**: You see Awake → Start → Update messages in order
5. **Compare**: How does this differ from web/mobile lifecycle?

### Task 3: Scene Management

1. Create a second scene: `File → New Scene → 2D`
2. Save it as "Scene2"
3. Add the `SceneManagement.cs` script to a GameObject
4. Create a UI Button that switches between scenes
5. **Verify**: Button successfully loads the other scene

### Task 4: Prefab Creation

1. Create a simple GameObject with a Sprite Renderer
2. Drag it to the Project window to create a prefab
3. Use `Instantiate()` in a script to spawn the prefab
4. **Verify**: Prefab spawns when you press a key or click

### Task 5: Debug Tools

1. Add the `DebugTools.cs` script to a GameObject
2. Use the Gizmos to visualize object positions
3. Add Debug.Log statements to track object behavior
4. **Verify**: Gizmos appear in Scene view, logs appear in Console

## ✅ Completion Checklist

- [ ] **Web/Mobile Analysis**: Documented key differences between platforms
- [ ] **Project Setup**: 2D project created and configured
- [ ] **Lifecycle Demo**: Console shows proper execution order
- [ ] **Scene Switching**: Can navigate between 2 scenes
- [ ] **Prefab System**: Created and instantiated prefabs
- [ ] **Debug Tools**: Gizmos and logs working correctly
- [ ] **No Errors**: Console shows no compilation or runtime errors

## ✅ What's Next

Proceed to [Lesson 2: Sprites & Animation](../lesson2-sprites-animation/) to learn about animation systems and sprite management.

---

## 📚 Reference

- **MonoBehaviour Lifecycle**: See `reference/reference1.md`
- **Scene Management**: Unity's SceneManager API
- **Prefab Workflow**: Creating and using prefabs
- **Debug Tools**: Gizmos and Console logging

---

## 🔧 Troubleshooting

**Issue**: Scripts not compiling
**Fix**: Check that scripts are in the correct folder and have proper C# syntax

**Issue**: Scene switching not working
**Fix**: Ensure both scenes are added to Build Settings (File → Build Settings)

**Issue**: Prefabs not instantiating
**Fix**: Check that the prefab reference is assigned in the script

**Issue**: Gizmos not visible
**Fix**: Enable Gizmos in Scene view toolbar and check the script's OnDrawGizmos method