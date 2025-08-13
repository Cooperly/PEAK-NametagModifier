using System;
using NametagModifier.Settings;
using UnityEngine;

namespace NametagModifier;

public static class OverrideClock {
    public static bool Clock() {
        var overrideTime = SettingsHandler.Instance.GetSetting<OverrideTime>().Value;
        
        if (Input.GetKeyDown(NametagModifier.OverrideKey.Value) && Time.realtimeSinceStartupAsDouble - LastTimeSetToTrue < overrideTime) {
            LastTimeSetToTrue = float.MinValue;
            return true;
        }
        if (Time.realtimeSinceStartupAsDouble - LastTimeSetToTrue < overrideTime){
            return true;
        }
        // If override keybind is pressed, set LastTimeSetToTrue to realtimeSinceStartup
        if (Input.GetKeyDown(NametagModifier.OverrideKey.Value)) {
            LastTimeSetToTrue = Time.realtimeSinceStartup;
            return true;
        }
        return false;
    }
    
    public static float LastTimeSetToTrue = float.MinValue;
}
