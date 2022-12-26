namespace ThanosCoinPlugin
{
    /// <summary>
    /// Contains plugin configuration
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Set to true if players should be killed when coin lands on tails
        /// </summary>
        public bool CoinKillOnTails { get; set; } = true;

        /// <summary>
        /// Death reason to display on death screen and body inspection
        /// </summary>
        public string BalanceReason { get; set; } = "ThanosCoin.exe";
    }
}
