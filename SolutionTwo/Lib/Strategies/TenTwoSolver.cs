using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TenTwoSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % TenCoinValue % TwoCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var tenCoins = money / TenCoinValue;
            var twoCoins = (money % TenCoinValue) / TwoCoinValue;
            var currency = new Currency(twoCoins, 0, tenCoins);
            solution = new Solution(money, currency);
            return true;
        }
    }
}