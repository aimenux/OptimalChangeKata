using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Lib.Models;
using Lib.Strategies;

namespace Lib.Services
{
    public class MoneyBoxService : IMoneyBoxService
    {
        private readonly ISolutionComparer _comparer;
        private readonly IEnumerable<IMoneySolver> _solvers;

        public MoneyBoxService()
        {
            _comparer = new SolutionComparer();
            _solvers = new List<IMoneySolver>
            {
                new TwoSolver(),
                new FiveSolver(),
                new TenSolver(),
                new FiveTwoSolver(),
                new FiveTwoAnotherSolver(),
                new TenTwoSolver(),
                new TenFiveSolver(),
                new TenFiveTwoSolver(),
                new TenFiveTwoAnotherSolver()
            };
        }

        public MoneyBoxService(ISolutionComparer comparer, IEnumerable<IMoneySolver> solvers)
        {
            _comparer = Guard.Against.Null(comparer, nameof(comparer));
            _solvers = Guard.Against.Null(solvers, nameof(solvers));
        }

        public Currency ComputeOptimalCurrency(long money)
        {
            Guard.Against.NegativeOrZero(money, nameof(money));

            var solutions = new List<Solution>();
            foreach (var solver in _solvers)
            {
                if (solver.TrySolve(money, out var solution))
                {
                    solutions.Add(solution);
                }
            }

            var orderedSolutions = solutions
                .OrderBy(solution => solution, _comparer)
                .ToList();

            return orderedSolutions.FirstOrDefault()?.Currency;
        }
    }
}