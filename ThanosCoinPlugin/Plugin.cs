using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Core;

namespace ThanosCoinPlugin
{
    using EventManager = PluginAPI.Events.EventManager;

    public class Plugin
    {
        [PluginConfig]
        public Config PluginConfig;

        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint("Thanos Coin Plugin", "1.0.0", "Perfectly balanced plugin", "Adam Szerszenowicz")]
        void LoadPlugin()
        {
            PrintLog("Plugin load started...");
            EventManager.RegisterEvents(this);
            PrintLog("Plugin is loaded.");
        }

        [PluginEvent(ServerEventType.PlayerCoinFlip)]
        void OnPlayerCoinFlip(Player player, bool isTails)
        {
            if (player is null || player.IsGodModeEnabled || PluginConfig is null || PluginConfig.CoinKillOnTails != isTails)
            {
                return;
            }

            player.Kill(PluginConfig.BalanceReason ?? string.Empty);
            PrintLog($"{player.DisplayNickname} got balanced."); 
        }

        private static void PrintLog(string message) => Log.Info(message, "ThanosCoinPlugin: ");
    }
}
