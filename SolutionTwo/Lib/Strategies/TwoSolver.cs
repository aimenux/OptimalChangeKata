using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TwoSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % TwoCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var twoCoins = money / TwoCoinValue;
            var currency = new Currency(twoCoins, 0, 0);
            solution = new Solution(money, currency);
            return true;
        }
    }
}