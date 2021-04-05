using Lib.Models;

namespace Lib.Strategies
{
    public interface IMoneySolver
    {
        bool TrySolve(long money, out Solution solution);
    }
}
