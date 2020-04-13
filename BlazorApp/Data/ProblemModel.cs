using ProjectEuler.Solutions;

namespace BlazorApp.Data
{
    public class ProblemModel
    {
        public ProblemModel(IProblem problem, bool isSolved)
        {
            Problem = problem;
            IsSolved = isSolved;
        }

        public bool IsSolved { get; }
        public bool ShownSolution { get; set; }
        public IBenchmarkedSolution Solution{ get; set; }
        public IProblem Problem { get; }
    }
}
