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
    /// <summary>
    /// Contains current plugin version.
    /// </summary>
    public const string PluginVersion = "3.0.0";

    /// <summary>
    /// Contains plugin description.
    /// </summary>
    public const string PluginDescription = "Perfectly balanced plugin.";

    /// <summary>
    /// Contains plugin author.
    /// </summary>
    public const string PluginAuthor = "Adam Szerszenowicz";

    /// <summary>
    /// Prints an info message to server log.
    /// </summary>
    /// <param name="message">Message to print.</param>
    private static void PrintLog(string message) => Log.Info(message, "ThanosCoinPlugin: ");

    /// <summary>
    /// Kills a player after a short delay.
    /// </summary>
    /// <param name="player">Player to kill.</param>
    /// <param name="reason">Death reason to display.</param>
    private static async void KillPlayerAsync(Player player, string reason)
    {
        await Task.Delay(3400);
        player.Kill(reason);
        PrintLog($"{player.DisplayNickname} got balanced.");
    }

    /// <summary>
    /// Stores plugin configuration.
    /// </summary>
    [PluginConfig]
    public Config PluginConfig;

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
    /// <param name="args">Contains event arguments.</param>
    [PluginEvent(ServerEventType.PlayerCoinFlip)]
    void OnPlayerCoinFlip(PlayerCoinFlipEvent args)
    {
        if (PluginConfig is not null && PluginConfig.CoinKillOnTails == args.IsTails)
        {
            KillPlayerAsync(args.Player, PluginConfig.BalanceReason ?? string.Empty);
        }
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
