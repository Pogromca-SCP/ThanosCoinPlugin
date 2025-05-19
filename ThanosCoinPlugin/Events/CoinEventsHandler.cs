using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Console;
using MEC;

namespace ThanosCoinPlugin.Events;

/// <summary>
/// Custom event handler for coin events.
/// </summary>
/// <param name="plugin">Reference to plugin object for access to config.</param>
public class CoinEventsHandler(ThanosCoinPlugin? plugin) : CustomEventsHandler
{
    /// <summary>
    /// Contains reference to plugin object for access to config object.
    /// </summary>
    private readonly ThanosCoinPlugin _plugin = plugin ?? new();

    /// <inheritdoc />
    public override void OnPlayerFlippedCoin(PlayerFlippedCoinEventArgs args)
    {
        var config = _plugin.Config;

        if (config is null || config.CoinKillOnTails != args.IsTails)
        {
            return;
        }

        var player = args.Player;
        var reason = config.BalanceReason ?? string.Empty;

        Timing.CallDelayed(3.4f, () =>
        {
            player.Kill(reason);
            Logger.Info($"{player.DisplayName} got balanced.");
        });
    }
}
