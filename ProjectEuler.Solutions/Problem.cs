using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Solutions
{
    public class Problem : IProblem
    {
       public Problem(string title, string description, int number)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new System.ArgumentException("message", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new System.ArgumentException("message", nameof(description));
            }
    

            Title = title;
            Description = description;
            Number = number;
        }

        public string Title { get; }
        public string Description { get; }

        public int Number { get; }
    }
}
