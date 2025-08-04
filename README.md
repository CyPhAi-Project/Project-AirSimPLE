# AirSimPLE

This repository is my attempt to strip down the original AirSim project (https://github.com/microsoft/AirSim) with only the Unreal Engine-based simulator and the Python API.


## Download Source Code

Required Software:
+ git https://git-scm.com/
+ git-lfs https://git-lfs.com/

To clone the repository to a folder `airsimple-repo` and **download all asset files using Git LFS**:
```bash
git clone https://github.com/CyPhAi-Project/Project-AirSimPLE.git airsimple-repo
cd airsimple-repo/
git lfs pull
```

## Build the Project through Command Line

### Required Software (Tested with the following on Windows 11):
+ Unreal Engine 5.2 https://www.unrealengine.com/en-US/unreal-engine-5
+ Microsoft Visual Studio 2022 Community Version https://visualstudio.microsoft.com/vs/community/  
  We tested the following required workloads and individual components suggested by [Unreal Engine 5.2 documentation].
  - Workloads:
    * .Net desktop development
    * Desktop development with C++
    * Universal Windows Platform development
    * Game development with C++
  - Individual Components:
    * MSVC v143 - VS 2022 C++ x64/x86 build tools (**v14.38-17.8**)
    * Windows 10 SDK (**10.0.18362.0**)
    * Unreal Engine installer

[Unreal Engine 5.2 documentation]: https://dev.epicgames.com/documentation/en-us/unreal-engine/setting-up-visual-studio-development-environment-for-cplusplus-projects-in-unreal-engine?application_version=5.2


### Build Configurations

To specify the particular version of the tool chain for building, please create or modify the following file `Documents/Unreal Engine/UnrealBuildTool/BuildConfiguration.xml` with the following:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Configuration xmlns="https://www.unrealengine.com/BuildConfiguration">
    <WindowsPlatform>
        <CompilerVersion>14.38.33145</CompilerVersion>
    </WindowsPlatform>
</Configuration>
```

**NOTE**: We provide a copy in `AirSimPLE/Saved/UnrealBuildTool/BuildConfiguration.xml` as suggested in [Unreal Engine 5.2 Build Configuration]. This is however not working for Unreal Engine 5.2.1 so far. We therefore suggest copying the file to the folder `Documents/Unreal Engine/UnrealBuildTool/`.

[Unreal Engine 5.2 Build Configuration]: https://dev.epicgames.com/documentation/en-us/unreal-engine/build-configuration-for-unreal-engine?application_version=5.2
 

### Build Command

If you are building under Windows CMD, run the command
```bat
build-game.cmd
```

It may take 20~30 minutes to build the game. Once the build is successful, you should be able to find the executable `FlyingExample.exe` under the `AirSimPLE\Binaries\Win64` folder.


## Install Python Client API `airsimple`

Required Software (Tested with the following on Windows 11):
+ Python 3.10

We recommend creating and activating a virtual environment as follows:
```bat
python -m venv venv
venv\Scripts\activate
```

Install the client API in editable mode
```
pip install -e PythonClient
```

## Start the FlyingExample Map and Run `hello_drone.py`

Double click to execute `FlyingExample.exe` that starts a game as the simulation environment. You may be asked if you would like a car simulation. Select `no` to start the quadrotor simulation. You may also be asked if you would like to configure the firewall to allow the connection. Allow the connection so that the Python client can communicate with the game.

Once the game is started. Go back to the command line terminal with the Python virtual environment and run:
```bat
python PythonClient\scripts\hello_drone.py
```
This will start the Python script that interacts with the game. Follow the instructions in the command line messages. You should be able to see some information of the simulated drone as well as control the drone to take off and take camera images.


## Open the Project in Unreal Editor

Open `AirSimPLE.uproject` under the `AirSimPLE` folder
