// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class AirSimPLEEditorTarget : TargetRules
{
	public AirSimPLEEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		ExtraModuleNames.AddRange(new string[] { "AirSimPLE" });
        DefaultBuildSettings = BuildSettingsVersion.V5;
        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_6;
        CppStandard = CppStandardVersion.Cpp20;
        // BuildEnvironment = TargetBuildEnvironment.Unique;
        //bUseUnityBuild = false;
        //bUsePCHFiles = false;
    }
}
