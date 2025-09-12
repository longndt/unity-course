# Lab 4: 2D Input System & Player Controller

## Objectives

- Create responsive 2D character controller
- Implement Unity's New Input System for 2D games
- Setup 2D camera follow system
- Add 2D jump mechanics with coyote time and jump buffering
- Integrate animations with 2D movement

---

## Part 1: Setup 2D Character and Environment

### Step 1: Create New 2D Scene

1. File → New Scene
2. Template: **2D (URP)**
3. Save As: `2D_PlayerController_Scene`

### Step 2: Create 2D Environment

1. **Ground Platforms**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `Ground_01`
   - Position: (0, -4, 0)
   - Scale: (12, 1, 1)
   - Color: Brown (#8B4513)
   - Add Component: **Box Collider 2D**

   - Duplicate for more platforms:
   - `Ground_02`: Position (8, -2, 0), Scale (4, 1, 1)
   - `Ground_03`: Position (-6, 0, 0), Scale (3, 1, 1)
   - `Ground_04`: Position (4, 2, 0), Scale (5, 1, 1)

2. **Setup Layers**:
   - **Layers** → Create Layer → `Ground`
   - Set all ground objects to **Ground** layer
   - **Layers** → Create Layer → `Player`

### Step 3: Create 2D Player Character

1. **Create Player GameObject**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `Player2D`
   - Position: (0, 0, 0)
   - Scale: (1, 1.5, 1)
   - Color: Blue (#4444FF)
   - Set Layer: **Player**

2. **Add Physics Components**:

   - Add Component: **Rigidbody2D**

     - Mass: 1
     - Linear Drag: 1 (for ground friction)
     - Angular Drag: 5 (prevent unwanted rotation)
     - Gravity Scale: 3 (faster falling)
     - Freeze Rotation Z: ✓ (prevent tipping over)

   - Add Component: **Capsule Collider 2D**
     - Size: (0.8, 1.4)
     - Offset: (0, 0)

3. **Setup Ground Detection**:
   - Create child GameObject: **GroundCheck**
   - Position: (0, -0.7, 0)
   - Add Component: **Transform** (empty object for position reference)

**✅ Checkpoint**: Player character with physics components in 2D scene with platforms

---

## Part 2: Implement 2D Input System and Movement

### Step 4: Install Input System Package

1. **Window** → Package Manager
2. Switch to **Unity Registry**
3. Search: **Input System**
4. Install latest version
5. When prompted, click **Yes** to restart (to enable new Input System)

### Step 5: Create Input Actions

1. **Create Input Actions Asset**:

   - Assets → Create → **Input Actions**
   - Name: `Player2D_InputActions`

2. **Configure Action Map**:

   - Double-click to open Input Actions window
   - **Action Maps** → Rename to: `Player`

3. **Add Actions**:

   - **Add Action** → Name: `Move`

     - Action Type: **Value**
     - Control Type: **Vector 2**
     - Add Binding: **2D Vector Composite**
     - Up: W, Down: S, Left: A, Right: D
     - Also add: **Arrow Keys** as alternative

   - **Add Action** → Name: `Jump`
     - Action Type: **Button**
     - Add Binding: **Space**
     - Also add: **Left Ctrl** as alternative

4. **Save and Generate Code**:
   - Click **Save Asset**
   - Check **Generate C# Class** ✓
   - Click **Apply**

### Step 6: Create 2D Player Controller Script

1. **Create Player Controller**:
   - Create → C# Script → `Player2DController`
   - Attach to Player2D GameObject

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public float coyoteTime = 0.2f;
    public float jumpBufferTime = 0.1f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundLayerMask = 1;
    public float groundCheckRadius = 0.2f;

    [Header("Physics")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Private variables
    private Rigidbody2D rb2D;
    private Player2D_InputActions inputActions;

    private Vector2 moveInput;
    private bool isGrounded;
    private bool wasGrounded;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    void Awake()
    {
        inputActions = new Player2D_InputActions();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Jump.performed += OnJump;
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Jump.performed -= OnJump;
        inputActions.Player.Disable();
    }

    void Update()
    {
        CheckGrounded();
        HandleCoyoteTime();
        HandleJumpBuffer();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleBetterJumping();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }

    void CheckGrounded()
    {
        wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
    }

    void HandleCoyoteTime()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void HandleJumpBuffer()
    {
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;

            if (coyoteTimeCounter > 0f)
            {
                // Execute jump
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                jumpBufferCounter = 0f;
                coyoteTimeCounter = 0f;
            }
        }
    }

    void HandleMovement()
    {
        // Apply horizontal movement
        rb2D.velocity = new Vector2(moveInput.x * moveSpeed, rb2D.velocity.y);

        // Flip character sprite based on movement direction
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void HandleBetterJumping()
    {
        // Better jumping physics
        if (rb2D.velocity.y < 0)
        {
            // Falling faster
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2D.velocity.y > 0 && !inputActions.Player.Jump.IsPressed())
        {
            // Short hop when jump is released
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw ground check circle
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
```

2. **Setup Ground Check Reference**:
   - Select Player2D in Inspector
   - Drag **GroundCheck** child object to **Ground Check** field
   - Set **Ground Layer Mask** to **Ground** layer only

**✅ Checkpoint**: Player responds to WASD/Arrow Keys and Space for jumping

---

## Part 3: 2D Camera Follow System

### Step 7: Create Smooth 2D Camera Follow

1. **Create Camera Controller Script**:
   - Create → C# Script → `CameraFollow2D`
   - Attach to **Main Camera**

```csharp
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Settings")]
    public float followSpeed = 3f;
    public Vector2 offset = Vector2.zero;

    [Header("Bounds (Optional)")]
    public bool useBounds = false;
    public float leftBound = -10f;
    public float rightBound = 10f;
    public float bottomBound = -5f;
    public float topBound = 5f;

    [Header("Look Ahead")]
    public float lookAheadDistance = 2f;
    public float lookAheadSpeed = 2f;

    private Vector3 targetPosition;
    private float currentLookAhead;

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate look-ahead based on player movement
        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        if (targetRb != null)
        {
            float targetLookAhead = targetRb.velocity.x * lookAheadDistance;
            currentLookAhead = Mathf.Lerp(currentLookAhead, targetLookAhead, lookAheadSpeed * Time.deltaTime);
        }

        // Calculate target position with offset and look-ahead
        targetPosition = target.position + new Vector3(currentLookAhead + offset.x, offset.y, -10f);

        // Apply bounds if enabled
        if (useBounds)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, leftBound, rightBound);
            targetPosition.y = Mathf.Clamp(targetPosition.y, bottomBound, topBound);
        }

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            // Draw camera bounds
            Gizmos.color = Color.yellow;
            Vector3 size = new Vector3(rightBound - leftBound, topBound - bottomBound, 0);
            Vector3 center = new Vector3((leftBound + rightBound) / 2, (bottomBound + topBound) / 2, 0);
            Gizmos.DrawWireCube(center, size);
        }
    }
}
```

2. **Configure Camera Follow**:
   - Select Main Camera
   - Set **Target** to Player2D
   - Adjust **Follow Speed**: 3
   - Set **Offset**: (0, 1) to center player better
   - Enable **Use Bounds** if you want to limit camera movement

**✅ Checkpoint**: Camera smoothly follows player with look-ahead

---

## Part 4: Enhanced 2D Movement Features

### Step 8: Add Wall Jump Mechanics

1. **Create Wall Detection**:

   - Add child to Player2D: **WallCheck**
   - Position: (0.5, 0, 0)

2. **Update Player Controller** with wall jump:

```csharp
[Header("Wall Jump")]
public Transform wallCheck;
public float wallCheckDistance = 0.5f;
public float wallSlideSpeed = 0.5f;
public float wallJumpForce = 10f;
public Vector2 wallJumpDirection = new Vector2(1, 1);

