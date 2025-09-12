# Lab 5: Create Complete Game with UI System and Build

## Objectives

- Create complete UI system (Menu, HUD, Game Over)
- Implement game logic and scoring
- Scene management system
- Build game to executable file

---

## Part 1: Setup Game Structure

### Step 1: Create Multiple Scenes

1. **File** → **Build Settings**
2. **Add Open Scenes** (current scene)
3. **Create new scenes**:

   **Main Menu Scene**:

   - File → New Scene
   - Save As: `MainMenu`
   - Add to Build Settings

   **Game Scene**:

   - Use existing scene with player controller
   - Save As: `GameScene`
   - Add to Build Settings

   **Game Over Scene**:

   - File → New Scene
   - Save As: `GameOver`
   - Add to Build Settings

### Step 2: Create Scene Manager Script

1. **Assets/Scripts** → Create → C# Script → `SceneController`
2. **Code**:

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("Scene Names")]
    public static string MAIN_MENU = "MainMenu";
    public static string GAME_SCENE = "GameScene";
    public static string GAME_OVER = "GameOver";

    [Header("Transition Settings")]
    public float transitionDelay = 0.1f;

    // Static methods for easy access from anywhere
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public static void LoadGameOver()
    {
        SceneManager.LoadScene(GAME_OVER);
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public static void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    // Instance methods for UI button assignment
    public void OnPlayButtonClicked()
    {
        Invoke(nameof(DelayedLoadGame), transitionDelay);
    }

    public void OnRestartButtonClicked()
    {
        Invoke(nameof(DelayedRestartGame), transitionDelay);
    }

    public void OnMainMenuButtonClicked()
    {
        Invoke(nameof(DelayedLoadMainMenu), transitionDelay);
    }

    public void OnQuitButtonClicked()
    {
        Invoke(nameof(DelayedQuitGame), transitionDelay);
    }

    // Delayed loading methods
    void DelayedLoadGame() { LoadGameScene(); }
    void DelayedRestartGame() { RestartGame(); }
    void DelayedLoadMainMenu() { LoadMainMenu(); }
    void DelayedQuitGame() { QuitGame(); }
}
```

### Step 3: Create Game Manager

1. **Create** → C# Script → `GameManager`
2. **Code**:

```csharp
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float gameTime = 60f; // Game duration in seconds
    public int winScore = 10;

    [Header("UI References")]
    public Text scoreText;
    public Text timeText;
    public Text gameOverText;
    public GameObject gameOverPanel;

    [Header("Game State")]
    public bool gameActive = true;

    // Private variables
    private int currentScore = 0;
    private float remainingTime;
    private bool gameWon = false;

    // Static reference for easy access
    public static GameManager Instance;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        remainingTime = gameTime;
        UpdateUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!gameActive) return;

        // Update timer
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            EndGame(false); // Time up
        }

        UpdateUI();
    }

    public void AddScore(int points)
    {
        if (!gameActive) return;

        currentScore += points;
        Debug.Log($"Score added: {points}. Total: {currentScore}");

        // Check win condition
        if (currentScore >= winScore)
        {
            EndGame(true); // Player won
        }
    }

    void EndGame(bool won)
    {
        gameActive = false;
        gameWon = won;

        // Show game over UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.text = won ? "YOU WON!" : "GAME OVER";
            gameOverText.color = won ? Color.green : Color.red;
        }

        Debug.Log($"Game ended. Won: {won}, Final Score: {currentScore}");
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}/{winScore}";
        }

        if (timeText != null)
        {
            timeText.text = $"Time: {Mathf.Max(0, remainingTime):F1}s";
        }
    }

    // Public getters
    public int GetScore() { return currentScore; }
    public float GetRemainingTime() { return remainingTime; }
    public bool IsGameActive() { return gameActive; }
}
```

**✅ Checkpoint**: Scene management and game manager setup

---

## Part 2: Main Menu UI

### Step 4: Create Main Menu

1. **Open MainMenu scene**
2. **GameObject** → UI → **Canvas**
3. **Canvas settings**:
   - UI Scale Mode: Scale With Screen Size
   - Reference Resolution: 1920x1080

### Step 5: Add Main Menu Elements

1. **Background Panel**:

   - Right-click Canvas → UI → Panel
   - Name: `BackgroundPanel`
   - Color: Dark Blue (#1a237e)

2. **Title Text**:

   - Right-click Canvas → UI → Text
   - Name: `TitleText`
   - Text: "UNITY GAME"
   - Font Size: 72
   - Color: White
   - Alignment: Center
   - Position: Top center

3. **Play Button**:

   - Right-click Canvas → UI → Button
   - Name: `PlayButton`
   - Text: "PLAY GAME"
   - Font Size: 24
   - Position: Center

4. **Quit Button**:
   - Right-click Canvas → UI → Button
   - Name: `QuitButton`
   - Text: "QUIT"
   - Font Size: 24
   - Position: Below Play button

### Step 6: Setup Button Events

1. **Add SceneController** to scene
2. **Play Button**:

   - On Click() → Add SceneController
   - Select `OnPlayButtonClicked()`

3. **Quit Button**:
   - On Click() → Add SceneController
   - Select `OnQuitButtonClicked()`

**✅ Checkpoint**: Functional main menu

---

## Part 3: Game HUD UI

### Step 7: Open Game Scene and Add UI

1. **Open GameScene**
2. **Add Canvas** (if not already present)

### Step 8: Create Game HUD

1. **Score Display**:

   - Right-click Canvas → UI → Text
   - Name: `ScoreText`
   - Text: "Score: 0/10"
   - Font Size: 24
   - Position: Top Left
   - Color: White

2. **Timer Display**:

   - Right-click Canvas → UI → Text
   - Name: `TimeText`
   - Text: "Time: 60.0s"
   - Font Size: 24
   - Position: Top Right
   - Color: White

3. **Instructions Panel**:

   - Right-click Canvas → UI → Panel
   - Name: `InstructionsPanel`
   - Size: Small, bottom of screen
   - Background: Semi-transparent

4. **Instructions Text**:
   - Child of InstructionsPanel
   - Text: "WASD: Move | Space: Jump | Collect items to score!"
   - Font Size: 18
   - Color: Yellow

### Step 9: Create Game Over Panel

1. **Game Over Panel**:

   - Right-click Canvas → UI → Panel
   - Name: `GameOverPanel`
   - Size: Full screen
   - Background: Semi-transparent black
   - **Initially disabled**

2. **Game Over Text**:

   - Child of GameOverPanel
   - Name: `GameOverText`
   - Text: "GAME OVER"
   - Font Size: 64
   - Position: Center top
   - Color: Red

3. **Final Score Text**:

   - Child of GameOverPanel
   - Text: "Final Score: 0"
   - Font Size: 32
   - Position: Below game over text

4. **Restart Button**:

   - Child of GameOverPanel
   - Text: "RESTART"
   - On Click → SceneController.OnRestartButtonClicked()

5. **Main Menu Button**:
   - Child of GameOverPanel
   - Text: "MAIN MENU"
   - On Click → SceneController.OnMainMenuButtonClicked()

### Step 10: Setup GameManager

1. **Add GameManager** to scene
2. **Assign UI references** in Inspector:
   - scoreText → ScoreText
   - timeText → TimeText
   - gameOverText → GameOverText
   - gameOverPanel → GameOverPanel

**✅ Checkpoint**: Complete game UI system

---

## Part 4: Collectible Items and Scoring

### Step 11: Create Collectible Prefab

1. **GameObject** → 2D Object → **Sprites** → **Circle**
2. Name: `Collectible`
3. Scale: (0.5, 0.5, 1)
4. Color: Yellow (#FFFF44)
5. **Add Components**:

   - **Circle Collider 2D** → Is Trigger = true
   - Remove **Rigidbody** (no physics needed)

6. **Create Material**:

   - Name: `Mat_Collectible`
   - Albedo: Gold (#FFD700)
   - Metallic: 0.8, Smoothness: 0.9
   - Apply to Collectible

7. **Add Rotation Animation**:
   - Create → C# Script → `CollectibleRotator`

```csharp
using UnityEngine;

