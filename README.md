# ThanosCoinPlugin
[![GitHub release](https://flat.badgen.net/github/release/Pogromca-SCP/ThanosCoinPlugin)](https://github.com/Pogromca-SCP/ThanosCoinPlugin/releases/)
[![GitHub license](https://flat.badgen.net/github/license/Pogromca-SCP/ThanosCoinPlugin)](https://github.com/Pogromca-SCP/ThanosCoinPlugin/blob/main/LICENSE)
![GitHub downloads](https://flat.badgen.net/github/assets-dl/Pogromca-SCP/ThanosCoinPlugin)
![GitHub last commit](https://flat.badgen.net/github/last-commit/Pogromca-SCP/ThanosCoinPlugin)

Perfectly balanced plugin for SCP: Secret Laboratory. Every coin flip has 50% chance to kill the player. Are you ready to test your luck?
 
This plugin was created using [official Northwood Plugin API](https://github.com/northwood-studios/NwPluginAPI). No additional dependencies need to be installed in order to run it.
 
## Installation
Simply put plugin `.dll` file inside your server's plugins folder.

## Configuration
|Name|Type|Default value|Description|
|---|---|---|---|
|coin_kill_on_tails|bool|true|Set to true if players should be killed when coin lands on tails.|
|balance_reason|string|ThanosCoin.exe|Death reason to display on death screen and body inspection.|
