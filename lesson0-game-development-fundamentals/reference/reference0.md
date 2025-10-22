# Lesson 0 Reference - Game Development Fundamentals

## Web/Mobile vs Game Development

### Web Development Pattern
```javascript
// Event-driven, state-based
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

### Mobile Development Pattern
```swift
// App lifecycle, touch events
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

### Game Development Pattern
```csharp
// Real-time simulation, continuous updates
public class GameComponent : MonoBehaviour
{
    void Start() {
        // Initialize once
    }

    void Update() {
        // Update every frame (60+ FPS)
    }

    void FixedUpdate() {
        // Physics simulation (50 FPS)
    }
}
```

## Game Development Pipeline

### Pre-Production
- Game Design Document
- Technical Requirements
- Art Style Guide
- Prototype

### Production
- Asset Creation
- Programming
- Level Design
- Testing

### Post-Production
- Optimization
- Polish
- Release
- Support

## Core Gameplay Loop

```
Input → Process → Output → Feedback
  ↑                           ↓
  ←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←←
```

## Unity Editor Windows

- **Scene View**: 3D/2D world editor
- **Game View**: Player perspective
- **Hierarchy**: Object organization
- **Inspector**: Properties and components
- **Project**: Asset files
- **Console**: Debug messages

## Game Design Concepts

### Player Agency
- **Choice**: Multiple approaches
- **Consequence**: Meaningful results
- **Mastery**: Skill development
- **Expression**: Personal style

### Game Mechanics
- **Core**: Primary actions (move, jump, shoot)
- **Secondary**: Supporting systems (inventory, dialogue)
- **Meta**: Progression, rewards, unlocks

## Performance Targets

- **60 FPS**: Smooth gameplay
- **Memory**: Avoid GC spikes
- **Assets**: Compress textures/audio
- **Platform**: Test on target devices

## Common Pitfalls

- **Over-engineering**: Start simple
- **Ignoring performance**: 60 FPS is critical
- **Poor feedback**: Players need clear responses
- **Complex controls**: Keep it intuitive