public class CollectibleRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationSpeed = new Vector3(0, 90, 0);
    public float bobHeight = 0.5f;
    public float bobSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // Bob up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
```

7. **Attach script** to Collectible

### Step 12: Create Collectible System

1. **Create** → C# Script → `Collectible`

```csharp
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    public int pointValue = 1;
    public AudioClip collectSound;

    [Header("Effects")]
    public GameObject collectEffect; // Optional particle effect

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        // Add score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(pointValue);
        }

        // Play sound
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Spawn effect
        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, transform.rotation);
        }

        Debug.Log($"Collected item worth {pointValue} points!");

        // Destroy this collectible
        Destroy(gameObject);
    }
}
```

8. **Attach script** to Collectible
9. **Create Prefab**: Drag Collectible to Assets/Prefabs

### Step 13: Place Collectibles in Scene

1. **Drag prefab** into scene multiple times
2. **Position** around the level
3. **Ensure total collectibles ≥ win score**

**✅ Checkpoint**: Working collectible system

---

## Part 5: Build and Deploy

### Step 14: Configure Build Settings

1. **File** → **Build Settings**
2. **Verify scene order**:

   - MainMenu (index 0)
   - GameScene (index 1)
   - GameOver (index 2)

3. **Platform Settings**:
   - Platform: PC, Mac & Linux Standalone
   - Target Platform: Windows (or according to OS)
   - Architecture: x86_64

### Step 15: Player Settings

1. **Player Settings button**
2. **Company Name**: Your name
3. **Product Name**: Unity Game Course
4. **Icon**: Set custom icon (optional)
5. **Screen Resolution**:
   - Default Screen Width: 1280
   - Default Screen Height: 720
   - Windowed: Checked
   - Resizable Window: Checked

### Step 16: Build Game

1. **Build And Run** or **Build**
2. **Choose build folder**: Create "Build" folder
3. **Wait for build** to complete
4. **Test executable**:
   - Main menu navigation
   - Game mechanics
   - UI functionality
   - Scene transitions

**✅ Final Checkpoint**: Complete built game

---

## Expected Results

### Complete Game Features:

- ✅ **Main Menu**: Title, Play, Quit buttons
- ✅ **Game Scene**: Player movement, collectibles, HUD
- ✅ **Scoring System**: Points for collecting items
- ✅ **Timer System**: Game time limit
- ✅ **Win/Lose Conditions**: Score target or time up
- ✅ **Game Over Screen**: Results and navigation options
- ✅ **Scene Management**: Smooth transitions
- ✅ **Built Executable**: Standalone game file

### UI Components:

- **Canvas with proper scaling**
- **Responsive UI elements**
- **Button click events**
- **Dynamic text updates**
- **Panel management**

### Game Flow:

```
Main Menu → Game Scene → Game Over Screen
     ↑                        ↓
     ← ← ← ← ← ← ← ← ← ← ← ← ← ←
```

---

## Testing Checklist

### Main Menu:

- [ ] Title displays correctly
- [ ] Play button loads game scene
- [ ] Quit button closes application

### Game Scene:

- [ ] Player movement works
- [ ] Collectibles can be gathered
- [ ] Score updates correctly
- [ ] Timer counts down
- [ ] Game ends at time limit or win condition

### Game Over:

- [ ] Shows win/lose message
- [ ] Displays final score
- [ ] Restart loads game scene
- [ ] Main Menu returns to start

### Build:

- [ ] Executable runs independently
- [ ] All scenes included
- [ ] No console errors
- [ ] Proper resolution and settings

---

## Common Build Issues

### Build Errors:

**Issue**: Scenes not included
**Fix**: Check Build Settings, add all scenes

**Issue**: Missing scripts
**Fix**: Ensure all scripts compile, check Console

**Issue**: UI not scaling
**Fix**: Check Canvas Scaler settings

### Runtime Issues:

**Issue**: Buttons not responding
**Fix**: Check EventSystem, Button components

**Issue**: Scene transitions failing
**Fix**: Verify scene names match exactly

**Issue**: UI elements misaligned
**Fix**: Test different resolutions, adjust anchoring
