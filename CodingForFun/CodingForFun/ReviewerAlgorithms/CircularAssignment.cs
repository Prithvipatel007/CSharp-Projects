using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun.ReviewerAlgorithms
{
    public class CircularReviewerAssignment : IReviewerStrategy
    {
        private readonly List<Person> _persons;
        private int _round = 1;

        public CircularReviewerAssignment(List<Person> persons)
        {
            _persons = persons;
        }

        public Dictionary<Person, Person> GetNextReviewRound()
        {
            int n = _persons.Count;
            var round = new Dictionary<Person, Person>();

            for (int i = 0; i < n; i++)
            {
                int reviewerIndex = (i + _round) % n;
                if (i == reviewerIndex)
                    throw new InvalidOperationException("Self-review occurred in circular strategy.");

                round[_persons[i]] = _persons[reviewerIndex];
            }

            _round = (_round + 1) % n;
            return round;
        }
    }
}
