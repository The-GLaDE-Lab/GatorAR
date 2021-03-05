# GatorAR
This AR application displays virtual models and real time data when an image is scanned by a phone camera.

The app is intended to lay the groundwork for education use at the University of Florida.
# Getting Started
1. Clone the repository to your local machine

2. Open the project using Unity

3. Unity will rebuild the project and add any missing files needed to run

4. Select ARScene under Assets -> Demo -> Scenes to view project

# Deploying on Mobile Devices

## Android

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select Android for platform

3. Connect Android device to PC and install any drivers if prompted 

4. Go to Settings -> Developer Options on your device and turn on USB debugging

5. In Unity, your device should now be recognized in the Run Device drop down menu under the Android Build Settings
   
   (If your device is not found you may need to download the Android SDK tools. Consult Unity documentation.)
   
6. Select Build And Run and the app will run on your Android device

## iPhone

1. After cloning and rebuilding project, go to File -> Build Settings

2. Select iOS for platform

3. Select Build and this should create a .xcodeproj build file

4. Follow steps 1-3 in the following guide to get the .xcodeproj file running on your iPhone:

   https://learn.unity.com/tutorial/setting-up-the-development-environment-for-ar-applications

Note: **Xcode running on a Mac device must be used in step 4**
