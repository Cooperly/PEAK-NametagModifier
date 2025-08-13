using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using NametagModifier.Patches;
using NametagModifier.Settings;
using SettingsExtender;
using UnityEngine;

namespace NametagModifier;

[BepInPlugin(ModGUID, ModName, ModVersion)]
public class NametagModifier : BaseUnityPlugin {
    private const string ModGUID = "club.freewifi.void.NameTagModifier";
    private const string ModName = "NametagModifier";
    private const string ModVersion = "1.0.2";
    
    private static ConfigEntry<KeyCode> overrideKey = null!;
    private static float lastOverrideTime = float.MinValue;

    private void Awake() {
        // Register BepInEx config
        overrideKey = Config.Bind(
            "Keybinds",
            "Override Key",
            KeyCode.T,
            "Pressing this key will show all nametags of all players for a set amount of time defined in the game settings, regardless of distance or camera angle.");
       
        // Register settings page
        SettingsRegistry.Register(ModName);
        
        var harmony = new Harmony(ModGUID);
        harmony.PatchAll(typeof(ModifyNametag));
    }

    private void Start() {
        // Register settings buttons
        SettingsHandler.Instance.AddSetting(new VisibleDistance());
        SettingsHandler.Instance.AddSetting(new VisibleAngle());
        SettingsHandler.Instance.AddSetting(new OverrideTime());
    }

    /// <summary>
    ///     Checks if the <see cref="overrideKey" /> has been pressed within the time that <see cref="OverrideTime" /> has
    ///     specified.
    /// </summary>
    public static bool IsOverriding() {
        var overrideTime = SettingsHandler.Instance.GetSetting<OverrideTime>().Value;
        // Compare Time.realtimeSinceStartup to lastOverrideTime, return true if less than overrideTime
        var isOverriden = Time.realtimeSinceStartup - lastOverrideTime < overrideTime;

        // Check if PEAK is currently blocking window input, such as in menus.
        if (GUIManager.instance.windowBlockingInput) {
            return false;
        }

        // Reset Override Behavior if player presses OverrideKey while already overridden
        if (Input.GetKeyDown(overrideKey.Value) && isOverriden) {
            lastOverrideTime = float.MinValue;
            return false;
        }
        
        if (isOverriden) {
            return true;
        }

        // If override keybind is pressed, set LastTimeSetToTrue to realtimeSinceStartup so it can be compared by isOverriden
        if (Input.GetKeyDown(overrideKey.Value)) {
            lastOverrideTime = Time.realtimeSinceStartup;
            return true;
        }
        return false;
    }
}
