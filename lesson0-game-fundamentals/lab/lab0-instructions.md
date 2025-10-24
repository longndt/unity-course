# Lab 0: Game Development Fundamentals & Mindset - Enhanced Instructions

## 🎯 Learning Objectives

- Understand the key differences between web/mobile and game development
- Learn basic game development concepts and terminology
- Navigate Unity Editor for the first time
- Create a simple bouncing ball game
- Understand the game development workflow

## 🎮 Playtest Criteria

**Complete when you can:**
- [ ] Explain the key differences between web/mobile and game development
- [ ] Navigate Unity Editor confidently for game development
- [ ] Create a simple bouncing ball game
- [ ] Understand the game development pipeline
- [ ] Identify core gameplay loop in a game

---

## 🚀 Quick Start

### Step 1: Create New 2D Project

1. **Open Unity Hub** → Click **"New project"**
2. **Select Template**: Choose **"2D (URP)"** template
3. **Project Name**: `Lesson0-GameFundamentals`
4. **Location**: Choose your preferred folder
5. **Click "Create project"** and wait for Unity to load

> **💡 Pro Tip**: The URP (Universal Render Pipeline) template provides better 2D performance and modern rendering features.

### Step 2: Explore the Example

1. **Open the `example/` folder** in this lesson
2. **Import the provided scripts** into your project:
   - Copy scripts to `Assets/Scripts/` folder
   - Unity will automatically compile them
3. **Create a new scene**: `File → New Scene → 2D`
4. **Add the example scripts** to GameObjects and test them

---

## 🎯 Lab Tasks

### Task 1: Web/Mobile vs Game Development Analysis

#### **1.1 Compare Development Patterns**

**Think about a web app you've built (e.g., todo list, blog):**
- How does it handle user interaction?
- What happens when a user clicks a button?
- How does it manage state and data?

**Think about a mobile app you've used (e.g., social media, productivity):**
- How does it respond to touch gestures?
- What happens when you switch between screens?
- How does it handle background/foreground states?

**Compare with a game you've played (e.g., platformer, puzzle):**
- How does the game respond to your input?
- What happens continuously while you play?
- How does the game world change over time?

#### **1.2 Document Key Differences**

Create a comparison chart in a text file:

```
Web Development:
- Event-driven: User clicks → something happens → done
- State management: Data changes drive UI updates
- Request/Response: Server communication patterns
- UI-centric: Interface is the primary concern

Mobile Development:
- App lifecycle: Activities manage screens
- Touch events: Gesture-based interactions
- Platform-specific: Android/iOS differences
- Resource management: Memory and battery optimization

Game Development:
- Real-time simulation: Game runs continuously at 60+ FPS
- Physics-driven: Objects move and interact realistically
- Player control: Player directly controls what happens
- Immersive experience: Full attention and engagement
```

#### **1.3 Identify Transferable Concepts**

**What concepts transfer between platforms?**
- Object-oriented programming
- Event handling
- State management
- User interface design
- Performance optimization

**What's unique to game development?**
- Real-time simulation
- Physics simulation
- Continuous input processing
- Frame-rate dependent logic

### Task 2: Unity Editor Navigation

#### **2.1 Explore Key Windows**

**Scene View (Top Left) - Your Level Editor:**
1. **Enable 2D Mode**: Click the **2D** button in the toolbar
2. **Navigate**: 
   - **Mouse Wheel**: Zoom in/out
   - **Right-click + Drag**: Pan around
   - **Alt + Left-click + Drag**: Orbit (not needed for 2D)
3. **Grid**: Right-click the **Grid** button to adjust settings

**Game View (Top Right) - What Players See:**
1. **Click Play**: See your game in action
2. **Aspect Ratio**: Test different screen sizes
3. **Stats**: Check performance information

**Hierarchy (Bottom Left) - Object Organization:**
1. **Right-click**: Create new GameObjects
2. **Select objects**: Click to select in scene
3. **Parent/Child**: Drag objects to create hierarchy

**Project (Bottom Center) - Asset Files:**
1. **Browse folders**: Navigate your project files
2. **Import assets**: Drag files from Windows Explorer
3. **Search**: Find assets quickly

**Inspector (Right Side) - Object Properties:**
1. **Select an object**: See its components
2. **Modify values**: Change properties in real-time
3. **Add components**: Click "Add Component"

**Console (Bottom Right) - Debug Messages:**
1. **Check for errors**: Red messages indicate problems
2. **Debug output**: Your Debug.Log() messages appear here
3. **Clear console**: Right-click to clear messages

#### **2.2 Practice Basic Operations**

**Create and Modify Objects:**
1. **Right-click in Hierarchy** → **2D Object** → **Sprite** → **Square**
2. **Select the square** in Hierarchy
3. **In Inspector**, modify:
   - **Transform**: Position (X: 0, Y: 0, Z: 0)
   - **Sprite Renderer**: Color (choose any color)
   - **Scale**: (2, 2, 1) to make it bigger

