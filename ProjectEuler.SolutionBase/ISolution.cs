namespace ProjectEuler.Solutions
{
    public interface ISolution
    {
        int ProblemNumber { get; }
        Answer GetAnswer();
    }
}
