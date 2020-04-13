namespace ProjectEuler.Solutions
{
    public static class AnswerExtensions
    {
        public static Answer ToAnswer(this int value)
        {
            return new Answer() { Value = value };
        }
    }
}