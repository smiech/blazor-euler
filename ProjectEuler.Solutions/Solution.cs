namespace ProjectEuler.Solutions
{
    public class Solution1 : ISolution
    {
        public int ProblemNumber => 1;

        public Answer GetAnswer()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum.ToAnswer();
        }
    }
}
