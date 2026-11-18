# RimThemes

> The port was made with the help of [Claude](https://claude.ai) (Anthropic), an AI assistant: code migration, analysis of the 1.7 assemblies and bug fixing. Testing in-game and publishing were done by Darkwood107.

> [!NOTE]
> **Unofficial RimWorld 1.7 port** by [Darkwood107](https://github.com/Darkwood107).
> This is a fork of [aRandomKiwi/RimThemes](https://github.com/aRandomKiwi/RimThemes), all credit for the mod goes to **aRandomKiwi**.
> It adds support for RimWorld 1.7 (Waylith engine) while keeping the original builds for 1.0–1.6 untouched.

> **Steam Workshop:** [RimThemes (1.7 Unofficial)](https://steamcommunity.com/sharedfiles/filedetails/?id=3841792534)

## RimWorld 1.7 port

RimWorld 1.7 replaced Unity with Ludeon's own Waylith engine and moved mods to .NET 10 and Harmony 3. This fork contains a rebuilt assembly in `1.7/Assemblies` and its source code in `Source/1.7`.

**Changes compared to the 1.6 version:**
- Project migrated to SDK-style `.csproj` targeting `net10.0`, built against `Assembly-CSharp`, `UnityStubs` and `Waylith` (Harmony 3.0).
- Theme sounds and music are loaded with `AudioClip.LoadFromFile` (the old `RuntimeAudioClipLoader` no longer exists).
- Custom cursor is now applied on the main thread (Waylith forbids windowing calls from the loading thread).
- Fixed buttons turning invisible after unthemed widgets (postfixes restored an unset `GUI.color`).
- Fixed the `Widgets.ButtonTextWorker` patch signature (`TextAnchor?`).
- Harmony patches are applied one by one, so a single failing patch no longer disables the whole mod.
- Null checks for loader background textures.

**Requirements:** RimWorld 1.7 and [Harmony](https://steamcommunity.com/sharedfiles/filedetails/?id=2009463077) 3.x.

**Building:** .NET 10 SDK (VS 2026 / Rider 2026 or `dotnet build`). Run `Source/1.7/build.bat "<path to RimWorld>"`, or set `RimWorldDir` / `RimWorldManaged` / `HarmonyDll` in `RimThemes.csproj`.

**Status:** tested on the 1.7 unstable branch (1.7.5013). Bugs specific to the 1.7 port should be reported in this fork, not to the original author.

Licensed under GPL-3.0, same as the original.

Themes engine for RimWorld.

Modify all game UI, make RimWorld look as you are or as you want.
Fully customizable (custom fonts and many other things can be Disabled in mod settings ! ) updates.

<p align="center">
    <img src="https://i.imgur.com/GCVVucp.jpg" alt="RimThemes screenshot 1" />
</p>
<p align="center">
    <img src="https://i.imgur.com/qLIlBPb.jpg" alt="RimThemes screenshot 2" />
</p>

## Make your own themes

Follow instructions in the [Themes Makers topic](https://steamcommunity.com/workshop/filedetails/discussion/1668983184/1843566500514705651/])

## Compatibility

Incompatible with : modCheck and Multiplayer mod

Should work with all others mods.
Tested on Windows and Linux 64bits.

## Old Themes

Old themes (RimThemes 2019RX and 2020R1) can always be used by following these steps :

[For 2019RX themes, download this zip file](https://www.dropbox.com/s/s6p8246t2h7ppi7/LegacyThemes.zip?dl=0)

[For 2020R1 themes, download this zip file](https://www.dropbox.com/s/viu8culxagx5fgp/20XX%20Themes.zip?dl=0)

Then simply create a "RimThemes" folder in the Rimworld's base directory (ex : "X:\Program Files (x86)\Steam\steamapps\common\RimWorld\" for Windows) and copy paste in this folder all themes folders inside the downloaded archive you want".

## Important

Need to be loaded in first position in mod list ! 9 themes included but 3 enabled by default
<p align="left">
    <img src="https://i.imgur.com/pKxfc6F.png" alt="RimThemes" />
</p>
