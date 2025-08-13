using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using NametagModifier.Patches;
using NametagModifier.Settings;
using SettingsExtender;
using UnityEngine;

namespace NametagModifier;

[BepInPlugin("club.freewifi.void.NameTagModifier", "NametagModifier", "1.0.1")]
public class NametagModifier : BaseUnityPlugin {
    public static ConfigEntry<KeyCode> OverrideKey = null!;

    private void Start() {
        SettingsHandler.Instance.AddSetting(new VisibleDistance());
        SettingsHandler.Instance.AddSetting(new VisibleAngle());
        SettingsHandler.Instance.AddSetting(new OverrideTime());
    }

    private void Awake() {
        
        OverrideKey = Config.Bind(
            "Keybinds",
            "Override Key",
            KeyCode.T,
            "Pressing this key will show all nametags of all players for a set amount of time defined in the game settings, regardless of distance or camera angle.");
        
        SettingsRegistry.Register("NametagModifier");
        var harmony = new Harmony("NametagModifier");
        harmony.PatchAll(typeof(ModifyNametag));
    }
}
