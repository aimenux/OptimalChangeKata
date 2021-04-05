using Ardalis.GuardClauses;

namespace Lib.Models
{
    public class Solution
    {
        public Solution(long money, Currency currency = null)
        {
            Guard.Against.NegativeOrZero(money, nameof(money));
            if (currency != null)
            {
                Guard.Against.InvalidInput(currency, nameof(currency), input => input.TotalMoney == money);
            }
            
            Money = money;
            Currency = currency;
        }

        public long Money { get; }

        public Currency Currency { get; }
    }
}
