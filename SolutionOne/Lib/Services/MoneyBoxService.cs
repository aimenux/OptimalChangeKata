using Ardalis.GuardClauses;
using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Services
{
    public class MoneyBoxService : IMoneyBoxService
    {
        public Currency ComputeOptimalCurrency(long money)
        {
            var rest = Guard.Against.NegativeOrZero(money, nameof(money));
            var tenCoins = GetTenCoins(ref rest);
            var fiveCoins = GetFiveCoins(ref rest);
            var twoCoins = GetTwoCoins(ref rest);
            var currency = new Currency(twoCoins, fiveCoins, tenCoins);
            return currency.TotalMoney == money ? currency : null;
        }

        private static long GetTenCoins(ref long rest)
        {
            var tenCoins = rest / TenCoinValue;
            rest %= TenCoinValue;
            return tenCoins;
        }

        private static long GetFiveCoins(ref long rest)
        {
            var fiveCoins = rest / FiveCoinValue;

            if (rest % FiveCoinValue == 0 || rest % FiveCoinValue % TwoCoinValue == 0)
            {
                rest %= FiveCoinValue;
                return fiveCoins;
            }

            return 0;
        }

        private static long GetTwoCoins(ref long rest)
        {
            var twoCoins = rest / TwoCoinValue;
            rest %= TwoCoinValue;
            return twoCoins;
        }
    }
}