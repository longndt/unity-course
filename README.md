# Unity Development Course

## Course Information

- **Target Audience**: Final year students with basic C# programming knowledge
- **Primary Focus**: 2D game development with Unity Engine
- **Objective**: Master 2D game development fundamentals and create complete playable games

## Getting Started

### 🛠️ Step 1: Environment Setup
Before starting the course, complete the environment setup:
- Follow the detailed guide: [`setup/environment-setup.md`](setup/environment-setup.md)
- Install Unity Hub and Unity 6.0 LTS
- Setup Visual Studio or VS Code for C# development
- Configure Git for version control

### 📚 Step 2: Learning Flow
Follow lessons in sequential order for best results:

1. **Lesson 1**: [`lesson1-unity-basics/`](lesson1-unity-basics/) - Start with Unity fundamentals
2. **Lesson 2**: [`lesson2-sprites-animation/`](lesson2-sprites-animation/) - Learn 2D sprites and animation
3. **Lesson 3**: [`lesson3-physics-collision/`](lesson3-physics-collision/) - Master 2D physics system
4. **Lesson 4**: [`lesson4-input-player-controller/`](lesson4-input-player-controller/) - Implement player controls
5. **Lesson 5**: [`lesson5-ui-complete-game/`](lesson5-ui-complete-game/) - Build complete game with UI

### 📖 Each Lesson Contains:
- **Theory**: Comprehensive explanations and concepts
- **Lab**: Hands-on practical exercises
- **Code**: Working examples and reference scripts

### 🚀 Advanced Resources
After completing the core lessons, explore advanced topics:
- **Design Patterns**: [`extras/design-patterns-in-unity.md`](extras/design-patterns-in-unity.md)
- **Performance Optimization**: [`extras/performance-optimization-guide.md`](extras/performance-optimization-guide.md)
- **Additional Resources**: [`extras/readme.md`](extras/readme.md)

## Course Structure

### Lesson 1: Unity Basics & 2D Game Development Fundamentals

- **Main Content**:
  - Introduction to Unity Engine and 2D Game Development
  - Unity Hub and Unity Editor installation
  - Getting familiar with Unity Interface
  - 2D Project setup and Scene management
  - Understanding 2D GameObjects and Sprites
- **Lab**: Create first 2D scene with sprites and basic objects

### Lesson 2: 2D Sprites, Animation & Components

- **Main Content**:
  - Unity Component System for 2D
  - Sprite Renderer and Sprite management
  - 2D Animation System (Animator Controller)
  - Transform Component in 2D space
  - Sorting Layers and Order in Layer
- **Lab**: Create animated 2D character with multiple sprites

### Lesson 3: 2D Physics & Collision Detection

- **Main Content**:
  - Rigidbody2D Component
  - 2D Colliders (Box, Circle, Polygon)
  - Physics Materials 2D
  - Collision Detection vs Trigger in 2D
  - Unity 2D Physics System
- **Lab**: Create 2D platformer physics with jumping mechanics

### Lesson 4: Input System & 2D Player Controller

- **Main Content**:
  - Unity Input System (New Input System)
  - Writing C# scripts for 2D player control
  - 2D Character Controller
  - 2D Camera Follow and Cinemachine
  - 2D Animation Integration
- **Lab**: Create complete 2D player controller with animations

### Lesson 5: UI System & Complete 2D Game

- **Main Content**:
  - Unity UI System (Canvas, UI Elements)
  - Button, Text, Image, and Slider components
  - Event System and UI interactions
  - Scene Management and Game States
  - Audio Integration and Sound Effects
  - Build Settings and publishing 2D games
- **Lab**: Complete 2D platformer game with UI, audio, and build to executable

## Extra Content: 3D Game Development

### Bonus Lesson A: 3D Basics (Optional)

- 3D GameObjects and Mesh components
- 3D Physics and Colliders
- 3D Character Controllers
- Basic 3D scene creation

### Bonus Lesson B: Advanced 3D (Optional)

- 3D Animation and Rigging
- Advanced 3D Physics
- 3D Camera systems
- 3D Lighting and Materials

## Folder Structure

