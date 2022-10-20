# GatorAR

This Augmented Reality application displays virtual models and real time data when a tracked image is scanned via the phone's camera.

The app is intended to lay the groundwork for educational use at the University of Florida.

Built and maintained by UF's Game-based Learning and Digital Experiences (**GLaDE**) Lab.

## Beta Build

Current state of the Beta build and changes based on results from Alpha testing.

Test Device: iPhone 12

### Usability

The app's user interface consists of a simple button layout that keeps the most important options readily accessible and leaves plenty of space for interactions in AR space. All game buttons and toggles are highlighted when clicked and animations are smooth. The main game screen features a sliding menu that hides away most user options, such as mission objectives or debugging tools. 'Pause' is kept on the main screen along with any relavent buttons. This includes toggles for debugging visuals (which are enabled by default) and a button to start the game's AR introduction. This design makes the app intuitive to use and easy to navigate.

The AR intro can be started at any time by users. It features a sequence of instructions that prompts them to scan specific images in order to make simple objects appear (a cube, sphere, and cylinder). Then it asks them to interact with these objects by tapping on them, thereby introducing them to basic AR concepts. Finally, it sends them to the power plant's multipurpose room, where the game can continue. Once they reach that room, a scannable image will trigger a robot character that provides the user with their first mission objective.

### Build Quality

This build is currently free of any gamebreaking bugs. In Alpha, the app performed relatvely well on the testing device, working as expected without crashing. The objects and UI elements within this build behave as expected, with notable events such as object interactions and state changes being logged for debugging. Menu choices are consistent with the current game state and always result in the same actions.

The AR image recognition works well on the test device, with game objects spawning soon after the camera is pointed at the selected images. The placement of the objects in the world also works relatively well. In AR space, objects tend to stay where they're left. They also respond well to tap interactions, although this could be improved for later versions with more types of interactions (dragging, flicking, etc.). Rapid movement of the phone camera does often result in objects being moved in the game world. Rescanning images will reposition (or respawn) their assigned object. Improved anchoring could be implemented in order to reduce the effect of this unwanted 'drift'.

In terms of aesthetics, the app's user interface uses a simple layout with a pleasant blue/white color scheme. Assets have been made using icons found online resulting in fairly intuitive button icons. UI animations, like the one used to slide the menu, are smooth and work reliably. Game objects, asside from the robot in the multipurpose room, are currently of simple design. They consist mainly of basic shapes or low-res models with one or no colors. These are still in development.

### Features

The application's core functions include introducing users to AR and then presenting them with mission objectives that they must complete by exploring a location with AR. The project's intended audience is students taking courses in thermodynamics or energy production. Mission objectives will then include plenty of classwork-type questions relating to these fields but also connected to the machines in the location. Missions will involve exploring the plant and looking for scannable prompts on select machines.

Currently, these missions have not been implemented in their entirety. After the introduction, the game's robot will breifly present the start of a mission. This includes a list of sample objectives; the first of which can be completed fairly easily. A template is being developed that will make missions and their content easy to modify. Persistant game state is used within the app to keep track of the player's progression through a mission as they complete objectives. The current UI makes it easy for users to navigate the game and check the state of their mission.

Users will also be presented with achievements for completing important mission objectives or other meaningful game scenarios. Only one of them is currently active, popping up shortly after the first objective is completed.

## Getting Started

### Unity Project Settings

Make sure you are using Unity version **2020.2.7f1.**

Install Android and/or iOS Build Support for the target Unity version.

<https://docs.unity3d.com/2020.2/Documentation/Manual/android-sdksetup.html>

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

## Deploying on Mobile Devices

### iPhone

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select iOS as the platform

3. Select Build and this should create a .xcodeproj file within the build directory

Note: **A Mac device (or a virtual machine running macOS) with Xcode installed is required to build for iOS devices in the next step.**

4. Follow steps 1-3 in the following guide to get the .xcodeproj file running on your iPhone:

   <https://learn.unity.com/tutorial/setting-up-the-development-environment-for-ar-applications>

### Android

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select Android for platform

3. Connect Android device to PC and install any drivers if prompted

4. Go to Settings -> Developer Options on your device and turn on USB debugging

5. In Unity, your device should now be recognized in the Run Device drop down menu under the Android Build Settings

Note: **If your device is not found you may need to download the Android SDK tools. Consult the follow Unity documentation.**
<https://docs.unity3d.com/2020.2/Documentation/Manual/android-sdksetup.html>

6. Select Build And Run and the app will run on your Android device