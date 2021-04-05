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

            var tenCoins = rest / TenCoinValue;
            rest %= TenCoinValue;
            if (rest % TwoCoinValue == 1 && rest < FiveCoinValue)
            {
                tenCoins -= 1;
                rest += TenCoinValue;
            }

            var fiveCoins = rest / FiveCoinValue;
            rest %= FiveCoinValue;
            if (rest % TwoCoinValue == 1 && rest < FiveCoinValue)
            {
                fiveCoins -= 1;
                rest += FiveCoinValue;
            }


            var twoCoins = rest / TwoCoinValue;
            rest %= TwoCoinValue;

            var solutionExists = rest == 0
                                 && twoCoins >= 0
                                 && fiveCoins >= 0
                                 && tenCoins >= 0;

            return solutionExists 
                ? new Currency(twoCoins, fiveCoins, tenCoins) 
                : null;
        }
    }
}