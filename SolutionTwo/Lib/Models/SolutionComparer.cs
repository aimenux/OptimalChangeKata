using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace Lib.Models
{
    public class SolutionComparer : ISolutionComparer
    {
        public int Compare(Solution x, Solution y)
        {
            Guard.Against.Null(x?.Currency, nameof(x));
            Guard.Against.Null(y?.Currency, nameof(y));
            Guard.Against.InvalidInput(x, nameof(x), _ => AreEquivalents(x, y));
            var diff = x.Currency.TotalCoins - y.Currency.TotalCoins;
            return Convert.ToInt32(diff);
        }

        private static bool AreEquivalents(Solution x, Solution y)
        {
            return x.Money == y.Money && x.Currency.TotalMoney == y.Currency.TotalMoney;
        }
    }

    public interface ISolutionComparer : IComparer<Solution>
    {
    }
}
