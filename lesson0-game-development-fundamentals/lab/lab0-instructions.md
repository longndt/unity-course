# Lab 0: Game Development Fundamentals & Mindset

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
1. Open Unity Hub → New Project → **2D (URP)** template
2. Project name: `Lesson0-GameFundamentals`
3. Create project and wait for Unity to load

### Step 2: Explore the Example
1. Open the `example/` folder in this lesson
2. Import the provided scripts into your project
3. Create a new scene: `File → New Scene → 2D`
4. Add the example scripts to GameObjects and test them

---

## 🎯 Lab Tasks

### Task 1: Web/Mobile vs Game Development Analysis

1. **Compare Development Patterns**
   - Think about a web app you've built (e.g., todo list, blog)
   - Think about a mobile app you've used (e.g., social media, productivity)
   - Compare with a game you've played (e.g., platformer, puzzle)

2. **Identify Key Differences**
   - **Web**: Event-driven, state management, request/response
   - **Mobile**: App lifecycle, touch events, platform-specific
   - **Game**: Real-time simulation, physics, player agency

3. **Document Your Findings**
   - Create a simple text file with your observations
   - Note how each platform handles user interaction
   - Identify which concepts transfer between platforms

### Task 2: Unity Editor Navigation

1. **Explore Key Windows**
   - **Scene View**: Navigate around the 2D world
   - **Game View**: See what the player sees
   - **Hierarchy**: Understand object organization
   - **Inspector**: Examine component properties
   - **Project**: Browse asset files

2. **Practice Basic Operations**
   - Create empty GameObjects
   - Add components to GameObjects
   - Move, rotate, and scale objects
   - Delete and duplicate objects

3. **Verify Understanding**
   - Can you explain what each window does?
   - Can you create and modify objects confidently?
   - Do you understand the component system?

### Task 3: Create a Simple Bouncing Ball Game

1. **Setup the Scene**
   - Create a 2D scene named "BouncingBall"
   - Add a ground platform (Sprite → Square)
   - Add walls on the sides and top

2. **Create the Ball**
   - Create a GameObject with SpriteRenderer (Circle)
   - Add Rigidbody2D component
   - Add CircleCollider2D component
   - Set initial velocity

3. **Add Game Logic**
   - Create a script to handle ball behavior
   - Add speed increase over time
   - Add bounce sound effects
   - Add particle effects on collision

4. **Test and Iterate**
   - Play the game and test ball physics
   - Adjust speed, gravity, and bounce
   - Add visual feedback (particles, screen shake)
   - Make it fun to play!

### Task 4: Game Development Pipeline Exercise

1. **Pre-Production Planning**
   - Write a simple game design document
   - Define core mechanics and objectives
   - Plan visual style and audio
   - Set technical requirements

2. **Production Development**
   - Implement the planned mechanics
   - Create and import assets
   - Test and debug functionality
   - Iterate on gameplay

3. **Post-Production Polish**
   - Optimize performance
   - Add visual and audio effects
   - Test on different devices
   - Prepare for release

## ✅ Completion Checklist

- [ ] **Web/Mobile Analysis**: Documented key differences
- [ ] **Unity Navigation**: Confident with editor windows
- [ ] **Bouncing Ball Game**: Created and tested
- [ ] **Game Pipeline**: Understood development process
- [ ] **Core Gameplay Loop**: Identified in your game

## 🎯 What's Next

Proceed to [Lesson 1: Unity Fundamentals & Setup](../lesson1-unity-basics/) to dive deeper into Unity's technical aspects.

---

## 📚 Reference

- **Game Design**: See `reference/reference0.md`
- **Unity Editor**: Unity Manual - Getting Started
- **Game Development**: Unity Learn Platform

---

## 🔧 Troubleshooting

**Issue**: Ball doesn't bounce
**Fix**: Check Rigidbody2D settings and collider setup

**Issue**: Game runs too slow/fast
**Fix**: Adjust physics timestep and frame rate settings

**Issue**: Can't navigate Unity Editor
**Fix**: Practice with basic operations, use Unity tutorials

**Issue**: Don't understand game development concepts
**Fix**: Play more games and analyze their mechanics
