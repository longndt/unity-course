# Unity Animation Flow & State Machine

## 🎯 Overview

This diagram illustrates Unity's animation system workflow, showing how Animator Controllers, state machines, and animation events work together to create smooth character animations.

## 📊 Animation System Flow

```
┌─────────────────────────────────────────────────────────────┐
│                    Animation System                         │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                Sprite Import Pipeline                       │
│                                                             │
│  Sprite Sheet ──────────────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Import Settings ────────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  • Texture Type: Sprite (2D and UI)                │  │   │
│  • Pixels Per Unit: 16-100                         │  │   │
│  • Sprite Mode: Multiple                           │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  Sprite Editor ──────────────────────────────────┐  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  • Slice Type: Automatic/Grid/Manual           │  │  │   │
│  • Pivot: Center/Bottom/Custom                 │  │  │   │
│  • Mesh Type: Tight/Full Rect                  │  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  Individual Sprites ──────────────────────────┐  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  • Idle_1, Idle_2, Idle_3                  │  │  │  │   │
│  • Walk_1, Walk_2, Walk_3                  │  │  │  │   │
│  • Jump_1, Jump_2, Jump_3                  │  │  │  │   │
│  • Attack_1, Attack_2, Attack_3            │  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  └─────────────────────────────────────────┘  │  │  │   │
│                                               │  │  │   │
│  └─────────────────────────────────────────────┘  │  │   │
│                                                   │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                Animator Controller Setup                    │
│                                                             │
│  Animator Controller ───────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Parameters ─────────────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  • Speed (Float)                                   │  │   │
│  • IsGrounded (Bool)                               │  │   │
│  • IsJumping (Bool)                                │  │   │
│  • Attack (Trigger)                                │  │   │
│  • Direction (Float)                               │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  States ─────────────────────────────────────────┐  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  • Idle State                                  │  │  │   │
│  • Walk State                                  │  │  │   │
│  • Run State                                   │  │  │   │
│  • Jump State                                  │  │  │   │
│  • Attack State                                │  │  │   │
│  • Death State                                 │  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  Transitions ────────────────────────────────┐  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  • Idle → Walk (Speed > 0.1)               │  │  │  │   │
│  • Walk → Run (Speed > 2.0)                │  │  │  │   │
│  • Any → Jump (Jump pressed)                │  │  │  │   │
│  • Jump → Idle (IsGrounded = true)          │  │  │  │   │
│  • Any → Attack (Attack triggered)          │  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  └─────────────────────────────────────────┘  │  │  │   │
│                                               │  │  │   │
│  └─────────────────────────────────────────────┘  │  │   │
│                                                   │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                Animation Event Flow                         │
│                                                             │
│  Animation Clip ────────────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Timeline ───────────────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  ┌─────────────────────────────────────────────┐   │  │   │
│  │  Frame 0: Idle_1                            │   │  │   │
│  │  Frame 5: Idle_2                            │   │  │   │
│  │  Frame 10: Idle_3                           │   │  │   │
│  │  Frame 15: Idle_1 (Loop)                    │   │  │   │
│  └─────────────────────────────────────────────┘   │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  Animation Events ──────────────────────────────┐  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  • OnFootstep (Frame 5, 15)                    │  │  │   │
│  • OnAttackHit (Frame 8)                       │  │  │   │
│  • OnAnimationComplete (Frame 15)              │  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  Script Methods ─────────────────────────────┐  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  public void OnFootstep() {                │  │  │  │   │
│      // Play footstep sound                │  │  │  │   │
│  }                                          │  │  │  │   │
│                                             │  │  │  │   │
│  public void OnAttackHit() {                │  │  │  │   │
│      // Deal damage to enemies              │  │  │  │   │
│  }                                          │  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  └─────────────────────────────────────────┘  │  │  │   │
│                                               │  │  │   │
│  └─────────────────────────────────────────────┘  │  │   │
│                                                   │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                Runtime Animation Flow                       │
│                                                             │
│  Script Updates ────────────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  animator.SetFloat("Speed", velocity.magnitude);       │   │
│  animator.SetBool("IsGrounded", isGrounded);           │   │
│  animator.SetTrigger("Attack");                        │   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Animator Controller ────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  • Check Parameters                                │  │   │
│  • Evaluate Transitions                            │  │   │
│  • Change States                                   │  │   │
│  • Play Animation Clips                            │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  SpriteRenderer Updates ─────────────────────────┐  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  • Change Sprite                                │  │  │   │
│  • Update Sorting Order                         │  │  │   │
│  • Handle Flipping                              │  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  Animation Events Triggered ─────────────────┐  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  • OnFootstep() called                     │  │  │  │   │
│  • OnAttackHit() called                    │  │  │  │   │
│  • OnAnimationComplete() called            │  │  │  │   │
│    │                                       │  │  │  │   │
│    ▼                                       │  │  │  │   │
│  └─────────────────────────────────────────┘  │  │  │   │
│                                               │  │  │   │
│  └─────────────────────────────────────────────┘  │  │   │
│                                                   │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
```