**Move Objects Around:**
1. **Select the square** in Hierarchy
2. **Press W** (Move tool) or click the Move tool in toolbar
3. **Drag the arrows** in Scene view to move the object
4. **Try different positions** and see how it affects the Game view

**Delete and Duplicate:**
1. **Select the square** in Hierarchy
2. **Press Delete** to remove it
3. **Right-click in Hierarchy** → **Create Empty**
4. **Select the empty GameObject** and **Ctrl+D** to duplicate

#### **2.3 Verify Understanding**

**Test your knowledge:**
- Can you explain what each window does?
- Can you create and modify objects confidently?
- Do you understand the component system?
- Can you navigate the Scene view smoothly?

### Task 3: Create a Simple Bouncing Ball Game

#### **3.1 Setup the Scene**

**Create the Ground:**
1. **Right-click in Hierarchy** → **2D Object** → **Sprite** → **Square**
2. **Rename** to "Ground"
3. **In Inspector**:
   - **Transform**: Position (0, -4, 0), Scale (20, 1, 1)
   - **Sprite Renderer**: Color (Green)
4. **Add Component** → **Box Collider 2D**

**Create the Paddle:**
1. **Right-click in Hierarchy** → **2D Object** → **Sprite** → **Square**
2. **Rename** to "Paddle"
3. **In Inspector**:
   - **Transform**: Position (0, -3, 0), Scale (3, 0.5, 1)
   - **Sprite Renderer**: Color (Blue)
4. **Add Component** → **Box Collider 2D**

**Create the Ball:**
1. **Right-click in Hierarchy** → **2D Object** → **Sprite** → **Circle**
2. **Rename** to "Ball"
3. **In Inspector**:
   - **Transform**: Position (0, 0, 0), Scale (1, 1, 1)
   - **Sprite Renderer**: Color (Red)
4. **Add Component** → **Circle Collider 2D**
5. **Add Component** → **Rigidbody 2D**

#### **3.2 Add Game Logic**

**Create the Ball Script:**
1. **Right-click in Project** → **Create** → **C# Script**
2. **Name it** "BouncingBall"
3. **Double-click** to open in code editor
4. **Replace the content** with:

```csharp
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    [Header("Ball Settings")]
    public float speed = 5f;
    public float acceleration = 0.1f;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Launch ball in random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * speed;
    }
    
    void Update()
    {
        // Increase speed over time
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + acceleration * Time.deltaTime);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ball hit: " + collision.gameObject.name);
    }
}
```

**Create the Paddle Script:**
1. **Right-click in Project** → **Create** → **C# Script**
2. **Name it** "PaddleController"
3. **Double-click** to open in code editor
4. **Replace the content** with:

```csharp
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float boundary = 8f;
    
    void Update()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Move paddle
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
        
        // Keep paddle within boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
```

#### **3.3 Attach Scripts to GameObjects**

**Attach Ball Script:**
1. **Select the Ball** in Hierarchy
2. **Drag the BouncingBall script** from Project to Inspector
3. **Configure settings** in Inspector if needed

**Attach Paddle Script:**
1. **Select the Paddle** in Hierarchy
2. **Drag the PaddleController script** from Project to Inspector
3. **Configure settings** in Inspector if needed

#### **3.4 Test and Iterate**

**Test the Game:**
1. **Click Play** button
2. **Use A/D keys** to move the paddle
3. **Watch the ball** bounce around
4. **Check Console** for debug messages

**Improve the Game:**
1. **Adjust ball speed** in Inspector
2. **Modify paddle speed** for better control
3. **Add more platforms** for complexity
4. **Change colors** for visual appeal

### Task 4: Game Development Pipeline Exercise

#### **4.1 Pre-Production Planning**

**Write a simple game design document:**

```
Game Title: Bouncing Ball Challenge
Genre: Arcade/Physics
Platform: PC (Windows/Mac)

Core Mechanics:
- Player controls paddle to keep ball bouncing
- Ball speed increases over time
- Score points for successful hits
- Game ends when ball hits bottom

Visual Style:
- Simple geometric shapes
- Bright, contrasting colors
- Clean, minimalist design

Audio:
- Ball bounce sound effects
- Background music (optional)
- UI sound effects

Technical Requirements:
- 60 FPS target
- Simple controls (A/D keys)
- Responsive physics
- Clear visual feedback
```

#### **4.2 Production Development**

**Implement the planned mechanics:**
1. **Ball physics**: Realistic bouncing behavior
2. **Paddle control**: Responsive movement
3. **Score system**: Track successful hits
4. **Difficulty progression**: Speed increases over time

**Create and import assets:**
1. **Sprites**: Simple shapes for ball, paddle, ground
2. **Materials**: Physics materials for bouncing
3. **Audio**: Sound effects for interactions
4. **UI**: Score display and game over screen

**Test and debug functionality:**
1. **Playtest regularly**: Check for bugs and issues
2. **Adjust parameters**: Fine-tune gameplay feel
3. **Fix problems**: Address any technical issues
4. **Optimize performance**: Ensure smooth gameplay

