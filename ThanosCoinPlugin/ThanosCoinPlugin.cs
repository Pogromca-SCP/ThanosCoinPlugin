using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using System;
using ThanosCoinPlugin.Events;

namespace ThanosCoinPlugin;

/// <summary>
/// Defines plugin functionality.
/// </summary>
public class ThanosCoinPlugin : Plugin<Config>
{
    /// <summary>
    /// Contains plugin name to display.
    /// </summary>
    public const string PluginName = "ThanosCoinPlugin";

    /// <summary>
    /// Contains current plugin version.
    /// </summary>
    public const string PluginVersion = "4.0.0";

    /// <summary>
    /// Contains plugin description.
    /// </summary>
    public const string PluginDescription = "Perfectly balanced plugin.";

    /// <summary>
    /// Contains plugin author.
    /// </summary>
    public const string PluginAuthor = "Adam Szerszenowicz";

    /// <inheritdoc />
    public override string Name { get; } = PluginName;

    /// <inheritdoc />
    public override string Description { get; } = PluginDescription;

    /// <inheritdoc />
    public override string Author { get; } = PluginAuthor;

    /// <inheritdoc />
    public override Version Version { get; } = new(PluginVersion);

    /// <inheritdoc />
    public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);

    /// <summary>
    /// Contains a reference to coin events handler.
    /// </summary>
    private CoinEventsHandler? _coinEventsHandler = null;

    /// <inheritdoc />
    public override void Enable()
    {
        if (_coinEventsHandler is not null)
        {
            return;
        }

        Logger.Info("Enabling ThanosCoin...");
        _coinEventsHandler = new(this);
        CustomHandlersManager.RegisterEventsHandler(_coinEventsHandler);
        Logger.Info("ThanosCoin is enabled.");
    }

    /// <inheritdoc />
    public override void Disable()
    {
        if (_coinEventsHandler is null)
        {
            return;
        }

        Logger.Info("Disabling ThanosCoin...");
        CustomHandlersManager.UnregisterEventsHandler(_coinEventsHandler);
        _coinEventsHandler = null;
        Logger.Info("ThanosCoin is disabled.");
    }
}
