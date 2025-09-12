# Lab 1: Create Your First 2D Scene with Sprites

## Objectives

- Get familiar with Unity 2D interface
- Create and manipulate 2D sprites
- Understand 2D Transform component and coordinate system
- Learn about Sprite Renderer and Sorting Layers
- Save 2D scene and project

---

## Step 1: Create New 2D Project

### Instructions:

1. Open Unity Hub
2. Click "New Project"
3. Select **"2D (URP)"** template (Universal Render Pipeline optimized for 2D)
4. Set project name: `My First 2D Game`
5. Choose location to save project
6. Click "Create project"

**✅ Checkpoint**: Unity Editor opened with 2D layout and empty scene

**📝 Note**: The 2D template automatically configures:

- Scene view in 2D mode
- Camera set to Orthographic projection
- Proper lighting for 2D games
- Physics 2D enabled

---

## Step 2: Understanding 2D Workspace

### Explore 2D Interface:

1. **Scene View**: Notice the 2D toggle is enabled (top toolbar)
2. **Game View**: Set to "Free Aspect" or "16:9" for mobile games
3. **Hierarchy**: Contains "Main Camera" and "Global Volume"
4. **Project**: Contains 2D-specific folders and settings

### Configure Scene View for 2D:

1. In Scene view, ensure **2D button** is pressed (top left)
2. **Gizmos** → Uncheck "3D Icons" for cleaner 2D view
3. Set Scene view to **Orthographic** if not already set
4. Use **middle mouse/trackpad** to pan around 2D space

**✅ Checkpoint**: Scene view properly configured for 2D development

---

## Step 3: Create Background Sprite

### 3.1 Create Background GameObject

1. Right-click in Hierarchy
2. Select **2D Object → Sprites → Square**
3. Rename to `Background`
4. In Inspector, check Transform component:
   - Position: (0, 0, 0)
   - Rotation: (0, 0, 0)
   - Scale: (10, 6, 1) - This creates a 10x6 unit background

### 3.2 Configure Background Sprite

1. Select Background in Hierarchy
2. In **Sprite Renderer** component:
   - **Color**: Choose a sky blue color (RGB: 135, 206, 235)
   - **Sorting Layer**: Default
   - **Order in Layer**: -10 (behind other objects)

### 3.3 Test Background

1. In Scene view, frame the background (double-click Background in Hierarchy)
2. Switch to Game view to see how it looks
3. Background should fill the entire camera view

**✅ Checkpoint**: Blue background sprite fills the screen

---

## Step 4: Create Player Character Sprite

### 4.1 Create Player GameObject

1. Right-click in Hierarchy
2. Select **2D Object → Sprites → Square**
3. Rename to `Player`
4. Set Transform:
   - Position: (-3, -2, 0)
   - Scale: (0.8, 1.2, 1) - Makes it slightly rectangular like a character

### 4.2 Configure Player Sprite

1. Select Player in Hierarchy
2. In **Sprite Renderer** component:
   - **Color**: Choose bright green (RGB: 0, 255, 0)
   - **Sorting Layer**: Default
   - **Order in Layer**: 0 (above background)

### 4.3 Add Player Tag

1. With Player selected, in Inspector
2. **Tag** dropdown → Add Tag...
3. Click **+** → Type "Player" → Save
4. Select Player object again
5. Set **Tag** to "Player"

**✅ Checkpoint**: Green rectangular player sprite visible on screen

---

## Step 5: Create Platform Sprites

### 5.1 Create Ground Platform

1. Right-click in Hierarchy
2. Select **2D Object → Sprites → Square**
3. Rename to `Ground Platform`
4. Set Transform:
   - Position: (0, -3, 0)
   - Scale: (8, 0.5, 1)

### 5.2 Configure Ground Platform

1. **Sprite Renderer**:
   - **Color**: Brown (RGB: 139, 69, 19)
   - **Order in Layer**: -1

### 5.3 Create Floating Platform

1. Duplicate Ground Platform (Ctrl+D / Cmd+D)
2. Rename to `Floating Platform`
3. Set Transform:
   - Position: (2, 0, 0)
   - Scale: (3, 0.5, 1)

### 5.4 Create Another Platform

1. Duplicate Floating Platform
2. Rename to `High Platform`
3. Set Transform:
   - Position: (-2, 2, 0)
   - Scale: (2.5, 0.5, 1)

**✅ Checkpoint**: Three brown platforms at different heights

---

## Step 6: Create Collectible Items

### 6.1 Create Collectible

1. Right-click in Hierarchy
2. Select **2D Object → Sprites → Circle**
3. Rename to `Coin`
4. Set Transform:
   - Position: (2, 0.8, 0)
   - Scale: (0.3, 0.3, 1)

### 6.2 Configure Coin

