namespace ProjectEuler.Solutions
{
    public interface IBenchmarkedSolution : ISolution
    {
        long ElapsedMiliseconds { get; }
    }
}