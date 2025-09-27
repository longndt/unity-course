# Unity Development Environment Setup Guide

Complete setup instructions for Unity game development on Windows and Mac systems.

---

## Table of Contents

1. [System Requirements](#system-requirements)
2. [Windows Setup Guide](#windows-setup-guide)
3. [Mac Setup Guide](#mac-setup-guide)
4. [Unity Hub Installation](#unity-hub-installation)
5. [Unity Editor Installation](#unity-editor-installation)
6. [Visual Studio Setup](#visual-studio-setup)
7. [Project Creation & Testing](#project-creation--testing)
8. [Troubleshooting](#troubleshooting)
9. [Additional Tools](#additional-tools)

---

## System Requirements

### Minimum Requirements

#### Windows

- **OS**: Windows 10 (64-bit) or newer
- **CPU**: Intel Core i5 / AMD equivalent
- **RAM**: 8 GB minimum (16 GB recommended)
- **GPU**: DirectX 11 compatible graphics card
- **Storage**: 20 GB free space minimum
- **Internet**: Required for Unity Hub and downloads

#### Mac

- **OS**: macOS 10.15 (Catalina) or newer
- **CPU**: Intel Core i5 / Apple M1 or newer
- **RAM**: 8 GB minimum (16 GB recommended)
- **GPU**: Metal-capable graphics card
- **Storage**: 20 GB free space minimum
- **Internet**: Required for Unity Hub and downloads

### Recommended Specifications

#### Windows

- **OS**: Windows 11 (64-bit)
- **CPU**: Intel Core i7 / AMD Ryzen 7
- **RAM**: 16 GB or more
- **GPU**: Dedicated graphics card (NVIDIA GTX 1060 / AMD RX 580 or better)
- **Storage**: SSD with 50 GB+ free space

#### Mac

- **OS**: macOS 12 (Monterey) or newer
- **CPU**: Apple M1 Pro/Max or Intel Core i7
- **RAM**: 16 GB or more
- **Storage**: SSD with 50 GB+ free space

---

## Windows Setup Guide

### Step 1: Check System Information

1. **Press** `Win + R` to open Run dialog
2. **Type** `msinfo32` and press Enter
3. **Verify** your system meets minimum requirements:
   - OS Version: Windows 10/11 (64-bit)
   - Processor: Check CPU model
   - Installed Memory: Check RAM amount
   - Graphics Card: Check GPU model

### Step 2: Update Windows

1. **Press** `Win + I` to open Settings
2. **Go to** Update & Security → Windows Update
3. **Click** "Check for updates"
4. **Install** all available updates
5. **Restart** computer when prompted

### Step 3: Update Graphics Drivers

#### For NVIDIA Graphics Cards:

1. **Visit** https://www.nvidia.com/drivers/
2. **Select** your graphics card model
3. **Download** and install latest driver
4. **Restart** computer after installation

#### For AMD Graphics Cards:

1. **Visit** https://www.amd.com/support/
2. **Select** your graphics card model
3. **Download** and install latest driver
4. **Restart** computer after installation

#### For Intel Graphics:

1. **Visit** https://downloadcenter.intel.com/
2. **Search** for your processor model
3. **Download** graphics driver
4. **Install** and restart

### Step 4: Install Microsoft Visual C++ Redistributables

1. **Visit** https://docs.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist
2. **Download** both x64 and x86 versions
3. **Install** both packages
4. **Restart** if prompted

### Step 5: Enable Developer Mode (Optional but Recommended)

1. **Press** `Win + I` to open Settings
2. **Go to** Update & Security → For developers
3. **Select** "Developer mode"
4. **Click** "Yes" when prompted
5. **Wait** for installation to complete

---

## Mac Setup Guide

### Step 1: Check System Information

1. **Click** Apple menu → About This Mac
2. **Verify** your system meets requirements:
   - macOS version: 10.15 or newer
   - Processor: Check CPU type (Intel/Apple Silicon)
   - Memory: Check RAM amount
   - Graphics: Check GPU model

### Step 2: Update macOS

1. **Click** Apple menu → System Preferences
2. **Select** Software Update
3. **Install** any available updates
4. **Restart** when prompted

### Step 3: Install Xcode Command Line Tools

1. **Open** Terminal (Applications → Utilities → Terminal)
2. **Type** the following command:
   ```bash
   xcode-select --install
   ```
3. **Click** "Install" in the popup dialog
4. **Wait** for installation to complete
5. **Verify** installation:
   ```bash
   xcode-select -p
   ```
   Should output: `/Applications/Xcode.app/Contents/Developer` or `/Library/Developer/CommandLineTools`

### Step 4: Install Rosetta 2 (Apple Silicon Macs only)

If you have an Apple M1/M2 Mac:

1. **Open** Terminal
2. **Run** the following command:
   ```bash
   sudo softwareupdate --install-rosetta
   ```
3. **Press** `A` to agree to license
4. **Wait** for installation to complete

### Step 5: Check Security Settings

1. **Go to** System Preferences → Security & Privacy
2. **Click** the lock icon to make changes
3. **Enter** your administrator password
4. **Ensure** "App Store and identified developers" is selected
5. **Click** lock icon again to save changes

---

## Unity Hub Installation

Unity Hub is the central tool for managing Unity installations and projects.

### Download Unity Hub

1. **Visit** https://unity.com/download
2. **Click** "Download Unity Hub"
3. **Choose** your operating system (Windows/Mac)

### Windows Installation

1. **Run** the downloaded `UnityHubSetup.exe` file
2. **Click** "Yes" when prompted by User Account Control
3. **Follow** installation wizard:
   - Accept license agreement
   - Choose installation location (default is fine)
   - Click "Install"
4. **Wait** for installation to complete
5. **Click** "Finish"

### Mac Installation

1. **Open** the downloaded `.dmg` file
2. **Drag** Unity Hub to Applications folder
3. **Open** Applications folder
4. **Right-click** Unity Hub → Open
5. **Click** "Open" when security prompt appears
6. **Unity Hub** will launch

### Unity Hub First-Time Setup

1. **Accept** Unity Hub license agreement
2. **Sign in** to Unity account (create one if needed):
   - Click "Sign in"
   - Enter email and password
   - OR create new account
3. **Choose** license type:
   - Select "Unity Personal" (free)
   - Click "Done"

---

## Unity Editor Installation

### Install Unity 6.0 LTS

1. **Open** Unity Hub
2. **Click** "Installs" tab on the left
3. **Click** "Install Editor"
4. **Select** "Unity 6000.0.X LTS" (Latest Long Term Support version)
5. **Click** "Install"

### Choose Installation Modules

**Required Modules (check these boxes):**

- ✅ **Microsoft Visual Studio Community 2022** (Windows only)
- ✅ **2D Sprite Package** (for 2D game development)
- ✅ **Android Build Support** (for mobile publishing)
- ✅ **Documentation** (offline help)

**Optional Modules:**

- 📱 **iOS Build Support** (Mac only, for iPhone games)
- 🌐 **WebGL Build Support** (for browser games)
- 🎮 **Windows Build Support** (Mac only, for cross-platform)
- 🎮 **Mac Build Support** (Windows only, for cross-platform)

### Start Installation

1. **Click** "Install" button
2. **Wait** for download and installation
3. **Do not close** Unity Hub during installation

---

## Visual Studio Setup

### Windows - Visual Studio Community

If not installed automatically with Unity:

1. **Visit** https://visualstudio.microsoft.com/vs/community/
2. **Download** Visual Studio Community (free)
3. **Run** installer and select these workloads:
   - ✅ **Game development with Unity**
   - ✅ **.NET desktop development**
4. **Click** "Install"
5. **Sign in** with Microsoft account when prompted

### Mac - Visual Studio for Mac

1. **Visit** https://visualstudio.microsoft.com/vs/mac/
2. **Download** Visual Studio for Mac
3. **Open** downloaded `.dmg` file
4. **Run** installer and select:
   - ✅ **.NET**
   - ✅ **Unity**
5. **Click** "Install"

### Alternative: Visual Studio Code

For a lighter code editor:

1. **Visit** https://code.visualstudio.com/
2. **Download** for your OS
3. **Install** VS Code
4. **Open** VS Code
5. **Install** Unity extension:
   - Click Extensions (Ctrl+Shift+X)
   - Search "Unity"
   - Install "Unity" by Unity Technologies

---

## Project Creation & Testing

### Create Test Project

1. **Open** Unity Hub
2. **Click** "Projects" tab
3. **Click** "New project"
4. **Select** "2D (URP)" for 2D game development
5. **Set** project settings:
   - **Project name**: "Unity2DTestProject"
   - **Location**: Choose desired folder
6. **Click** "Create project"

### Verify Installation

Unity Editor should open with:

- Scene view showing a sample scene
- Hierarchy panel with Main Camera and Directional Light
- Project panel with Assets folder
- Inspector panel on the right

### Test Basic Functionality

1. **Create** a 2D sprite object:
   - Right-click in Hierarchy
   - Select "2D Object" → "Sprite" → "Square"
2. **Move** the sprite:
   - Select sprite in Hierarchy
   - Use transform tools to move it in 2D space
3. **Play** the scene:
   - Click Play button at top
   - Verify Game view shows the 2D scene
   - Click Play again to stop
4. **Create** a script:
   - Right-click in Project panel
   - Select "Create" → "C# Script"
   - Name it "Test2DScript"
   - Double-click to open in code editor

### Test Script Compilation

1. **Replace** script content with:

```csharp
using UnityEngine;

public class Test2DScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Unity 6.0 2D setup is working correctly!");
    }

    void Update()
    {
        // Simple rotation for visual feedback
        transform.Rotate(0, 0, 45 * Time.deltaTime);
    }
}
```

2. **Save** the file (Ctrl+S / Cmd+S)
3. **Return** to Unity Editor
4. **Drag** script onto the Sprite in Hierarchy
5. **Click** Play button
6. **Check** Console panel (Window → General → Console)
7. **Verify** message "Unity 6.0 2D setup is working correctly!" appears
8. **Observe** the sprite rotating smoothly
9. **Drag** script onto the Cube in Hierarchy
10. **Click** Play button
11. **Check** Console panel (Window → General → Console)
12. **Verify** message "Unity setup is working correctly!" appears

---

## Troubleshooting

### Common Windows Issues

#### Issue: Unity Hub won't install

**Solutions:**

1. Run installer as Administrator
2. Temporarily disable antivirus
3. Check Windows version (must be 64-bit)
4. Free up disk space (need 20GB+)

#### Issue: Visual Studio integration not working

**Solutions:**

1. In Unity: Edit → Preferences → External Tools
2. Set External Script Editor to Visual Studio path
3. Reinstall Unity with Visual Studio module
4. Repair Visual Studio installation

#### Issue: Graphics driver errors

**Solutions:**

1. Update graphics drivers to latest version
2. Use DirectX 11 if DirectX 12 causes issues
3. Lower graphics quality in Project Settings

### Common Mac Issues

#### Issue: "App can't be opened" security error

**Solutions:**

1. System Preferences → Security & Privacy
2. Click "Open Anyway" for blocked apps
3. Use Command Line Tools: `sudo spctl --master-disable`
4. Right-click app → Open (instead of double-clicking)

#### Issue: Unity Editor crashes on Apple Silicon

**Solutions:**

1. Ensure Rosetta 2 is installed
2. Use Unity 2022.3 LTS or newer for better M1 support
3. Close other applications to free memory
4. Check Activity Monitor for Unity processes

#### Issue: Xcode Command Line Tools missing

**Solutions:**

1. Install Xcode from App Store (full version)
2. Run: `sudo xcode-select --reset`
3. Run: `xcode-select --install` again
4. Verify: `xcode-select -p`

### General Issues

#### Issue: Unity Editor runs slowly

**Solutions:**

1. Close unnecessary applications
2. Increase virtual memory/swap space
3. Use SSD instead of HDD if possible
4. Lower Unity editor graphics quality
5. Disable real-time virus scanning for Unity folders

#### Issue: Projects won't open

**Solutions:**

1. Check Unity version compatibility
2. Clear Unity cache: Delete Library folder in project
3. Reimport assets: Assets → Reimport All
4. Create new project and import assets manually

#### Issue: Scripts won't compile

**Solutions:**

1. Check for syntax errors in Console
2. Restart Unity Editor
3. Delete Library and Temp folders
4. Reimport all assets

---

## Additional Tools

### Recommended Utilities

#### For Windows:

- **Git for Windows**: Version control (https://git-scm.com/download/win)
- **7-Zip**: Archive extraction (https://www.7-zip.org/)
- **Process Explorer**: System monitoring (Microsoft Sysinternals)

#### For Mac:

- **Git**: Pre-installed or via Xcode Command Line Tools
- **The Unarchiver**: Archive extraction (App Store)
- **Activity Monitor**: Built-in system monitoring

### Unity-Specific Tools

#### Free Assets:

- **Unity Particle Pack**: Free particle effects
- **ProBuilder**: 3D modeling tool (built into Unity)
- **Cinemachine**: Advanced camera system (built into Unity)

#### Learning Resources:

- **Unity Learn**: Free tutorials (learn.unity.com)
- **Unity Documentation**: Official docs (docs.unity3d.com)
- **Unity Forums**: Community support (forum.unity.com)

---

## Verification Checklist

Before starting the Unity course, ensure you can complete all these tasks:

### ✅ System Check:

- [ ] Operating system meets minimum requirements
- [ ] At least 8GB RAM available
- [ ] 20GB+ free disk space
- [ ] Graphics drivers updated
- [ ] Stable internet connection

### ✅ Software Installation:

- [ ] Unity Hub installed and running
- [ ] Unity 6.0 LTS installed
- [ ] Code editor installed (Visual Studio/VS Code)
- [ ] Unity license activated (Personal/Student)

### ✅ Functionality Test:

- [ ] Can create new Unity project
- [ ] Unity Editor opens without errors
- [ ] Can create and move 3D objects
- [ ] Play mode works correctly
- [ ] Can create and edit C# scripts
- [ ] Scripts compile without errors
- [ ] Code editor opens from Unity
- [ ] Console shows debug messages

### ✅ Performance Check:

- [ ] Unity Editor responsive (not laggy)
- [ ] Play mode runs smoothly
- [ ] No memory warnings in Console
- [ ] Can build simple project to executable

---

## Getting Help

### If You're Stuck:

1. **Check Unity Console** for error messages
2. **Restart Unity Hub and Editor**
3. **Search Unity Documentation** for specific errors
4. **Post on Unity Forums** with specific error details
5. **Contact course instructor** with screenshot of issue

### Before Course Starts:

- Complete this setup guide 1-2 days before first session
- Test creating a simple project
- Familiarize yourself with Unity Hub interface
- Ensure stable internet connection for course day

---

**Setup Complete! 🎉**

You're now ready to begin the Unity Game Development course. Make sure to bookmark this guide for future reference and troubleshooting.