#### **4.3 Post-Production Polish**

**Optimize performance:**
1. **Check frame rate**: Use Unity Profiler
2. **Reduce draw calls**: Optimize rendering
3. **Test on different devices**: Ensure compatibility
4. **Memory management**: Check for leaks

**Add visual and audio effects:**
1. **Particle effects**: Ball bounce particles
2. **Screen shake**: Impact feedback
3. **Sound effects**: Audio feedback
4. **Visual polish**: Smooth animations

**Test on different devices:**
1. **Different screen sizes**: Test aspect ratios
2. **Performance testing**: Check on slower hardware
3. **Input testing**: Verify controls work properly
4. **Bug testing**: Look for edge cases

**Prepare for release:**
1. **Build settings**: Configure for target platform
2. **Icon creation**: Design game icon
3. **Documentation**: Write user instructions
4. **Packaging**: Create installer or executable

---

## ✅ Completion Checklist

### **Web/Mobile Analysis**
- [ ] **Comparison chart created** with key differences
- [ ] **Transferable concepts identified** between platforms
- [ ] **Game development uniqueness** understood
- [ ] **Documentation completed** in text file

### **Unity Navigation**
- [ ] **All windows explored** and understood
- [ ] **Basic operations practiced** (create, modify, delete)
- [ ] **Scene view navigation** mastered
- [ ] **Inspector usage** comfortable
- [ ] **Console monitoring** understood

### **Bouncing Ball Game**
- [ ] **Scene setup completed** (ground, paddle, ball)
- [ ] **Scripts created** and attached
- [ ] **Game runs without errors** in Play mode
- [ ] **Controls work** (A/D keys for paddle)
- [ ] **Ball physics** working correctly
- [ ] **Console shows** debug messages

### **Game Pipeline**
- [ ] **Game design document** written
- [ ] **Development process** understood
- [ ] **Testing and iteration** completed
- [ ] **Polish considerations** identified

### **Core Gameplay Loop**
- [ ] **Input → Process → Output → Feedback** cycle identified
- [ ] **Player agency** understood
- [ ] **Real-time simulation** concept grasped
- [ ] **Game feel** considerations noted

---

## 🚨 Troubleshooting

### **Common Issues and Solutions**

#### **Ball doesn't bounce**
**Possible causes:**
- Missing Rigidbody2D component
- No colliders on objects
- Physics material not applied

**Solutions:**
1. Check Ball has Rigidbody2D and CircleCollider2D
2. Check Ground and Paddle have BoxCollider2D
3. Verify colliders are not set as triggers
4. Check Physics 2D settings in Project Settings

#### **Paddle doesn't move**
**Possible causes:**
- Script not attached
- Input not configured
- Script has errors

**Solutions:**
1. Verify PaddleController script is attached
2. Check Console for compilation errors
3. Test with different input keys
4. Verify Input Manager settings

#### **Game runs too slow/fast**
**Possible causes:**
- Frame rate issues
- Physics timestep incorrect
- Performance problems

**Solutions:**
1. Check target frame rate in Project Settings
2. Adjust Fixed Timestep in Physics 2D settings
3. Use Unity Profiler to identify bottlenecks
4. Optimize rendering settings

#### **Can't navigate Unity Editor**
**Possible causes:**
- Interface not understood
- Tools not familiar
- Layout confusing

**Solutions:**
1. Practice with basic operations
2. Use Unity tutorials for interface
3. Try different layout presets
4. Ask for help from instructor

---

## 📚 Next Steps

### **Immediate Next Steps**
1. **Complete all tasks** in this lab
2. **Test your bouncing ball game** thoroughly
3. **Experiment with different values** in Inspector
4. **Try adding new features** to your game

### **Prepare for Next Lesson**
1. **Review Unity Editor** navigation skills
2. **Understand component system** basics
3. **Practice with GameObjects** and Transform
4. **Read Lesson 1 materials** in advance

### **Further Learning**
1. **Unity Learn tutorials** for additional practice
2. **Unity documentation** for deeper understanding
3. **Community forums** for questions and help
4. **Practice projects** to reinforce learning

---

## 💡 Pro Tips

### **Development Workflow**
- **Save frequently**: Ctrl+S for scene, Ctrl+Shift+S for project
- **Test regularly**: Use Play mode to check functionality
- **Debug systematically**: Use Console and Inspector
- **Document your learning**: Keep notes on what you discover

### **Learning Strategy**
- **Don't rush**: Take time to understand each concept
- **Experiment freely**: Try different values and see what happens
- **Ask questions**: Don't hesitate to seek help
- **Practice regularly**: Consistent practice is key to mastery

### **Game Development Mindset**
- **Think in systems**: How do different parts work together?
- **Consider player experience**: What feels good to play?
- **Iterate and improve**: Games are built through iteration
- **Learn from others**: Study games you enjoy playing

---

