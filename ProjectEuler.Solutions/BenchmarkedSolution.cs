using System.Diagnostics;

namespace ProjectEuler.Solutions
{
    public class BenchmarkedSolution : ISolution, IBenchmarkedSolution
    {
        public long ElapsedMiliseconds { get; private set; }

        public int ProblemNumber { get; private set; }

        private Answer answer;
        private BenchmarkedSolution() { }

        public static BenchmarkedSolution Create (ISolution solution)
        {
            var stopwatch = Stopwatch.StartNew();

            var bs = new BenchmarkedSolution() { answer = solution.GetAnswer(), ElapsedMiliseconds = stopwatch.ElapsedMilliseconds, ProblemNumber = solution.ProblemNumber };
            return bs;
        }

        public Answer GetAnswer()
        {
            return answer;
        }
    }
}
