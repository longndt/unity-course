# Unity Course - LongNDT

## Course Overview

This course teaches 2D game development with Unity from the ground up. Perfect for beginners with web/mobile development experience who want to learn game development.

**Format**: Light theory, hands-on practice, and project-based learning

---

## Prerequisites

- **C# Programming**: Classes, methods, events, properties
- **Unity Hub**: Latest version for project management
- **Unity 6 LTS**: Latest Long Term Support version
- **IDE**: Visual Studio 2022, VS Code, or JetBrains Rider
- **Git**: Version control (optional but recommended)
- **Helpful but not required**: Web/mobile development experience
- **Optional**: Basic understanding of physics and animation concepts

### **System Requirements**
- **Windows**: Windows 10/11 (64-bit), 8GB RAM, DX11 compatible GPU
- **macOS**: macOS 12+ (Monterey/Sonoma), 8GB RAM, Metal compatible GPU
- **Storage**: 25GB free space for Unity and projects

---

## What You Will Learn

- Build complete 2D game slices with Unity
- Understand GameObject/Component architecture and MonoBehaviour lifecycle
- Create 2D sprite workflows and animation state machines
- Implement physics-based mechanics and robust collisions
- Use the new Input System for responsive player control
- Build UI/HUD, menus, and gameplay state management
- Profile and optimize builds for target platforms

---

## 📚 Course Structure & Learning Path

### **🎯 Learning Flow Overview**
```
Lesson 0 (Fundamentals) → Lesson 1 (Basics) → Lesson 2 (Sprites) → 
Lesson 3 (Physics) → Lesson 4 (Input) → Lesson 5 (Complete Game)
```

### **📖 Detailed Course Structure**

#### **Lesson 0: Game Development Fundamentals & Mindset**
- **🎯 Purpose**: Bridge from web/mobile to game development
- **📚 Topics**: Game design basics, player experience, Unity Editor overview
- **🎮 Project**: Simple "Hello World" bouncing ball game
- **🔗 Path**: `lesson0-game-fundamentals/`

#### **Lesson 1: Unity Fundamentals & Project Setup**
- **🎯 Purpose**: Master Unity's core architecture
- **📚 Topics**: Editor, scenes, prefabs, MonoBehaviour lifecycle
- **🎮 Project**: Scene management system with prefab spawning
- **🔗 Path**: `lesson1-unity-basics/`

#### **Lesson 2: Sprites & Animation**
- **🎯 Purpose**: Master 2D visual systems and animation
- **📚 Topics**: Import pipeline, sorting layers, Animator Controller, animation events
- **🎮 Project**: Complete character animation system with idle/walk/jump/attack
- **🔗 Path**: `lesson2-sprites-animation/`

#### **Lesson 3: Physics & Collision**
- **🎯 Purpose**: Implement responsive physics mechanics
- **📚 Topics**: Rigidbody2D, colliders, materials, layers, FixedUpdate, raycast
- **🎮 Project**: 2D platformer with advanced jump mechanics (coyote time, variable jump)
- **🔗 Path**: `lesson3-physics-collision/`

#### **Lesson 4: Input & Player Controller**
- **🎯 Purpose**: Create responsive player controls
- **📚 Topics**: Input System actions, PlayerInput, rebinding, camera follow
- **🎮 Project**: Advanced character controller with gamepad and keyboard support
- **🔗 Path**: `lesson4-input-player-controller/`

#### **Lesson 5: UI, Gameplay Loop & Build**
- **🎯 Purpose**: Complete game development cycle
- **📚 Topics**: UGUI/UIToolkit, HUD, menus, pause, save/load, build pipeline
- **🎮 Project**: Complete vertical slice from main menu → gameplay → results
- **🔗 Path**: `lesson5-ui-complete-game/`

---

## 🗺️ Navigation & Learning Flow

### **📋 How to Use This Course**

