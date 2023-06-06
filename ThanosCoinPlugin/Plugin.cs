using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using System.Threading.Tasks;

namespace ThanosCoinPlugin;

/// <summary>
/// Defines plugin functionality.
/// </summary>
public class Plugin
{
    public const string PluginVersion = "2.1.0";
    public const string PluginDescription = "Perfectly balanced plugin.";
    public const string PluginAuthor = "Adam Szerszenowicz";

    /// <summary>
    /// Prints an info message to server log.
    /// </summary>
    /// <param name="message">Message to print.</param>
    private static void PrintLog(string message) => Log.Info(message, "ThanosCoinPlugin: ");

    /// <summary>
    /// Stores plugin configuration.
    /// </summary>
    [PluginConfig]
    public Config? PluginConfig;

    /// <summary>
    /// Loads and initializes the plugin.
    /// </summary>
    [PluginPriority(LoadPriority.Medium)]
    [PluginEntryPoint("Thanos Coin Plugin", PluginVersion, PluginDescription, PluginAuthor)]
    void LoadPlugin()
    {
        PrintLog("Plugin load started...");
        ReloadConfig();
        EventManager.RegisterEvents(this);
        PrintLog("Plugin is loaded.");
    }

    /// <summary>
    /// Reloads the plugin.
    /// </summary>
    [PluginReload]
    void ReloadPlugin()
    {
        PrintLog("Plugin reload started...");
        EventManager.UnregisterEvents(this);
        ReloadConfig();
        EventManager.RegisterEvents(this);
        PrintLog("Plugin reloaded.");
    }

    /// <summary>
    /// Unloads the plugin.
    /// </summary>
    [PluginUnload]
    void UnloadPlugin()
    {
        PrintLog("Plugin unload started...");
        EventManager.UnregisterEvents(this);
        PluginConfig = null;
        PrintLog("Plugin is unloaded.");
    }

    /// <summary>
    /// Called when player flips the coin.
    /// </summary>
    /// <param name="player">Player which thrown the coin.</param>
    /// <param name="isTails"><see langword="true"/> if coin landed on tails, <see langword="false"/> otherwise.</param>
    [PluginEvent(ServerEventType.PlayerCoinFlip)]
    async void OnPlayerCoinFlip(Player? player, bool isTails)
    {
        if (player is null || PluginConfig is null || PluginConfig.CoinKillOnTails != isTails)
        {
            return;
        }

        await Task.Delay(3400);
        player.Kill(PluginConfig?.BalanceReason ?? string.Empty);
        PrintLog($"{player.DisplayNickname} got balanced.");
    }

    /// <summary>
    /// Reloads plugin config values.
    /// </summary>
    private void ReloadConfig()
    {
        var handler = PluginHandler.Get(this);
        handler?.LoadConfig(this, nameof(PluginConfig));
    }
}
