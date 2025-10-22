# Lesson 1: Unity Fundamentals & Setup

## Overview

**Difficulty**: Beginner
**Prerequisites**: Lesson 0 completed, Basic C#, Unity Hub + Unity 6 LTS installed

This lesson introduces Unity's technical fundamentals: Editor, scenes, prefabs, and MonoBehaviour lifecycle. You'll understand how game development differs from web/mobile development and build a small playable scene.

---

## 🎯 Learning Objectives

- Set up a 2D project and navigate the Unity Editor efficiently
- Understand GameObject/Component model and MonoBehaviour lifecycle (Awake/Start/Update)
- Create and use prefabs; manage scenes and scene loading
- Use simple debug tools (Gizmos, Logs) to inspect behavior

---

## 🚀 Quick Start

### Step 1: Create New 2D Project
1. Open Unity Hub → New Project → **2D (URP)** template
2. Project name: `Lesson1-UnityBasics`
3. Create project and wait for Unity to load

### Step 2: Create Test Scene
1. Create a scene named `Lesson1-Scene`
2. Save scene: `File → Save Scene As → Lesson1-Scene`

### Step 3: Add Example Scripts
1. Open the `example/` folder in this lesson
2. Import scripts into your project's Scripts folder
3. Add empty GameObjects and attach scripts:
   - `TransformBasics.cs`, `CameraControl.cs`, `SceneManagement.cs`, `DebugTools.cs`

### Step 4: Test Your Setup
1. **Press Play** and observe logs for lifecycle order
2. **Check Console** for debug messages
3. **Try switching scenes** using the SceneManagement script
4. **Verify movement** and camera controls work

---

## 📚 Learning Path

- Reference → `reference/` (APIs, checklists) [to be added]
- Example → `example/` (run and playtest first)
- Theory → `theory/theory1.md` (read targeted sections)
- Lab → `lab/lab1-instructions.md` (complete playtest tasks)

---

## ✅ What's Next

Proceed to [Lesson 2: Sprites & Animation](../lesson2-sprites-animation/) to learn about visual game elements and animation systems.

---

## Resources & References

- Unity Manual: Getting started
- Execution Order of Event Functions
- Scenes and SceneManager API
- Prefabs workflow


