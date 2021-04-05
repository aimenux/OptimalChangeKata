using Lib.Models;
using static Lib.Models.Constants;

namespace Lib.Strategies
{
    public class TenFiveSolver : AbstractMoneySolver
    {
        public override bool TrySolve(long money, out Solution solution)
        {
            var hasSolution = money % TenCoinValue % FiveCoinValue == 0;
            if (!hasSolution ||HasZeroSolutions(money))
            {
                solution = new Solution(money);
                return false;
            }

            var tenCoins = money / TenCoinValue;
            var fiveCoins = (money % TenCoinValue) / FiveCoinValue;
            var currency = new Currency(0, fiveCoins, tenCoins);
            solution = new Solution(money, currency);
            return true;
        }
    }
}