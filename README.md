# GatorAR

This Augmented Reality application displays virtual models and real time data when a tracked image is scanned via the phone's camera.

The app is intended to lay the groundwork for educational use at the University of Florida.

Built and maintained by UF's Game-based Learning and Digital Experiences (**GLaDE**) Lab.

# Beta Build

Current state of the beta build and some results from Alpha testing.

Test Device: iPhone 12

### Usability 

As observed during testing of the Alpha build, most UI elements work as expected. The menus are easy to navigate with simple button layouts making the app intuitive to use. 

### Build Quality 

This build is currently free of any gamebreaking bugs. In Alpha, the app performed relatvely well on the testing device, working as expected without crashing. The objects and UI elements within this build behave as expected, with notable events such as object interactions and state changes being logged for debugging. Menu choices are consistent with the current game state and always result in the same actions.

### Features

Persistant game state is used within the app to keep track of the player's progression through a mission as they complete objectives. The current UI makes it easy for users to navigate the game and check the state of their mission.

# Getting Started

### Unity Project Settings

Make sure you are using Unity version **2020.2.7f1.**

Install Android and/or iOS Build Support for the target Unity version.

https://docs.unity3d.com/2020.2/Documentation/Manual/android-sdksetup.html

Install the Following Package Versions:

- ARFoundation: 4.1.5
- ARCore XR Plugin: 4.1.5
- ARKit XR Plugin: 4.1.5
- XR Plugin Management: 4.0.1

### Building Project

1. Clone the repository to your local machine

2. Open the project using Unity

3. Unity will rebuild the project and add any missing files needed to run

4. Select ARScene under Assets -> Demo -> Scenes to view project's main scene

To see the UI rendered as it would look on a phone, select the Game tab and change the Free Aspect drop down to 1920x1080 Portrait.

# Deploying on Mobile Devices

### Android

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select Android for platform

3. Connect Android device to PC and install any drivers if prompted 

4. Go to Settings -> Developer Options on your device and turn on USB debugging

5. In Unity, your device should now be recognized in the Run Device drop down menu under the Android Build Settings
   
Note: **If your device is not found you may need to download the Android SDK tools. Consult Unity documentation below.**

   https://docs.unity3d.com/2020.2/Documentation/Manual/android-sdksetup.html
   
6. Select Build And Run and the app will run on your Android device

### iPhone

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select iOS for platform

3. Select Build and this should create a .xcodeproj file within the build directory

Note: **A Mac device (or macOS Virtual machine) running Xcode is required to build for iOS in the next step.**

4. Follow steps 1-3 in the following guide to get the .xcodeproj file running on your iPhone:

   https://learn.unity.com/tutorial/setting-up-the-development-environment-for-ar-applications
