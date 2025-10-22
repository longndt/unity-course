# Lab 2: 2D Sprites, Animation & Character Controller

## Objectives

- Import and configure 2D sprite sheets
- Create sprite animations using Animation window
- Setup Animator Controller for character states
- Implement basic 2D character movement
- Learn about 2D collision detection

---

## Step 1: Project Setup and Sprite Import

### 1.1 Create New 2D Project

1. Open Unity Hub
2. Create new project: **"2D Character Animation"**
3. Select **2D (URP)** template
4. Wait for project to load

### 1.2 Import Sample Sprites

1. In Project panel, create folders:
   - **Art** → **Characters**
   - **Art** → **Environment**
   - **Art** → **UI**
   - **Scripts**
   - **Animations**

### 1.3 Create Sample Character Sprites

Since we don't have external assets, we'll create simple character states:

1. **Assets** → **Create** → **2D** → **Sprites** → **Square**
2. Name it "Character_Idle"
3. Create three more squares:
   - "Character_Walk1"
   - "Character_Walk2"
   - "Character_Jump"

### 1.4 Configure Sprite Colors

1. Select "Character_Idle"
2. **Sprite Renderer** → **Color**: Light Blue
3. "Character_Walk1" → **Color**: Blue
4. "Character_Walk2" → **Color**: Dark Blue
5. "Character_Jump" → **Color**: Purple

**✅ Checkpoint**: Four colored sprite assets ready for animation

---

## Step 2: Create Character GameObject with Animation

### 2.1 Setup Character GameObject

1. Create **2D Object** → **Sprites** → **Square**
2. Rename to "Player"
3. Position: (0, 0, 0)
4. Scale: (1, 1.5, 1) - Make taller like a character

### 2.2 Create Idle Animation

1. Select Player in Hierarchy
2. **Window** → **Animation** → **Animation**
3. Click **Create** button
4. Name: "Player_Idle"
5. Save in **Animations** folder

### 2.3 Setup Idle Animation Properties

1. In Animation window:
   - Set length to 1.00 seconds
   - Click **Add Property** → Sprite Renderer → Sprite
2. Set keyframes:
   - **0:00** - Drag "Character_Idle" sprite
   - **0:30** - Drag "Character_Walk1" sprite
   - **1:00** - Drag "Character_Idle" sprite
3. Press **Play** to test idle animation

### 2.4 Create Walk Animation

1. In Animation window, click dropdown → **Create New Clip**
2. Name: "Player_Walk"
3. Set length to 0.60 seconds
4. Create walking cycle:
   - **0:00** - "Character_Walk1" sprite
   - **0:15** - "Character_Idle" sprite
   - **0:30** - "Character_Walk2" sprite
   - **0:45** - "Character_Idle" sprite
   - **0:60** - "Character_Walk1" sprite

### 2.5 Create Jump Animation

1. Create New Clip: "Player_Jump"
2. Set length to 0.30 seconds
3. Simple jump:
   - **0:00** - "Character_Jump" sprite
   - **0:30** - "Character_Jump" sprite

**✅ Checkpoint**: Player has three animation clips ready

---

## Step 3: Setup Animator Controller

### 3.1 Create Animator Controller

1. **Assets** → **Create** → **Animator Controller**
2. Name: "PlayerController"
3. Save in **Animations** folder
4. Double-click to open **Animator** window

### 3.2 Setup Animation States

1. **Right-click** in Animator grid → **Create State** → **From New Blend Tree**
2. Rename to "Idle"
3. **Right-click** again → **Create State** → **Empty**
4. Rename to "Walk"
5. Create another: "Jump"

### 3.3 Assign Animation Clips

1. Select **Idle** state
2. In Inspector: **Motion** → Select "Player_Idle"
3. Select **Walk** state → **Motion** → "Player_Walk"
4. Select **Jump** state → **Motion** → "Player_Jump"
5. **Right-click** Idle → **Set as Layer Default State**

### 3.4 Create Animation Parameters

1. In **Animator** window, **Parameters** tab
2. Click **+** → **Float** → Name: "Speed"
3. Click **+** → **Bool** → Name: "IsJumping"
4. Click **+** → **Trigger** → Name: "Jump"

