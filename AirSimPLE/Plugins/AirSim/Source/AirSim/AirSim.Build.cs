// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using UnrealBuildTool;
using System.IO;

public class AirSim : ModuleRules
{
    public AirSim(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_6;
        DefaultBuildSettings = BuildSettingsVersion.V5;
        CppStandard = CppStandardVersion.Cpp20;
        bEnableExceptions = true;

        PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "AssetRegistry", "InputCore", "ImageWrapper", "RenderCore", "RHI", "PhysicsCore", "ChaosVehicles", "Landscape", "CinematicCamera" });
        PrivateDependencyModuleNames.AddRange(new string[] { "UMG", "Slate", "SlateCore", "RenderCore" });

        //suppress VC++ proprietary warnings
        // PublicDefinitions.Add("_SCL_SECURE_NO_WARNINGS=1");

        PublicDependencyModuleNames.Add("Eigen");
        PublicDependencyModuleNames.Add("RPCLib");
        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "Public", "AirLib", "include"));

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // for SHGetFolderPath.
            PublicSystemLibraries.Add("Shell32.lib");

            //for joystick support
            PublicSystemLibraries.Add("dinput8.lib");
            PublicSystemLibraries.Add("dxguid.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
		{
			// needed when packaging
			PublicSystemLibraries.Add("stdc++");
			PublicSystemLibraries.Add("supc++");
		}
        else {
            // TODO raise error for unsupported platforms
        }
    }
}
