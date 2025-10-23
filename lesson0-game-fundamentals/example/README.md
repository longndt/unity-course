# Lesson 0 Example: Bouncing Ball Game

## 🎯 What This Example Teaches

This simple bouncing ball game demonstrates the core concepts of game development:
- **Real-time simulation**: The ball moves continuously
- **Physics**: Ball bounces off walls realistically
- **Player interaction**: Ball responds to collisions
- **Game feel**: Sound effects and visual feedback

## 🚀 How to Use This Example

### Step 1: Setup the Scene
1. Create a new 2D scene in Unity
2. Add a ground platform (GameObject → 2D Object → Sprites → Square)
3. Scale the platform to make it wider
4. Add walls on the sides and top

### Step 2: Create the Ball
1. Create a GameObject (GameObject → Create Empty)
2. Add a Sprite Renderer component (Add Component → Rendering → Sprite Renderer)
3. Set the sprite to a circle (Create → 2D → Sprites → Circle)
4. Add a Rigidbody2D component (Add Component → Physics 2D → Rigidbody 2D)
5. Add a Circle Collider 2D component (Add Component → Physics 2D → Circle Collider 2D)

### Step 3: Add the Scripts
1. Add the `BouncingBall.cs` script to the ball GameObject
2. Add the `CameraShake.cs` script to the Main Camera
3. Add the `GameManager.cs` script to an empty GameObject

### Step 4: Configure the Ball
1. In the BouncingBall component, set:
   - Initial Speed: 5
   - Speed Increase: 0.1
   - Max Speed: 15
2. Add an AudioSource component to the ball
3. Assign a bounce sound to the Bounce Sound field

### Step 5: Test the Game
1. Press Play
2. Watch the ball bounce around
3. Try adding more balls or changing the physics settings

## 🔧 Troubleshooting

**Ball doesn't bounce**: Check that the ball has a Rigidbody2D and Collider2D
**Ball falls through ground**: Make sure the ground has a Collider2D
**No sound**: Check that the ball has an AudioSource component
**Script errors**: Make sure all required components are attached

## 💡 Learning Points

- **MonoBehaviour**: Scripts that control GameObjects
- **Components**: Modular pieces that add functionality
- **Physics**: Realistic movement and collisions
- **Real-time**: Game runs continuously at 60+ FPS
- **Player Feedback**: Visual and audio responses to actions
