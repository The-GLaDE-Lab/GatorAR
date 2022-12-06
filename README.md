# GatorAR

This Augmented Reality application displays virtual models and real-time data when tracked images are scanned via the phone's camera.

The app is intended to lay the groundwork for educational use at the University of Florida.

Built and maintained by UF's Game-based Learning and Digital Experiences (**GLaDE**) Lab.

## Production Release Build

The current state of the Production Release and changes from the last Release Candidate.

Test Device: iPhone 12 (iOS 16.1.1)

Project Built and Installed to Test Device through Xcode 14.1 (macOS 13.0.1)

### Usability

The app's user interface consists of a simple button layout that keeps the most important options readily accessible and leaves plenty of space for interactions in the AR space. All buttons and toggles are highlighted when clicked in-game and their animations are consistently smooth. The main game screen features a sliding menu that hides away most user options, such as mission objectives or settings. It slides open reliably and the process maintains the state of any buttons being hidden. 'Pause' is kept on the main screen along with any relevant buttons. This includes a button to start the game's AR introduction and, when applicable, buttons to toggle AR debugging visuals. This design makes the app intuitive to use and easy to navigate.

The AR intro can be started at any time by users. It features a sequence of instructions that prompts them to scan specific images to make simple objects appear (a cube, sphere, and cylinder). Then it asks them to interact with these objects by tapping on them, thereby introducing them to basic AR concepts. Finally, it directs them to the power plant's multipurpose room, where the game can continue. Once they reach that room, another scannable image will trigger an animated robot character that provides the user with their first mission and its corresponding objectives.

The objectives for this mission can be accessed through the UI as part of the hidden sliding menu. After clicking the respective button, a prompt will fill the screen with a checklist that is updated as players progress through the mission. Mission progress can be reset by accessing the 'Reset' button, which is now contained under settings. An additional setting is an option to enable 'Dev. Mode', which changes the function of the 'Help' button to open the debug log and shows the debug visuals.

### Build Quality

This build is currently free of any major bugs. In previous releases, the app has performed well on the testing device, working as expected with minimal crashing. Typical errors included the misplacement of objects and some trouble maintaining the state of inactive objects. Most recently, an issue with updated device firmware led to significant performance issues. The objects and UI elements within this build behave as expected, with notable events such as object interactions and state changes being logged for debugging. Menu choices have been updated to hide away buttons to enable 'Dev. Mode' and 'Reset', which now resets mission progress in addition to the current AR session. This resets the objects spawned through images and improves performance by removing unused planes from memory.

AR image recognition works well on the test device, with game objects spawning almost instantly after the camera is pointed at the selected images. This is the case in ideal conditions and it has been found that lower light environments might make it harder for the camera to recognize distinct shapes in the image. This is also the case for images on reflective surfaces, with duller surfaces working best for image detection.

The placement of the objects in the world also works relatively well. In AR space, objects tend to stay where they're left. They also respond well to tap interactions, although this could be improved for later versions with more types of interactions (dragging, flicking, etc.). Rapid movement of the phone camera can sometimes result in objects being moved in the game world. Rescanning images will reposition their assigned object.

In terms of aesthetics, the app's user interface uses a simple layout with a pleasant blue/white color scheme. Assets have been made using icons found online resulting in fairly intuitive button icons. UI animations, like the one used to slide the menu, are smooth and work reliably. Game objects, aside from the robot in the multipurpose room, are currently of simple design. They consist mainly of basic shapes or low-res models with one or no colors. These are still in development.

### Features

The application's core functions include introducing users to AR and then presenting them with mission objectives that they must complete by exploring a location with AR. The project's intended audience is students taking courses in thermodynamics or energy production. Mission objectives will then include plenty of classwork-type questions relating to these fields but also connected to the machines in the location. Missions will involve exploring the plant and looking for scannable prompts on select machines that prompt users to solve problems to reach a greater goal.

For this build, a sample mission has been implemented that will serve as a template for most missions going forward. It is presented to players shortly after completing the introductory sequence, once they make their way into the multipurpose room. It consists of a few objectives that have the player interact with a specific machine in the power plant. Initially, players must find the given machine and scan an image near its control panel. The spawned prompt will ask players to answer a thermodynamics question relating to the given machine and provide them with only some of the information they will need. Missing values can be found by scanning the appropriate location on the machines. For example, scanning an image target near the inlet tube of a chiller reveals the input temperature. This value is then saved to the original question prompt. Finding these missing values and answering the question correctly are also additional objectives that will be updated upon completion. Values used in the current thermodynamics question are picked at random during mission start (or reset) and have realistic ranges.

Persistent game state is used within the app to keep track of the player's progression through a mission as they complete objectives. The current UI makes it easy for users to navigate the game and check their mission progress.

## Getting Started

### Unity Project Settings

Make sure you are using Unity version **2020.2.7f1.**

Install Android and/or iOS Build Support for the target Unity version.

<https://docs.unity3d.com/2020.2/Documentation/Manual/android-sdksetup.html>

Install the Following Package Versions:

- ARFoundation: 4.1.13
- ARCore XR Plugin: 4.1.5
- ARKit XR Plugin: 4.1.13
- XR Plugin Management: 4.0.1

   Note: ARFoundation and ARKit here were updated from the previous release due to an issue with the testing device relating to iOS 16. This list reflects the current packages being used with development being focused on iOS devices. Building the project for Android might require updating ARCore as well but this has not been tested.

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