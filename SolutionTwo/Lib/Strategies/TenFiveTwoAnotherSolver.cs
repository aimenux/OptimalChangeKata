using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TenFiveTwoAnotherSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = (money - FiveCoinValue) % TenCoinValue % TwoCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            const int fiveCoins = 1;
            var tenCoins = (money - FiveCoinValue) / TenCoinValue;
            var twoCoins = (money - FiveCoinValue) % TenCoinValue / TwoCoinValue;
            var currency = new Currency(twoCoins, fiveCoins, tenCoins);
            solution = new Solution(money, currency);
            return true;
        }
    }
}