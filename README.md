# Unity Template for Hololens 2 Projects
A template for creating Unity projects for the Hololens 2. One of the biggest issues I've come across with creating applications for the HL2 with Unity is that there is so much mixed guidance online. Some people say to use OpenXR. Some people say to use Unity's XR plugin management with Windows MR. This confused the hell out of me. So here is a working template for Hololens 2 applications built with Unity 2019.4.11f1. 

## Why & Installation 
Because you don't have to worry about settings, and which to use. To install, simply create a new repository with this template and clone it. Everything should work out the box -- Try 


## What does this project use?
This project uses MRTK, with Unity's XR plugin management system, with WindowsMixedReality, for Unity 2019.4.11f1. The MRTK settings use a copy of the default HL2 profile, but with some changes. Mainly that diagnostics have been disabled, and camera settings use the generic XR camera controller, not the WindowsMixedReality one.

To make this project again, you need to:

- Create a new Unity project. 
- Using `File > Build Settings`, swap to the Universal Windows Platform (UWP).
- Download the latest MRTK package and install it into your project. 
- If it shows a dialog with settings, tick all the checkboxes and hit `Apply` or `Ok`.
- Go to `Edit > Project Settings`. Go to `XR Plugin Management`, swap to the UWP platform (if not on it already):
  - Make sure `Initialize XR on Startup` is ticked.
  - Tick `Windows Mixed Reality` under `Plug-in Providers`.
  - Wait for it to install, if it does.
  - Now navigate to `XR Plugin Management > Windows Mixed Reality` (on the left-hand bar)
  - Make sure `Use Primary Window` is checked and the depth buffer is set to 16 bit. 
- Go to `Mixed Reality Toolkit > Add to scene and configure`, click it.
- This should add two objects to the scene. Click on the one called `MixedRealityToolkit`:
  - In the inspector, set the configuration profile to the `DefaultHololens2Profile`. Click `Clone` to clone it, hit `OK` or `Save`.
  - Navigate to the `Camera` section below.
  - Clone the current `CameraProfile` so you can edit it. Hit `OK` or `Save`.
  - Under `XR SDK Camera Settings`, set the type to `GenericXRSDKCameraSettings`.

# Build & Test Log
For the current released version, there have been several builds before release. This is evidenced by the internal build log shown below. It is worth noting that the last build in this log is the one tested against the current version of this repository.

All commits to this repository have been fully tested on a working HL2, from Unity 2019.4.11f1. It was built from Unity to VS2019, built on `Release` for the `ARM` architecture, and deployed remotely. The current version works without head-locking or launching in a 2D window. 

| Build | As expected? | Notes  |
| ----- | ----- | ------ |
| v1    | ❌   | Unity Native XR & UWP Deployment |
| v2    | ✅   | MRTK + WMR, on UWP with DefaultXR profile.  Shows windowed view. 
| v3    | ❌   | MRTK + WMR, UWP, HL2XRProfile. Shows windowed view. (shouldnt).
| v4    | ✅   | All of above but with WMR enabled. Head-locked view in 3D world.
| v5    | ✅   | All of the above but with Generic XR Camera Settings.




# Status

| Date | Notes |
| ---- | ----- |
|`30/01/2020` | Blank Unity 2019.4.11f1 project.
|`31/01/2020` | Working example HL2 Unity 2019.4.11f1 project.