### 3.5 Setup Transitions

1. **Right-click** Idle → **Make Transition** → Click Walk
2. In Inspector:
   - **Conditions**: Speed Greater 0.1
   - **Transition Duration**: 0.1
3. Walk → Idle transition:
   - **Conditions**: Speed Less 0.1
   - **Transition Duration**: 0.1
4. Idle → Jump:
   - **Conditions**: Jump (trigger)
   - **Transition Duration**: 0.05
5. Jump → Idle:
   - **Conditions**: IsJumping false
   - **Transition Duration**: 0.2

**✅ Checkpoint**: Animator Controller configured with states and transitions

---

## Step 4: Create Character Movement Script

### 4.1 Create Player Script

1. **Assets** → **Create** → **C# Script**
2. Name: "PlayerController2D"
3. Double-click to open in code editor

### 4.2 Write Movement Code

```csharp
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public LayerMask groundLayerMask = 1;
    public float groundCheckDistance = 0.1f;

    // Components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Movement variables
    private float moveInput;
    private bool isGrounded;
    private bool facingRight = true;

    void Start()
    {
        // Get required components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Validate components
        if (rb == null)
            Debug.LogError("Rigidbody2D component missing!");
        if (animator == null)
            Debug.LogError("Animator component missing!");
    }

    void Update()
    {
        // Get input
        GetInput();

        // Check ground status
        CheckGroundStatus();

        // Update animator parameters
        UpdateAnimator();

        // Handle sprite flipping
        HandleSpriteFlipping();
    }

    void FixedUpdate()
    {
        // Handle horizontal movement
        MoveCharacter();
    }

    void GetInput()
    {
        // Horizontal input
        moveInput = Input.GetAxis("Horizontal");

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MoveCharacter()
    {
        // Apply horizontal movement
        Vector2 velocity = rb.velocity;
        velocity.x = moveInput * moveSpeed;
        rb.velocity = velocity;
    }

    void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Trigger jump animation
        animator.SetTrigger("Jump");
        animator.SetBool("IsJumping", true);
    }

    void CheckGroundStatus()
    {
        // Raycast downward to check for ground
        Vector2 raycastOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down,
                                           groundCheckDistance, groundLayerMask);

        isGrounded = hit.collider != null;

        // Update jumping status
        if (isGrounded && rb.velocity.y <= 0.1f)
        {
            animator.SetBool("IsJumping", false);
        }

        // Draw debug ray
        Debug.DrawRay(raycastOrigin, Vector2.down * groundCheckDistance,
                     isGrounded ? Color.green : Color.red);
    }

    void UpdateAnimator()
    {
        // Update speed parameter
        float speed = Mathf.Abs(moveInput);
        animator.SetFloat("Speed", speed);
    }

    void HandleSpriteFlipping()
    {
        // Flip sprite based on movement direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch direction flag
        facingRight = !facingRight;

        // Flip the sprite
        spriteRenderer.flipX = !facingRight;
    }

    // Display debug information
    void OnDrawGizmosSelected()
    {
        // Draw ground check ray
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * groundCheckDistance);
    }
}
```

### 4.3 Attach Script to Player

1. Select Player in Hierarchy
2. **Add Component** → **Player Controller2D**
3. **Add Component** → **Rigidbody2D**
4. Configure Rigidbody2D:
   - **Gravity Scale**: 3
   - **Freeze Rotation Z**: ✅ (prevent spinning)

**✅ Checkpoint**: Player has movement script and physics components

---

## Step 5: Create Level Environment

### 5.1 Create Ground Platform

1. **2D Object** → **Sprites** → **Square**
2. Name: "Ground"
3. Transform:
   - Position: (0, -3, 0)
   - Scale: (10, 1, 1)
4. **Sprite Renderer** → **Color**: Brown
5. **Add Component** → **Box Collider 2D**

### 5.2 Create Platforms

1. Duplicate Ground (Ctrl+D)
2. Name: "Platform1"
3. Transform:

   - Position: (3, -1, 0)
   - Scale: (3, 0.5, 1)

