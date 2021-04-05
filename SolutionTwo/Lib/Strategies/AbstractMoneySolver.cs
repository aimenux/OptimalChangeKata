using Lib.Models;

namespace Lib.Strategies
{
    public abstract class AbstractMoneySolver : IMoneySolver
    {
        public abstract bool TrySolve(long money, out Solution solution);

        protected static bool HasZeroSolutions(long money) => money <= 1 || money == 3;
    }
}