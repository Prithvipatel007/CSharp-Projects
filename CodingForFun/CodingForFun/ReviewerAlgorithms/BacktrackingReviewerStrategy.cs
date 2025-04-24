using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun.ReviewerAlgorithms
{
    public class BacktrackingReviewerStrategy : IReviewerStrategy
    {
        private readonly List<Person> _persons;
        private readonly Dictionary<int, HashSet<int>> _reviewHistory;
        private int _round = 0;

        public string Name => "Backtracking Reviewer Assignment";

        public BacktrackingReviewerStrategy(List<Person> persons)
        {
            _persons = persons;
            _reviewHistory = persons.ToDictionary(p => p.Id, p => new HashSet<int>());
        }

        public Dictionary<Person, Person> GetNextReviewRound()
        {
            var usedReviewerIds = new HashSet<int>();
            var round = new Dictionary<Person, Person>();

            if (Backtrack(0, usedReviewerIds, round))
            {
                // Save history
                foreach (var kvp in round)
                {
                    _reviewHistory[kvp.Key.Id].Add(kvp.Value.Id);
                }

                // Reset after complete cycle
                if (_reviewHistory.All(kvp => kvp.Value.Count == _persons.Count - 1))
                {
                    Console.WriteLine("🔄 Full cycle complete. Resetting history.\n");
                    foreach (var key in _reviewHistory.Keys)
                    {
                        _reviewHistory[key].Clear();
                    }
                    _round = 0;
                }
                else
                {
                    _round++;
                }

                return round;
            }

            throw new InvalidOperationException("❌ No valid review round could be generated.");
        }

        private bool Backtrack(int index, HashSet<int> usedReviewerIds, Dictionary<Person, Person> round)
        {
            if (index == _persons.Count)
                return true;

            var author = _persons[index];

            var possibleReviewers = _persons
                .Where(r => r.Id != author.Id &&
                            !usedReviewerIds.Contains(r.Id) &&
                            !_reviewHistory[author.Id].Contains(r.Id))
                .OrderBy(_ => Guid.NewGuid()) // Shuffle to introduce randomness
                .ToList();

            foreach (var reviewer in possibleReviewers)
            {
                round[author] = reviewer;
                usedReviewerIds.Add(reviewer.Id);

                if (Backtrack(index + 1, usedReviewerIds, round))
                    return true;

                // Backtrack
                round.Remove(author);
                usedReviewerIds.Remove(reviewer.Id);
            }

            return false;
        }
    }

}
