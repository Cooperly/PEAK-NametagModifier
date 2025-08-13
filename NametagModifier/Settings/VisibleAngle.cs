using SettingsExtender;
using Unity.Mathematics;
using Zorro.Settings;

namespace NametagModifier.Settings;

public class VisibleAngle : FloatSetting, IExposedSetting {
    public string GetDisplayName() {
        return "Visible Angle";
    }

    public string GetCategory() {
        return SettingsRegistry.GetPageId("NametagModifier");
    }

    protected override float GetDefaultValue() {
        return 45f;
    }

    protected override float2 GetMinMaxValue() {
        return new float2(0f, 180f);
    }

    public override void ApplyValue() {
    }
}
