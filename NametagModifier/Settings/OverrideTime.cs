namespace NametagModifier.Settings;

using SettingsExtender;
using Unity.Mathematics;
using Zorro.Settings;

public class OverrideTime : FloatSetting, IExposedSetting {
    public string GetDisplayName() {
        return "Override Time";
    }

    public string GetCategory() {
        return SettingsRegistry.GetPageId("NametagModifier");
    }

    protected override float GetDefaultValue() {
        return 20f;
    }

    protected override float2 GetMinMaxValue() {
        return new float2(1f, 720f);
    }

    public override void ApplyValue() {}
}

