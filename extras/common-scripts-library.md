# Unity Course - Common Scripts Library

## Essential Unity Scripts for Beginners

> **📁 Code Files**: All scripts are available in the `common-scripts-library/` folder with full implementation.

---

## Player Controllers

### 1. Basic 3D Player Controller

**File**: `Basic3DPlayerController.cs`

- WASD movement
- Mouse look
- Jump mechanics
- Ground checking

### 2. Simple 2D Player Controller

**File**: `Simple2DPlayerController.cs`

- Left/Right movement
- Jump physics
- Animation triggers

### 3. Top-Down Player Controller

**File**: `TopDownPlayerController.cs`

- 4-directional movement
- Rotation towards movement
- Smooth movement

---

## Camera Systems

### 1. Third Person Camera

**File**: `ThirdPersonCamera.cs`

- Follow player smoothly
- Mouse orbit controls
- Collision detection
- Distance adjustment

### 2. 2D Camera Follow

**File**: `Camera2DFollow.cs`

- Smooth following
- Boundary constraints
- Offset positioning

### 3. Simple Camera Shake

**File**: `CameraShake.cs`

- Impact shake effects
- Configurable intensity
- Smooth return to position

---

## Game Management

### 1. Scene Manager

**File**: `SceneTransitionManager.cs`

- Load scenes with loading screen
- Fade transitions
- Progress tracking

### 2. Game State Manager

**File**: `GameStateManager.cs`

- Play/Pause/GameOver states
- State transition logic
- Event system

### 3. Save/Load System

**File**: `SaveLoadManager.cs`

- PlayerPrefs implementation
- JSON save data
- Settings persistence

---

## UI Systems

### 1. Main Menu Controller

**File**: `MainMenuController.cs`

- Button event handling
- Panel transitions
- Settings management

### 2. HUD Manager

**File**: `HUDManager.cs`

- Health bars
- Score display
- Timer systems

### 3. Pause Menu

**File**: `PauseMenuController.cs`

- Game pause/resume
- Settings access
- Return to menu

---

## Audio Systems

### 1. Audio Manager

**File**: `AudioManager.cs`

- Sound effect playing
- Background music
- Volume controls
- Audio mixing

### 2. 3D Spatial Audio

**File**: `SpatialAudioSource.cs`

- Distance-based volume
- 3D positioning
- Doppler effects

---

## Physics and Movement

### 1. Physics-Based Movement

**File**: `PhysicsMovement.cs`

- Rigidbody movement
- Force-based controls
- Air control

### 2. Platform Movement

**File**: `MovingPlatform.cs`

- Waypoint movement
- Player attachment
- Smooth transitions

### 3. Object Launcher

**File**: `ObjectLauncher.cs`

- Projectile physics
- Trajectory calculation
- Object pooling

---

## Interaction Systems

### 1. Collectible System

**File**: `CollectibleItem.cs`

- Trigger-based collection
- Score integration
- Visual/Audio feedback

### 2. Interactable Objects

**File**: `InteractableObject.cs`

- Player proximity detection
- Action prompts
- Event triggering

### 3. Inventory System

**File**: `SimpleInventory.cs`

- Item management
- UI integration
- Persistence

---

## Effects and Animation

### 1. Simple Animator Controller

**File**: `SimpleAnimationController.cs`

- Parameter management
- State transitions
- Event handling

### 2. Particle Effect Trigger

**File**: `ParticleEffectTrigger.cs`

- Effect spawning
- Timing control
- Cleanup management

### 3. Object Rotator

**File**: `ObjectRotator.cs`

- Continuous rotation
- Configurable axes
- Speed controls

---

## Utilities

### 1. Object Pool Manager

**File**: `ObjectPoolManager.cs`

- Performance optimization
- Reusable objects
- Dynamic sizing

### 2. Timer System

**File**: `TimerSystem.cs`

- Countdown timers
- Event triggering
- Multiple timer support

### 3. Debug Helper

**File**: `DebugHelper.cs`

- Visual debugging
- Performance monitoring
- Log management

---

## AI Systems

### 1. Simple AI Follow

**File**: `SimpleAIFollow.cs`

- Player following
- Obstacle avoidance
- State management

### 2. Patrol AI

**File**: `PatrolAI.cs`

- Waypoint patrol
- Player detection
- Alert states

### 3. Simple Enemy AI

**File**: `SimpleEnemyAI.cs`

- Chase behavior
- Attack patterns
- Health system

---

## Usage Guidelines

### Script Integration

1. Copy script to Assets/Scripts folder
2. Attach to appropriate GameObject
3. Configure public variables in Inspector
4. Test functionality in Play mode

### Customization Tips

- Modify public variables to adjust behavior
- Add Debug.Log statements to understand flow
- Extend classes to add more features
- Use inheritance to create variations

### Best Practices

- Always null-check references
- Use meaningful variable names
- Comment complex logic
- Test edge cases
- Optimize performance-critical scripts

---

## Common Issues and Solutions

### NullReferenceException

**Cause**: Missing component or GameObject reference
**Solution**: Check Inspector assignments, add null checks

### Performance Issues

**Cause**: Expensive operations in Update()
**Solution**: Use FixedUpdate, coroutines, or event systems

### Physics Problems

**Cause**: Incorrect Rigidbody settings or collision setup
**Solution**: Review physics components, check collision layers

### UI Not Responding

**Cause**: Missing EventSystem or incorrect Canvas settings
**Solution**: Add EventSystem, check Canvas setup

---

## Learning Path Recommendations

### Beginner Scripts (Sessions 1-2)

- BasicObjectInfo.cs
- SimpleCameraController.cs
- ObjectRotator.cs

### Intermediate Scripts (Sessions 3-4)

- Basic3DPlayerController.cs
- CollectibleItem.cs
- SimpleAnimationController.cs

### Advanced Scripts (Session 5)

- GameStateManager.cs
- AudioManager.cs
- SceneTransitionManager.cs

---

## Extension Ideas

### For Advanced Students

1. **Networking**: MultiPlayer support
2. **Mobile Controls**: Touch input adaptation
3. **VR Integration**: VR controller support
4. **Procedural Generation**: Random level creation
5. **Advanced AI**: Machine learning integration

### Game Genre Specializations

1. **Platformer**: Advanced jump mechanics, level progression
2. **Racing**: Vehicle physics, lap timing
3. **RPG**: Stats system, equipment management
4. **Strategy**: Unit management, resource systems
5. **Puzzle**: Logic systems, solution validation
