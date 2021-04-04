using Lib.Models;

namespace Lib.Services
{
    public interface IMoneyBoxService
    {
        Currency ComputeOptimalCurrency(long money);
    }
}