#### **🎯 For Complete Beginners:**
1. **Start Here**: `lesson0-game-fundamentals/` - Learn game development mindset
2. **Follow Sequence**: Complete lessons 0→1→2→3→4→5 in order
3. **Study Materials**: Read theory → Study examples → Complete labs
4. **Build Projects**: Use sample projects as reference and inspiration

#### **🎯 For Experienced Developers:**
1. **Skip to Basics**: `lesson1-unity-basics/` - Focus on Unity-specific concepts
2. **Jump Around**: Use lessons as reference for specific topics
3. **Sample Projects**: Study `sample-projects/` for complete implementations
4. **Quick Reference**: Use `extras/` for advanced topics and troubleshooting

#### **🎯 Learning Path Options:**
- **🎮 Project-First**: Start with `sample-projects/` → Study theory → Build your own
- **📚 Theory-First**: Read `theory/` → Study `example/` → Complete `lab/`
- **🔧 Problem-Solving**: Use `extras/troubleshooting_guide.md` → Find relevant lesson

---

## 📁 Lesson Structure

Each lesson follows a standardized structure designed for effective learning:

```
lesson-topic/
├──  reference/          # Quick reference codes & checklists
├──  example/            # Working code examples
├──  theory/             # Light documentation (single theoryX.md)
└──  lab/                # Hands-on playtest tasks
```

Note: All lesson folders now use the standardized `example/` structure.

---

## 🗺️ Visual Diagrams

- Game Loop & Execution Order
- Animator Flow & State Machine
- Physics Update & Collision Matrix
- Input Flow (devices → actions → gameplay/UI)
- UI Navigation & Gameplay States
- Build Pipeline (targets, profiles, compression)

---

## 📚 How to Study This Course Effectively

### Step 1: Start with Reference
- Skim `reference/` to see APIs and checklists used in the lesson

### Step 2: Explore Working Example
- Open the lesson `example/` and run the sample scene
- Playtest first, then peek into scripts structure

### Step 3: Read Theory as Reference
- Read only the sections related to what you're implementing
- Jump between theory ↔ example ↔ reference

### Step 4: Code Along
- Recreate the example features in your own scene
- Test frequently and iterate in small steps

### Step 5: Complete Lab
- Follow playtest criteria to validate features (measurable outcomes)

### Step 6: Review & Reflect
- Compare with example, note pitfalls, create personal cheat sheets

---

## 🚀 Getting Started

### Step 1: Check and Install Development Environment
- Read `extras/environment-setup.md` for Unity Hub, Unity 6 LTS, IDE, Git

### Step 2: Open the Project
- Open this folder in Unity Hub and launch with Unity 6 LTS

### Step 3: Recommended Learning Path
- Lesson 0 → Lesson 1 → Lesson 2 → Lesson 3 → Lesson 4 → Lesson 5

---

## 💡 Learning Tips

- Playtest early and often; optimize later
- Use `reference/` for API patterns; keep theory light
- Prefer `FixedUpdate` for physics, `Update` for input sampling
- Profile builds on the target device before shipping

---

## 📚 Course Resources

### **Learning Materials**
- **Learning Path**: `extras/learning-path.md` - Visual course journey
- **Environment Setup**: `extras/environment-setup.md` - Complete setup guide
- **Study Guide**: `extras/study-guide.md` - How to study effectively

### **Code & Examples**
- **Common Scripts Library**: `extras/common-scripts-library.md` - Reusable code library
- **Free Assets Resources**: `extras/free-assets-resources.md` - Free asset sources and integration guide

### **Additional Resources**
- **Design Patterns**: `extras/design-patterns.md` - Common design patterns for game development
- **Performance Optimization**: `extras/performance-optimization.md` - Advanced optimization techniques
- **Troubleshooting Guide**: `extras/troubleshooting_guide.md` - Common issues and solutions
- **All Extras**: `extras/readme.md` - Complete resource overview

---

## Next Steps

- Start with `lesson0-game-fundamentals/` to understand game development mindset
- Proceed to `lesson1-unity-basics/` for technical Unity fundamentals
- Continue through all lessons in sequence