```
unity-course/
├── lesson1-unity-basics/
│   ├── lab/
│   │   └── lab1-instructions.md
│   ├── theory/
│   │   └── theory1.md
│   └── code/
│       ├── TransformBasics.cs
│       ├── CameraControl.cs
│       ├── SceneManagement.cs
│       ├── NamingConventions.cs
│       └── DebugTools.cs
├── lesson2-sprites-animation/
│   ├── lab/
│   │   └── lab2-instructions.md
│   ├── theory/
│   │   └── theory2.md
│   └── code/
│       ├── ComponentLifecycle.cs
│       ├── AnimatorControl.cs
│       ├── SpriteControl.cs
│       ├── Character2D.cs
│       ├── CollisionHandler.cs
│       └── AnimationDebugger.cs
├── lesson3-physics-collision/
│   ├── lab/
│   │   └── lab3-instructions.md
│   ├── theory/
│   │   └── theory3.md
│   └── code/
│       ├── RigidbodyControl.cs
│       ├── ColliderSetup.cs
│       ├── PhysicsMaterialSetup.cs
│       ├── TriggerDetection.cs
│       ├── ForceControl.cs
│       ├── PlayerJump.cs
│       └── AdvancedJump.cs
├── lesson4-input-player-controller/
│   ├── lab/
│   │   └── lab4-instructions.md
│   ├── theory/
│   │   └── theory4.md
│   └── code/
│       ├── InputSystemComparison.cs
│       ├── PlayerInputController.cs
│       ├── AutoInputEvents.cs
│       └── Player2DController.cs
├── lesson5-ui-complete-game/
│   ├── lab/
│   │   └── lab5-instructions.md
│   ├── theory/
│   │   └── theory5.md
│   └── code/
│       ├── UIButton.cs
│       ├── SpecializedButtons.cs
│       ├── UIText.cs
│       ├── HealthBar.cs
│       ├── UISlider.cs
│       ├── UIPanel.cs
│       ├── MainMenuPanel.cs
│       ├── MenuManager.cs
│       └── HUDManager.cs
├── assets-resources/
│   └── common-scripts-library.md
├── guide/
│   ├── study-guide.md
│   └── final-project-guide.md
├── setup/
│   └── environment-setup.md
├── labs/
│   ├── lab1-unity-basics/
│   ├── lab2-sprites-animation/
│   ├── lab3-physics-collision/
│   ├── lab4-input-controller/
│   └── lab5-complete-game/
└── extras/
    ├── readme.md
    ├── performance-optimization-guide.md
    └── design-patterns-in-unity.md
```

```

## System Requirements

- Windows 10/11 or macOS 10.15+
- Unity 6.0 LTS (Unity 6000.0.x) - Latest stable version
- Visual Studio 2022 or Visual Studio Code with C# extension
- Minimum 8GB RAM (16GB recommended)
- DirectX 11/Metal compatible graphics card
- 25GB free disk space

## Key Features of This Course

### 2D Game Development Focus

- ✅ **2D Sprites and Animation**: Complete 2D character animation workflow
- ✅ **2D Physics**: Platformer mechanics with Rigidbody2D and 2D Colliders
- ✅ **Input System**: New Unity Input System for responsive controls
- ✅ **UI/UX Design**: Modern UI patterns for 2D games
- ✅ **Complete Game**: From concept to published executable

### Modern Unity Practices

- ✅ **Unity 6.0**: Latest LTS version with performance improvements
- ✅ **Component-Based Architecture**: Modular, maintainable code
- ✅ **ScriptableObjects**: Data-driven game design
- ✅ **Cinemachine**: Professional camera control
- ✅ **Audio Mixer**: Dynamic audio management

### Learning Outcomes

After completing this course, students will be able to:

1. Create complete 2D games from scratch
2. Implement player controls and game mechanics
3. Design and animate 2D characters
4. Build user interfaces and game menus
5. Publish games to multiple platforms
6. Apply game development best practices

## Next Steps & Advanced Learning

### 🎯 After Course Completion
Once you've mastered the core lessons, enhance your skills with:

**Advanced Topics** (Located in `extras/` folder):
- **Design Patterns in Unity**: [`design-patterns-in-unity.md`](extras/design-patterns-in-unity.md)
  - Singleton, Observer, Command patterns
  - Architecture patterns for larger projects
  - Best practices for maintainable code

- **Performance Optimization**: [`performance-optimization-guide.md`](extras/performance-optimization-guide.md)
  - Memory management and garbage collection
  - Rendering optimization techniques
  - Profiler usage and bottleneck identification

- **Additional Resources**: [`extras/readme.md`](extras/readme.md)
  - Extended learning materials
  - Community resources and tutorials
  - Project ideas for portfolio development

### 📈 Recommended Learning Path
1. ✅ Complete all 5 core lessons
2. 🔄 Build your own 2D game project
3. 📚 Study advanced topics in `extras/`
4. 🚀 Explore 3D development (Bonus lessons)
5. 🌟 Contribute to open-source Unity projects

## References

- Unity Official Documentation
- Unity Learn Platform
- C# Programming Guide
```