## 🎮 State Machine Patterns

### **Basic State Machine**
```
┌─────────────────────────────────────────────────────────────┐
│                    State Machine                            │
│                                                             │
│  Idle State ────────────────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  • Play Idle Animation                                 │   │
│  • Check for Input                                     │   │
│  • Transition to Walk if Speed > 0.1                   │   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Walk State ─────────────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  • Play Walk Animation                             │  │   │
│  • Check for Input                                 │  │   │
│  • Transition to Run if Speed > 2.0                │  │   │
│  • Transition to Idle if Speed < 0.1               │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  Run State ─────────────────────────────────────┐  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  • Play Run Animation                          │  │  │   │
│  • Check for Input                             │  │  │   │
│  • Transition to Walk if Speed < 2.0           │  │  │   │
│  • Transition to Idle if Speed < 0.1           │  │  │   │
│    │                                           │  │  │   │
│    ▼                                           │  │  │   │
│  └─────────────────────────────────────────────┘  │  │   │
│                                                   │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
```

### **Jump State Machine**
```
┌─────────────────────────────────────────────────────────────┐
│                    Jump State Machine                       │
│                                                             │
│  Any State ─────────────────────────────────────────────┐   │
│    │                                                   │   │
│    ▼                                                   │   │
│  • Check Jump Input                                    │   │
│  • Check IsGrounded                                    │   │
│  • Transition to Jump if conditions met                │   │
│    │                                                   │   │
│    ▼                                                   │   │
│  Jump State ─────────────────────────────────────────┐  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  • Play Jump Animation                             │  │   │
│  • Apply Jump Force                                │  │   │
│  • Check for Landing                               │  │   │
│  • Transition to Idle when IsGrounded = true       │  │   │
│    │                                               │  │   │
│    ▼                                               │  │   │
│  └─────────────────────────────────────────────────┘  │   │
│                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
```

## 🔧 Common Animation Patterns

### **Direction Flipping**
```csharp
public class CharacterController : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0) {
            spriteRenderer.flipX = false;
        } else if (horizontal < 0) {
            spriteRenderer.flipX = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }
}
```

### **Speed-Based Animation**
```csharp
public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;

    void Update() {
        float speed = rb.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        bool isGrounded = CheckGrounded();
        animator.SetBool("IsGrounded", isGrounded);
    }
}
```

### **Animation Events**
```csharp
public class CharacterAnimator : MonoBehaviour {
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioClip attackSound;

    public void OnFootstep() {
        audioSource.PlayOneShot(footstepSound);
    }

    public void OnAttackHit() {
        audioSource.PlayOneShot(attackSound);
        // Deal damage to enemies in range
    }

    public void OnAnimationComplete() {
        // Return to idle state
        animator.SetTrigger("Idle");
    }
}
```

## ⚡ Performance Tips

### **Animation Optimization**
- Use **Sprite Atlas** for multiple sprites
- Keep **Pixels Per Unit** consistent
- Use **Tight** mesh type for better batching
- Limit **Sorting Layers** to essential ones
- Use **Animation Compression** for large clips

### **State Machine Optimization**
- Use **Has Exit Time** for smooth transitions
- Set appropriate **Transition Duration**
- Use **Any State** sparingly
- Group related states in **Sub-State Machines**

## 🔧 Troubleshooting

### **Common Issues**
- **Animation not playing**: Check Animator Controller assignment
- **Transitions not working**: Verify parameter conditions
- **Events not firing**: Check Animation Event setup
- **Flipping issues**: Use SpriteRenderer.flipX instead of negative scale

### **Debug Tips**
- Use **Animator Window** to visualize state machine
- Use **Animation Window** to set up events
- Use **Debug.Log()** in animation event methods
- Use **Animator.GetCurrentAnimatorStateInfo()** for state info

---

**Next**: Learn about [Physics Update Order](./physics_update_order.md) for collision systems
