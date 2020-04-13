namespace ProjectEuler.Solutions
{
    public interface IProblem
    {
        int Number { get; }
        string Title { get; }
        string Description { get; }
    }
}
