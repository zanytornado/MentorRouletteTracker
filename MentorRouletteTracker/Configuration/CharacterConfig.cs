using Dalamud.Configuration;
using Dalamud.Game.ClientState.Objects.SubKinds;
using MentorRouletteTracker;

public class CharacterConfig  : IPluginConfiguration {
    public int Version { get; set; } = 1;
    public ulong LocalContentId;
    public string CharacterName { get; set; } = string.Empty;
    public string CharacterWorld { get; set; } = string.Empty;

    public CharacterConfig() { }

    public CharacterConfig(ulong id, IPlayerCharacter local)
    {
        LocalContentId = id;
        CharacterName = local.Name.ToString();
        CharacterWorld = local.HomeWorld.GameData!.Name.ToString();
    }

    public static CharacterConfig CreateNew() => new()
    {
        LocalContentId = Plugin.ClientState.LocalContentId,

        CharacterName = Plugin.ClientState.LocalPlayer?.Name.ToString() ?? "",
        CharacterWorld = Plugin.ClientState.LocalPlayer?.HomeWorld.GameData?.Name.ToString() ?? "Unknown"
    };
}