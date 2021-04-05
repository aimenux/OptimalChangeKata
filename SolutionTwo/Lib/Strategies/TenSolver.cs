using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TenSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % TenCoinValue == 0;
            if (!hasSolution || HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var tenCoins = money / TenCoinValue;
            var currency = new Currency(0, 0, tenCoins);
            solution = new Solution(money, currency);
            return true;
        }
    }
}