using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class FiveTwoAnotherSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = (money - FiveCoinValue) % TwoCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            const int fiveCoins = 1;
            var twoCoins = (money - FiveCoinValue) / TwoCoinValue;
            var currency = new Currency(twoCoins, fiveCoins, 0);
            solution = new Solution(money, currency);
            return true;
        }
    }
}