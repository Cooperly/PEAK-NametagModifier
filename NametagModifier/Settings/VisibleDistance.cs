using SettingsExtender;
using Unity.Mathematics;
using Zorro.Settings;

namespace NametagModifier.Settings;

public class VisibleDistance : FloatSetting, IExposedSetting {
    public string GetDisplayName() {
        return "Visible Distance";
    }

    public string GetCategory() {
        return SettingsRegistry.GetPageId("NametagModifier");
    }

    protected override float GetDefaultValue() {
        return 8f;
    }

    protected override float2 GetMinMaxValue() {
        return new float2(0f, 4000f);
    }

    public override void ApplyValue() {}
}
