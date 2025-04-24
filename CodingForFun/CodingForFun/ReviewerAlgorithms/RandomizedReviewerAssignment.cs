using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun.ReviewerAlgorithms
{
    public class RandomizedReviewerAssignment : IReviewerStrategy
    {
        private readonly List<Person> _persons;
        private Dictionary<int, HashSet<int>> _history;
        private int _round = 0;

        public RandomizedReviewerAssignment(List<Person> persons)
        {
            _persons = persons;
            _history = persons.ToDictionary(p => p.Id, p => new HashSet<int>());
        }

        public Dictionary<Person, Person> GetNextReviewRound()
        {
            int n = _persons.Count;
            var authors = _persons.OrderBy(p => p.Id).ToList();

            for (int attempt = 0; attempt < 1000; attempt++)
            {
                var reviewers = _persons.OrderBy(p => ((_round + attempt + p.Id) * 17) % 1000).ToList();

                var round = new Dictionary<Person, Person>();
                var usedReviewerIds = new HashSet<int>();
                bool valid = true;

                for (int i = 0; i < n; i++)
                {
                    var author = authors[i];
                    var reviewer = reviewers[i];

                    if (author.Id == reviewer.Id || usedReviewerIds.Contains(reviewer.Id) || _history[author.Id].Contains(reviewer.Id))
                    {
                        valid = false;
                        break;
                    }

                    round[author] = reviewer;
                    usedReviewerIds.Add(reviewer.Id);
                }

                if (valid)
                {
                    foreach (var kvp in round)
                        _history[kvp.Key.Id].Add(kvp.Value.Id);

                    // Reset after full cycle
                    if (_history.All(kvp => kvp.Value.Count == n - 1))
                    {
                        Console.WriteLine("🔁 Full random review cycle complete, resetting history.");
                        _history = _persons.ToDictionary(p => p.Id, p => new HashSet<int>());
                        _round = 0;
                    }
                    else
                    {
                        _round++;
                    }

                    return round;
                }
            }

            throw new Exception("Failed to generate random valid round.");
        }
    }

}