private bool isTouchingWall;
private bool isWallSliding;
private int wallJumpDirection_X;

// Add to Update()
void Update()
{
    CheckGrounded();
    CheckWall();
    HandleCoyoteTime();
    HandleJumpBuffer();
    HandleWallSlide();
}

void CheckWall()
{
    isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right * transform.localScale.x, wallCheckDistance, groundLayerMask);
    wallJumpDirection_X = (int)transform.localScale.x;
}

void HandleWallSlide()
{
    if (isTouchingWall && !isGrounded && rb2D.velocity.y < 0)
    {
        isWallSliding = true;
        rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -wallSlideSpeed, float.MaxValue));
    }
    else
    {
        isWallSliding = false;
    }
}

// Modify OnJump method
void OnJump(InputAction.CallbackContext context)
{
    if (context.performed)
    {
        if (isWallSliding)
        {
            // Wall jump
            rb2D.velocity = new Vector2(-wallJumpDirection_X * wallJumpForce * wallJumpDirection.x, wallJumpForce * wallJumpDirection.y);
        }
        else
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }
}
```

### Step 9: Add Jump Squash and Stretch Effect

```csharp
[Header("Visual Effects")]
public float jumpScaleMultiplier = 1.2f;
public float landScaleMultiplier = 0.8f;
public float scaleSpeed = 10f;

private Vector3 originalScale;
private Vector3 targetScale;

void Start()
{
    originalScale = transform.localScale;
    targetScale = originalScale;
}

// Add to Update()
void Update()
{
    // ... existing code ...
    HandleVisualEffects();
}

