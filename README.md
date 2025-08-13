# NametagModifier
![Binoculars with name still visible](https://files.freewifi.club/noindex/zoom.jpg)

NametagModifier is a client-side mod that allows you to change the behavior of nametags, which includes:
- `Visible Distance` (How far do you have to be from a player before nametags fade out)
- `Visible Angle` (How far does your camera have to be facing from a player before nametags fade out)

Alongside being able to change the default distance, you can also set an `Override Keybind` (`T` by default) which will always show nametags for how long `Override Time` (`20s` by default) is set to, regardless of distance or camera angle.

## Configuration
You can change all aspects of this mod (except for the `Override Keybind`) from within the settings menu, the mod doesn't modify vanilla values by default and will replicate vanilla behavior other than the `Override Keybind`.
- `Visible Distance` dictates how far you can see nametags in meters before they fade away.
- `Visible Angle` dictates how close your camera has to be facing to a player in degrees before nametags fade away.
- `Override Time` dictates how long the `Override key` will keep nametags visible regardless of distance or angle. 
  - You can always press the key again to hide it, regardless of what this setting is set to.
- You can change the `Override Keybind` by modifying the config file at `BepInEx/config/club.freewifi.void.NameTagModifier.cfg`, modifying it ingame is not possible at this time.
![Config Image](https://files.freewifi.club/noindex/config.png)

**Requires [SettingsExtenderForked](https://thunderstore.io/c/peak/p/pharmacomaniac/SettingsExtenderForked/)**

