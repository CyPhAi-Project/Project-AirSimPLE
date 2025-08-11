#!/usr/bin/env bash

set -e

if [[ -n "$UAT_PATH" ]]; then
    RUNUAT_BAT="$UAT_PATH"
elif [[ "$(uname)" == "Darwin" ]]; then
    RUNUAT_BAT="/System/Volumes/Data/Users/Shared/Epic Games/UE_5.6/Engine/Build/BatchFiles/RunUAT.sh"
else
    echo "Error: UAT_PATH is not set and the script is not running on macOS."
    exit 1
fi

if [[ ! -x "$RUNUAT_BAT" ]]; then
    echo "Error: RunUAT script not found or not executable at '$RUNUAT_BAT'."
    exit 1
fi

SCRIPT_DIR="$(realpath "$(dirname "$0")")"

echo "$SCRIPT_DIR"

PROJECT_PATH="$SCRIPT_DIR/AirSimPLE/AirSimPLE.uproject"

echo "$PROJECT_PATH"

"$RUNUAT_BAT" -nop4 BuildCookRun -clean -project="$PROJECT_PATH" -targetplatform=Mac -build -cook -skipcookingeditorcontent -compressed -stage -nodebuginfo -package
