using Ardalis.GuardClauses;
using static Lib.Models.Constants;

namespace Lib.Models
{
    public class Currency
    {
        public Currency(long twoCoins, long fiveCoins, long tenCoins)
        {
            TwoCoins = Guard.Against.Negative(twoCoins, nameof(twoCoins));
            FiveCoins = Guard.Against.Negative(fiveCoins, nameof(fiveCoins));
            TenCoins = Guard.Against.Negative(tenCoins, nameof(tenCoins));
        }

        public long TwoCoins { get; }

        public long FiveCoins { get; }

        public long TenCoins { get; }

        public long TotalCoins => TwoCoins + FiveCoins + TenCoins;

        public long TotalMoney => TwoCoins * TwoCoinValue + FiveCoins * FiveCoinValue + TenCoins * TenCoinValue;
    }
}
