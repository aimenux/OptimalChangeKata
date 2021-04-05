using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class FiveSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % FiveCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var fiveCoins = money / FiveCoinValue;
            var currency = new Currency(0, fiveCoins, 0);
            solution = new Solution(money, currency);
            return true;
        }
    }
}