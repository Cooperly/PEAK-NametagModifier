using HarmonyLib;
using NametagModifier.Settings;

namespace NametagModifier.Patches;

[HarmonyPatch(typeof(IsLookedAt), nameof(IsLookedAt.Update))]
public class ModifyNametag {
    public static void Prefix(IsLookedAt __instance) {
        var distance = SettingsHandler.Instance.GetSetting<VisibleDistance>().Value;
        var visibleAngle = SettingsHandler.Instance.GetSetting<VisibleAngle>().Value;

        var clock = NametagModifier.IsOverriding();
        
        if (clock)
        {
            __instance.visibleDistance = 4000;
            __instance.visibleAngle = 180;
            return;
        }
        __instance.visibleDistance = distance;
        __instance.visibleAngle = visibleAngle / 2;

    }
}
