using System;
using NametagModifier.Settings;
using UnityEngine;

namespace NametagModifier;

public static class OverrideClock {
    public static bool Clock() {
        var overrideTime = SettingsHandler.Instance.GetSetting<OverrideTime>().Value;
        
        // Check if PEAK is currently blocking window input, such as in menus.
        if (!GUIManager.instance.windowBlockingInput) {
            // Reset Override Behavior if player presses OverrideKey while already overridden
            if (Input.GetKeyDown(NametagModifier.OverrideKey.Value) && Time.realtimeSinceStartupAsDouble - LastTimeSetToTrue < overrideTime) {
                LastTimeSetToTrue = float.MinValue;
                return false;
            }
            // Compare Time.realtimeSinceStartupAsDouble to LastTimeSetToTrue, return true if less than overrideTime
            if (Time.realtimeSinceStartupAsDouble - LastTimeSetToTrue < overrideTime){
                return true;
            }
            // If override keybind is pressed, set LastTimeSetToTrue to realtimeSinceStartup
            if (Input.GetKeyDown(NametagModifier.OverrideKey.Value)) {
                LastTimeSetToTrue = Time.realtimeSinceStartup;
                return true;
            }
        }
        return false;
    }
    public static float LastTimeSetToTrue = float.MinValue;
}