1. **Sprite Renderer**:
   - **Color**: Gold (RGB: 255, 215, 0)
   - **Order in Layer**: 1 (above platforms)

### 6.3 Create More Coins

1. Duplicate Coin (Ctrl+D)
2. Position at (-2, 2.8, 0) - above high platform
3. Duplicate again
4. Position at (0, -1.5, 0) - floating in air

### 6.4 Organize Coins

1. Create empty GameObject (Ctrl+Shift+N)
2. Rename to "Collectibles"
3. Drag all coin objects under Collectibles parent
4. This keeps Hierarchy organized

**✅ Checkpoint**: Three gold coins positioned around the scene

---

## Step 7: Camera Setup and Scene Composition

### 7.1 Adjust Camera

1. Select **Main Camera** in Hierarchy
2. In Inspector, **Camera** component:
   - **Projection**: Orthographic (already set)
   - **Size**: 4 (adjust if needed to fit all objects)
   - Position: (0, 0, -10) - Z position must be negative

### 7.2 Test Camera View

1. In Scene view, select Main Camera
2. **GameObject** menu → **Align View to Selected**
3. Switch between Scene and Game view
4. Adjust camera size if needed to frame all objects nicely

**✅ Checkpoint**: All objects visible and well-framed in Game view

---

## Step 8: Add Simple Animation (Bonus)

### 8.1 Animate Coins

1. Select one Coin object
2. **Window** → **Animation** → **Animation**
3. Click **Create** button
4. Save as "CoinSpin"
5. Click **Add Property** → Transform → Rotation
6. Set keyframes:
   - 0:00 - Rotation Z: 0
   - 1:00 - Rotation Z: 360
7. Test by playing the scene

**✅ Checkpoint**: Coin rotates smoothly when playing

---

## Step 9: Save and Test

### 9.1 Save Everything

1. **File** → **Save** (Ctrl+S / Cmd+S)
2. Save scene as "Level01"
3. **File** → **Save Project**

### 9.2 Final Test

1. Click **Play** button
2. Observe the scene in Game view:
   - Background fills screen
   - Player and platforms visible
   - Coins rotating (if animated)
   - No error messages in Console

### 9.3 Scene Statistics

1. **Window** → **Analysis** → **Frame Debugger**
2. Note how many draw calls the scene uses
3. For 2D games, keep draw calls low for better performance

**✅ Final Checkpoint**: Complete 2D scene with background, player, platforms, and collectibles

---

## Expected Results

After completing this lab, your scene should contain:

### GameObjects Created:

- ✅ **Background**: Large blue sprite filling the screen
- ✅ **Player**: Green rectangular sprite representing the character
- ✅ **3 Platforms**: Brown rectangular sprites at different heights
- ✅ **3 Coins**: Gold circular sprites as collectible items
- ✅ **Organized Hierarchy**: Clean structure with parent objects

### 2D Concepts Learned:

- ✅ **Sprite Renderer**: How 2D images are displayed
- ✅ **Sorting Layers**: Z-depth control for 2D objects
- ✅ **2D Transform**: Position, rotation, scale in 2D space
- ✅ **Orthographic Camera**: Proper camera setup for 2D games
- ✅ **Scene Organization**: Best practices for hierarchy management

### Visual Composition:

- ✅ **Layered Depth**: Background behind, objects in front
- ✅ **Color Contrast**: Clear visual distinction between elements
- ✅ **Proper Scale**: Objects sized appropriately for 2D gameplay
- ✅ **Platformer Layout**: Basic level design with jumping opportunities

---

## Troubleshooting

### Common Issues:

**Issue**: Objects not visible in Game view
**Fix**:

- Check object positions (Z should be 0 for 2D sprites)
- Verify camera position (Z should be negative, like -10)
- Check Sorting Order in Sprite Renderer

**Issue**: Sprites look blurry or pixelated
**Fix**:

- Select sprite in Project panel
- In Inspector: Filter Mode → "Point (no filter)" for pixel art
- Or "Bilinear" for smooth sprites

**Issue**: Scene view not showing 2D properly
**Fix**:

- Click "2D" button in Scene view toolbar
- Check Camera is set to Orthographic
- Reset Scene view: Scene tab → Right-click → "Reset"

**Issue**: Colors not appearing correctly
**Fix**:

- Check if URP is properly configured
- Verify Sprite Renderer Color is white (255, 255, 255)
- Check lighting settings in Global Volume

---

## Next Steps

In Lab 2, we will:

- Add sprite animations to the player character
- Implement sprite sheet workflows
- Learn about Animation Controllers
- Create animated characters and objects
- Explore Timeline system for cutscenes

---

**🎉 Congratulations!** You've created your first 2D Unity scene with proper layering, composition, and organization. This foundation will be essential for building complete 2D games.
