using System.ComponentModel;

namespace ThanosCoinPlugin
{
    /// <summary>
    /// Contains plugin configuration.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Set to true if players should be killed when coin lands on tails.
        /// </summary>
        [Description("Set to true if players should be killed when coin lands on tails")]
        public bool CoinKillOnTails { get; set; } = true;

        /// <summary>
        /// Death reason to display on death screen and body inspection.
        /// </summary>
        [Description("Death reason to display on death screen and body inspection")]
        public string BalanceReason { get; set; } = "ThanosCoin.exe";
    }
}