4. Duplicate Platform1
5. Name: "Platform2"
6. Position: (-3, 1, 0)

### 5.3 Setup Ground Layer

1. **Inspector** → **Layer** dropdown → **Create New Layer**
2. Name: "Ground"
3. Assign all platforms to "Ground" layer

### 5.4 Configure Player Ground Detection

1. Select Player
2. In **Player Controller2D** script:
   - **Ground Layer Mask** → Select "Ground" layer only
   - **Ground Check Distance**: 0.6

**✅ Checkpoint**: Level has platforms and ground collision setup

---

## Step 6: Test and Debug Character Controller

### 6.1 Test Basic Movement

1. Click **Play** button
2. Test controls:
   - **A/D** or **Arrow Keys**: Move left/right
   - **Space**: Jump (only when grounded)
3. **Console** should show no errors

### 6.2 Debug Ground Detection

1. Select Player while playing
2. **Scene** view should show:
   - **Green ray** when grounded
   - **Red ray** when in air
3. Jump should only work when ray is green

### 6.3 Test Animations

1. Player should:
   - **Idle**: When not moving
   - **Walk**: When moving horizontally
   - **Jump**: When jumping
   - **Sprite flip**: When changing direction

### 6.4 Fine-tune Parameters

1. Stop playing
2. Adjust **Player Controller2D** settings:
   - **Move Speed**: 3-8 (comfort preference)
   - **Jump Force**: 8-12 (jump height)
   - **Ground Check Distance**: 0.5-0.8 (platform detection)

**✅ Checkpoint**: Fully functional 2D character controller

---

## Expected Results

After completing this lab, you should have:

### Functional Character System:

- ✅ **Animated Player**: Idle, Walk, and Jump animations
- ✅ **Smooth Movement**: Responsive horizontal movement
- ✅ **Physics-Based Jumping**: Realistic jump mechanics
- ✅ **Ground Detection**: Only jump when on platforms
- ✅ **Sprite Flipping**: Character faces movement direction

### Animation System:

- ✅ **Animator Controller**: State machine with transitions
- ✅ **Animation Clips**: Multiple character states
- ✅ **Parameter Control**: Code-driven animation triggers
- ✅ **Smooth Transitions**: Natural animation blending

### 2D Physics Integration:

- ✅ **Rigidbody2D**: Proper physics simulation
- ✅ **Collider2D**: Platform collision detection
- ✅ **Layer System**: Ground detection filtering
- ✅ **Debug Visualization**: Visual feedback for ground checks

---

## Troubleshooting

### Animation Issues:

**Problem**: Animations not playing
**Solution**:

- Check Animator Controller is assigned to Player
- Verify animation clips are assigned to states
- Check parameter names match exactly in code

**Problem**: Transitions not working
**Solution**:

- Verify transition conditions match parameter values
- Check "Has Exit Time" is unchecked for responsive transitions
- Ensure parameter types (Float, Bool, Trigger) are correct

### Movement Issues:

**Problem**: Character not moving
**Solution**:

- Verify Rigidbody2D is attached
- Check Input system is responding (Debug.Log moveInput)
- Ensure moveSpeed > 0

**Problem**: Character stuck to walls
**Solution**:

- Add Physics Material 2D with friction = 0
- Check collider sizes aren't overlapping
- Verify ground layer mask excludes walls

**Problem**: Jump not working
**Solution**:

- Check isGrounded detection with debug rays
- Verify Space key input
- Ensure jumpForce is sufficient (8-15 range)

### Code Issues:

**Problem**: NullReferenceException
**Solution**:

- Check all GetComponent<>() calls in Start()
- Add null checks for critical components
- Verify GameObjects have required components

---

## Next Steps

In Lab 3, we will:

- Add 2D physics interactions (moving platforms)
- Implement collectible items with trigger detection
- Create hazards and game boundaries
- Add particle effects for visual feedback
- Introduce basic enemy AI with 2D pathfinding

---

You've created a complete 2D character controller with animations, physics, and responsive movement. This is the foundation for any 2D platformer or adventure game.
