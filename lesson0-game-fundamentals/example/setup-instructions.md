# Lesson 0 Example Setup Instructions

## 🎯 Overview
This guide will help you set up the simple bouncing ball game from scratch. Perfect for your first Unity project!

---

## 📋 Prerequisites
- Unity Hub installed
- Unity 6 LTS installed
- Basic understanding of Unity Editor (from Lesson 0 theory)

---

## 🚀 Step-by-Step Setup

### **Step 1: Create New Project**
1. **Open Unity Hub**
2. **Click "New project"**
3. **Select "2D (URP)" template**
4. **Project name**: `Lesson0-BouncingBall`
5. **Location**: Choose your preferred folder
6. **Click "Create project"**
7. **Wait for Unity to load** (may take 2-3 minutes)

### **Step 2: Create Scripts Folder**
1. **Right-click in Project window**
2. **Create → Folder**
3. **Name it**: `Scripts`
4. **This keeps your code organized**

### **Step 3: Import Scripts**
1. **Copy all `.cs` files** from this example folder
2. **Paste them** into your `Assets/Scripts` folder
3. **Wait for Unity to compile** (check bottom-right corner)

### **Step 4: Create Game Objects**

#### **4.1: Main Camera Setup**
1. **Select Main Camera** in Hierarchy
2. **In Inspector, set**:
   - **Projection**: Orthographic
   - **Size**: 5
   - **Position**: (0, 0, -10)

#### **4.2: Create Ball**
1. **Right-click in Hierarchy → 2D Object → Sprite**
2. **Rename to**: `Ball`
3. **Add Components**:
   - **Rigidbody2D** (Component → Physics 2D → Rigidbody 2D)
   - **Circle Collider 2D** (Component → Physics 2D → Circle Collider 2D)
   - **BouncingBall script** (Add Component → Scripts → BouncingBall)
4. **Set Rigidbody2D**:
   - **Gravity Scale**: 0
   - **Drag**: 0.1
   - **Angular Drag**: 0.1

#### **4.3: Create Walls**
1. **Create 4 sprites** (Right-click → 2D Object → Sprite)
2. **Name them**: `WallTop`, `WallBottom`, `WallLeft`, `WallRight`
3. **Add Box Collider 2D** to each
4. **Position them** to form a boundary:
   - **WallTop**: (0, 5, 0), Scale (10, 1, 1)
   - **WallBottom**: (0, -5, 0), Scale (10, 1, 1)
   - **WallLeft**: (-5, 0, 0), Scale (1, 10, 1)
   - **WallRight**: (5, 0, 0), Scale (1, 10, 1)

#### **4.4: Create Goal (Optional)**
1. **Create sprite**: `Goal`
2. **Add Box Collider 2D**
3. **Check "Is Trigger"**
4. **Create Tag**: "Goal" (Edit → Project Settings → Tags and Layers)
5. **Assign tag** to Goal object
6. **Position**: (3, 3, 0), Scale (1, 1, 1)

### **Step 5: Create UI Elements**

#### **5.1: Create Canvas**
1. **Right-click in Hierarchy → UI → Canvas**
2. **Canvas Scaler** settings:
   - **UI Scale Mode**: Scale With Screen Size
   - **Reference Resolution**: 1920x1080

#### **5.2: Create Text Elements**
1. **Right-click Canvas → UI → Text (Legacy)**
2. **Create 3 text objects**:
   - **ScoreText**: "Score: 0/10"
   - **TimeText**: "Time: 60s"
   - **GameOverText**: "GAME OVER!" (initially hidden)

#### **5.3: Position UI Elements**
1. **ScoreText**: Top-left corner
2. **TimeText**: Top-right corner
3. **GameOverText**: Center of screen

### **Step 6: Connect Scripts**

#### **6.1: GameManager Setup**
1. **Create empty GameObject**: `GameManager`
2. **Add GameManager script**
3. **Drag UI Text objects** to corresponding fields in Inspector

#### **6.2: Camera Shake Setup**
1. **Select Main Camera**
2. **Add CameraShake script**
3. **This enables screen shake effects**

### **Step 7: Test Your Game**
1. **Press Play button**
2. **Watch the ball bounce around**
3. **Check Console for debug messages**
4. **Verify UI updates correctly**

---

## 🔧 Troubleshooting

### **Ball Not Moving**
- **Check**: Rigidbody2D component attached
- **Check**: Gravity Scale is 0
- **Check**: BouncingBall script attached
- **Check**: Console for errors

### **Collisions Not Working**
- **Check**: Collider2D components on walls
- **Check**: "Is Trigger" is unchecked for walls
- **Check**: Ball has CircleCollider2D

### **UI Not Visible**
- **Check**: Canvas Render Mode is Screen Space - Overlay
- **Check**: Text objects are children of Canvas
- **Check**: Text color is not transparent

### **Scripts Not Compiling**
- **Check**: Console for compilation errors
- **Check**: Scripts are in Scripts folder
- **Check**: No syntax errors in code

---

## 🎮 What You Should See

### **Working Game Features:**
- ✅ Ball bounces around the screen
- ✅ Ball speed increases over time
- ✅ UI shows score and time
- ✅ Game over when time runs out
- ✅ Console shows debug messages
- ✅ Screen shake on ball collision (if CameraShake attached)

### **Learning Outcomes:**
- ✅ Understand GameObject/Component model
- ✅ Learn basic physics setup
- ✅ Practice UI creation
- ✅ Experience script communication
- ✅ Use debugging tools

---

## 🚀 Next Steps

1. **Experiment** with different values in Inspector
2. **Try adding** more effects (particles, sounds)
3. **Modify** the game rules (scoring, time limits)
4. **Move to** Lesson 1 for deeper Unity concepts

