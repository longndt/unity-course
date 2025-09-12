# Lab 3: 2D Physics & Collision Detection

## Objectives

- Understand and apply Unity 2D Physics System
- Work with Rigidbody2D and Collider2D components
- Create Physics Materials 2D
- Build simple 2D physics game with collision detection
- Learn difference between Collision and Trigger events

---

## Part 1: Setup 2D Physics Environment

### Step 1: Create New 2D Project

1. Unity Hub → New Project
2. Template: **2D (URP)**
3. Name: `2D Physics Game`
4. Create Project

### Step 2: Create 2D Ground and Boundaries

1. **Create Ground Platform**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `Ground`
   - Position: (0, -4, 0)
   - Scale: (20, 2, 1)
   - Color: Brown (#8B4513)
   - Add Component: **Box Collider 2D**

2. **Create Side Boundaries**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `LeftWall`
   - Position: (-9, 0, 0)
   - Scale: (1, 12, 1)
   - Color: Gray (#808080)
   - Add Component: **Box Collider 2D**

   - Duplicate (Ctrl+D) → Name: `RightWall`
   - Position: (9, 0, 0)

   - Duplicate LeftWall → Name: `TopWall`
   - Position: (0, 5, 0)
   - Scale: (20, 1, 1)

### Step 3: Setup Camera for 2D View

1. Select **Main Camera**
2. In Inspector:
   - Position: (0, 0, -10)
   - Projection: **Orthographic** (should be set automatically in 2D template)
   - Size: 6

**✅ Checkpoint**: Have 2D arena with ground and boundary walls visible in Scene view

---

## Part 2: Create 2D Bouncing Ball

### Step 4: Create Ball GameObject

1. **GameObject** → 2D Object → **Sprites** → **Circle**
2. Name: `BouncingBall2D`
3. Position: (0, 3, 0) - above ground to test gravity
4. Scale: (1, 1, 1)
5. Color: Red (#FF4444)

### Step 5: Add Physics Components

1. **Add Rigidbody2D**:

   - Component → Physics 2D → **Rigidbody 2D**
   - Mass: 1
   - Linear Drag: 0.1
   - Angular Drag: 0.1
   - Gravity Scale: 1

2. **Add Circle Collider 2D**:
   - Component → Physics 2D → **Circle Collider 2D**
   - Radius: 0.5 (should auto-fit the sprite)
   - Material: (we'll create this next)

### Step 6: Create 2D Physics Materials

1. **Create Folder**: Assets → Create → Folder → `PhysicsMaterials2D`

2. **Create Bouncy Material**:

   - Create → Physics Material 2D → `BouncyBall`
   - Friction: 0.3
   - Bounciness: 0.9

3. **Create Ground Material**:

   - Create → Physics Material 2D → `GroundSurface`
   - Friction: 0.8
   - Bounciness: 0.2

4. **Apply Materials**:
   - Ball → Circle Collider 2D → Material → BouncyBall
   - Ground → Box Collider 2D → Material → GroundSurface
   - Walls → Leave default (no bouncing on walls)

**✅ Checkpoint**: Ball should fall and bounce when you press Play

---

## Part 3: Add Interactive Elements

### Step 7: Create Moving Platform

1. **Create Moving Platform**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `MovingPlatform`
   - Position: (3, -1, 0)
   - Scale: (3, 0.5, 1)
   - Color: Blue (#4444FF)
   - Add Component: **Box Collider 2D**
   - Add Component: **Rigidbody2D**
   - Set Rigidbody2D → Body Type: **Kinematic**

2. **Add Platform Movement Script**:
   - Create → C# Script → `MovingPlatform2D`
   - Attach to MovingPlatform

```csharp
using UnityEngine;

public class MovingPlatform2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float moveRange = 4f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate movement
        float movement = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.Translate(Vector2.right * movement);

            // Check if reached right boundary
            if (transform.position.x >= startPosition.x + moveRange)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * movement);

            // Check if reached left boundary
            if (transform.position.x <= startPosition.x - moveRange)
            {
                movingRight = true;
            }
        }
    }
}
```

### Step 8: Create Collectible Item

1. **Create Collectible**:

   - GameObject → 2D Object → **Sprites** → **Circle**
   - Name: `Collectible`
   - Position: (0, 1, 0)
   - Scale: (0.5, 0.5, 1)
   - Color: Yellow (#FFFF44)

2. **Setup Trigger Collider**:

   - Add Component: **Circle Collider 2D**
   - Check **Is Trigger** ✓
   - Radius: 0.25

3. **Add Collectible Script**:
   - Create → C# Script → `Collectible2D`
   - Attach to Collectible

```csharp
using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    [Header("Effects")]
    public float rotationSpeed = 90f;

    void Update()
    {
        // Rotate the collectible
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BouncingBall2D")
        {
            Debug.Log("Collectible picked up!");

            // Add force to ball on collection
            Rigidbody2D ballRb = other.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.AddForce(Vector2.up * 300f);
            }

            // Destroy collectible
            Destroy(gameObject);
        }
    }
}
```

**✅ Checkpoint**: Moving platform should move horizontally, collectible should spin and disappear when touched by ball

---

## Part 4: Add Player Control and Advanced Physics

### Step 9: Add Player Control to Ball

1. **Create Ball Controller Script**:
   - Create → C# Script → `BallController2D`
   - Attach to BouncingBall2D

```csharp
using UnityEngine;

public class BallController2D : MonoBehaviour
{
    [Header("Movement")]
    public float moveForce = 10f;
    public float jumpForce = 300f;
    public float maxSpeed = 8f;

    [Header("Ground Check")]
    public LayerMask groundLayerMask = 1;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb2D;
    private bool isGrounded = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // Create ground check point
        if (groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform);
            groundCheckObj.transform.localPosition = Vector3.down * 0.5f;
            groundCheck = groundCheckObj.transform;
        }
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);

        // Handle input
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Apply horizontal force
        Vector2 force = Vector2.right * horizontal * moveForce;
        rb2D.AddForce(force);

        // Limit speed
        if (rb2D.velocity.x > maxSpeed)
            rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.y);
        else if (rb2D.velocity.x < -maxSpeed)
            rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(Vector2.up * jumpForce);
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

### Step 10: Create Hazard with Collision Detection

1. **Create Hazard**:

   - GameObject → 2D Object → **Sprites** → **Square**
   - Name: `Hazard`
   - Position: (-3, -3, 0)
   - Scale: (1, 1, 1)
   - Color: Red (#FF0000)
   - Add Component: **Box Collider 2D**

2. **Add Hazard Script**:
   - Create → C# Script → `Hazard2D`
   - Attach to Hazard

```csharp
using UnityEngine;

public class Hazard2D : MonoBehaviour
{
    [Header("Effects")]
    public float pushForce = 500f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BouncingBall2D")
        {
            Debug.Log("Player hit hazard!");

            // Push ball away
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(pushDirection * pushForce);
            }
        }
    }
}
```

**✅ Checkpoint**: Player can control ball with arrow keys and spacebar, hazard pushes ball away

---

## Part 5: Testing and Optimization

### Step 11: Test Physics Interactions

**Test Checklist**:

- [ ] Ball falls and bounces realistically
- [ ] Ball responds to player input (arrow keys + space)
- [ ] Moving platform carries the ball
- [ ] Collectible disappears when touched and adds upward force
- [ ] Hazard pushes ball away on contact
- [ ] Ground check works correctly for jumping

### Step 12: Fine-tune Physics Settings

**Recommended Tweaks**:

- Adjust `moveForce` in BallController2D for responsive movement
- Modify `bounciness` in physics materials for desired bounce behavior
- Change `gravity scale` on Rigidbody2D for different game feel
- Adjust `maxSpeed` to prevent unrealistic movement

### Step 13: Visual Polish

1. **Add Particle Effects** (Optional):

   - GameObject → Effects → **Particle System**
   - Position on collectible pickup location
   - Trigger via script when collected

2. **Add Sound Effects** (Optional):
   - Import audio clips
   - Use `AudioSource.PlayOneShot()` in collision scripts

**✅ Final Checkpoint**: Complete 2D physics game with player control, moving platforms, collectibles, and hazards

---

## Learning Objectives Review

After completing this lab, you should understand:

1. **2D Physics Fundamentals**:

   - Rigidbody2D vs Rigidbody (3D differences)
   - Collider2D types and their applications
   - Physics Materials 2D for surface properties

2. **Collision vs Trigger**:

   - OnCollisionEnter2D for solid object interactions
   - OnTriggerEnter2D for detection zones
   - When to use each approach

3. **Force Application**:

   - AddForce() for physics-based movement
   - Different ForceMode2D options
   - Velocity manipulation vs force application

4. **Ground Detection**:
   - Using OverlapCircle for ground checking
   - LayerMask for selective collision detection
   - Gizmos for debugging collision areas

**Next Steps**: Use these 2D physics concepts in Lesson 4 for player character controller!