void HandleVisualEffects()
{
    // Jump squash and stretch
    if (!wasGrounded && isGrounded)
    {
        // Just landed
        targetScale = new Vector3(originalScale.x * landScaleMultiplier, originalScale.y * jumpScaleMultiplier, originalScale.z);
    }
    else if (wasGrounded && !isGrounded)
    {
        // Just jumped
        targetScale = new Vector3(originalScale.x * jumpScaleMultiplier, originalScale.y * landScaleMultiplier, originalScale.z);
    }
    else if (isGrounded)
    {
        // Return to normal
        targetScale = originalScale;
    }

    // Apply scale smoothly
    Vector3 currentScale = transform.localScale;
    float scaleX = Mathf.Sign(currentScale.x) * targetScale.x; // Preserve flip direction
    transform.localScale = Vector3.Lerp(currentScale, new Vector3(scaleX, targetScale.y, targetScale.z), scaleSpeed * Time.deltaTime);
}
```

**✅ Checkpoint**: Player has wall jump, smooth camera follow, and visual feedback

---

## Part 5: 2D Animation Integration

### Step 10: Setup 2D Animation System

1. **Create Animation Folder Structure**:

   - Assets → Create → Folder → `Animations`
   - Assets/Animations → Create → Folder → `Player`

2. **Create Animation Controller**:

   - Create → Animator Controller → `Player2D_Controller`
   - Place in Assets/Animations/Player/

3. **Create Animation States**:

   - Open Animator window
   - Create States: **Idle**, **Run**, **Jump**, **Fall**
   - Set **Idle** as default state (orange)

4. **Create Parameters**:

   - **Speed** (Float)
   - **IsGrounded** (Bool)
   - **VerticalVelocity** (Float)

5. **Setup Transitions**:
   - Idle → Run: Speed > 0.1
   - Run → Idle: Speed < 0.1
   - Any State → Jump: !IsGrounded AND VerticalVelocity > 0
   - Any State → Fall: !IsGrounded AND VerticalVelocity < 0
   - Jump/Fall → Idle: IsGrounded AND Speed < 0.1
   - Jump/Fall → Run: IsGrounded AND Speed > 0.1

### Step 11: Add Animation to Player Controller

```csharp
[Header("Animation")]
public Animator animator;

// Add to Update()
void Update()
{
    // ... existing code ...
    UpdateAnimations();
}

void UpdateAnimations()
{
    if (animator != null)
    {
        // Update animation parameters
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rb2D.velocity.y);
    }
}
```

**✅ Checkpoint**: Complete 2D player controller with animations, camera follow, and advanced movement

---

## Part 6: Testing and Polish

### Step 12: Test Movement System

**Test Checklist**:

- [ ] Responsive movement with WASD/Arrow Keys
- [ ] Jump feels good with coyote time and jump buffering
- [ ] Wall jumping works on vertical surfaces
- [ ] Camera follows smoothly with look-ahead
- [ ] Visual squash/stretch effects on jump/land
- [ ] Animation states transition properly

### Step 13: Fine-tuning Parameters

**Recommended Adjustments**:

- **Move Speed**: 6-8 for responsive platformer feel
- **Jump Force**: 10-15 based on level design
- **Coyote Time**: 0.1-0.2 seconds
- **Jump Buffer**: 0.1-0.15 seconds
- **Camera Follow Speed**: 2-4 for smooth tracking

### Step 14: Add Debug Information

```csharp
void OnGUI()
{
    if (Application.isPlaying)
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Grounded: " + isGrounded);
        GUI.Label(new Rect(10, 30, 200, 20), "Wall Sliding: " + isWallSliding);
        GUI.Label(new Rect(10, 50, 200, 20), "Velocity: " + rb2D.velocity);
        GUI.Label(new Rect(10, 70, 200, 20), "Coyote Time: " + coyoteTimeCounter.ToString("F2"));
    }
}
```

**✅ Final Checkpoint**: Professional 2D character controller ready for game development

---

## Learning Objectives Review

After completing this lab, you should understand:

1. **2D Input System**:

   - Setting up Input Actions for 2D games
   - Handling input events with UnityEvents
   - Creating responsive 2D controls

2. **Advanced 2D Movement**:

   - Coyote time for forgiving jump timing
   - Jump buffering for responsive controls
   - Wall jumping mechanics
   - Better jumping physics with variable height

3. **2D Camera Systems**:

   - Smooth camera following
   - Look-ahead for better game feel
   - Camera bounds and constraints

4. **Animation Integration**:
   - Connecting animations to movement states
   - Parameter-driven animation systems
   - Visual feedback for game actions

**Next Steps**: Use this character controller as the foundation for your complete game in Lesson 5!
