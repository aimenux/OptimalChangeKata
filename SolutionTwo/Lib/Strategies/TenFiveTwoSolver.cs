using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TenFiveTwoSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % TenCoinValue % FiveCoinValue % TwoCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var tenCoins = money / TenCoinValue;
            var fiveCoins = (money % TenCoinValue) / FiveCoinValue;
            var twoCoins = (money % TenCoinValue % FiveCoinValue) / TwoCoinValue;
            var currency = new Currency(twoCoins, fiveCoins, tenCoins);
            solution = new Solution(money, currency);
            return true;
        }
    }
}