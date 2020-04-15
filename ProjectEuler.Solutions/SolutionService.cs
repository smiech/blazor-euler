using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Solutions
{
    public class SolutionService
    {
        public SolutionService()
        {
            LoadSolutions();
        }

        private ProblemLoader problemLoader = new ProblemLoader();
        private IEnumerable<ISolution> solutions;

        private List<Problem> problemz = new List<Problem>();

        public void LoadSolutions()
        {
            solutions = SolutionLoader.Load<ISolution>(
                new string[]
                {
                    @"/Users/adam/repositories/project-euler-solutions"
                });
        }

        public Task<IEnumerable<IProblem>> GetProblemsAsync(int from, int to)
        {
            return problemLoader.LoadProblems(from, to);
        }

        public bool HasSolution(IProblem problem)
        {
            var existingSolutions = solutions.Where(x => x.ProblemNumber == problem.Number);
            return existingSolutions.Any();
        }

        public Task<IBenchmarkedSolution> GetBenchmarkedSolutionAsync(IProblem problem)
        {
            var existingSolutions = solutions.Where(x => x.ProblemNumber == problem.Number);
            if (!HasSolution(problem))
            {
                throw new InvalidOperationException("problem not solved");
            }

            return Task.FromResult((IBenchmarkedSolution)BenchmarkedSolution.Create(existingSolutions.First()));
        }

    }


}
