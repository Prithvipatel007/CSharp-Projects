using CodingForFun.ReviewerAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "Alexander" },
                new Person { Id = 2, Name = "Chaitanya" },
                new Person { Id = 3, Name = "Keyur" },
                new Person { Id = 4, Name = "Prithvi" },
                new Person { Id = 5, Name = "Raheleh" }
            };

            var reviewCounts = new Dictionary<(int ReviewerId, int AuthorId), int>();
            var strategy = new BacktrackingReviewerStrategy(people);
            var scheduler = new ReviewScheduler(strategy);

            int totalRounds = 100;

            for (int i = 1; i <= totalRounds; i++)
            {
                Console.WriteLine($"Round {i}:");
                var round = scheduler.GetNextRound();

                foreach (var pair in round)
                {
                    Console.WriteLine($"{pair.Key.Name} <- {pair.Value.Name}");

                    var key = (pair.Value.Id, pair.Key.Id); // ReviewerId → AuthorId
                    if (!reviewCounts.ContainsKey(key))
                        reviewCounts[key] = 0;

                    reviewCounts[key]++;
                }

                Console.WriteLine();
            }

            // Final Summary Table
            Console.WriteLine("📊 Review Summary Table (Reviewer → Author Count):\n");

            foreach (var reviewer in people)
            {
                foreach (var author in people)
                {
                    if (reviewer.Id == author.Id) continue;

                    var key = (reviewer.Id, author.Id);
                    reviewCounts.TryGetValue(key, out int count);
                    Console.WriteLine($"{reviewer.Name} → {author.Name} = {count} times");
                }
                Console.WriteLine();
            }

            // Behavioral Benchmark
            Console.WriteLine("📈 Behavioral Metrics Summary\n");

            int totalAssignments = reviewCounts.Values.Sum();
            int uniquePairs = reviewCounts.Keys.Count;
            int repeatedPairs = reviewCounts.Values.Count(v => v > 1);
            int maxRepeats = reviewCounts.Values.Max();
            int minRepeats = reviewCounts.Values.Min();

            double mean = totalAssignments / (double)uniquePairs;
            double variance = reviewCounts.Values.Average(v => Math.Pow(v - mean, 2));
            double stddev = Math.Sqrt(variance);

            Console.WriteLine($"Total Rounds: {totalRounds}");
            Console.WriteLine($"Total Assignments: {totalAssignments}");
            Console.WriteLine($"Unique Reviewer-Author Pairs: {uniquePairs}");
            Console.WriteLine($"Repeated Pairs (>1): {repeatedPairs}");
            Console.WriteLine($"Max Repeats for Any Pair: {maxRepeats}");
            Console.WriteLine($"Min Repeats for Any Pair: {minRepeats}");
            Console.WriteLine($"Standard Deviation of Pair Repeats: {stddev:F2}\n");

            Console.WriteLine("📈 Reviewer Diversity:");
            foreach (var reviewer in people)
            {
                var distinctAuthors = reviewCounts.Keys
                    .Where(k => k.ReviewerId == reviewer.Id)
                    .Select(k => k.AuthorId)
                    .Distinct()
                    .Count();
                Console.WriteLine($"{reviewer.Name} reviewed {distinctAuthors} different people.");
            }

            Console.WriteLine("\n📈 Author Diversity:");
            foreach (var author in people)
            {
                var distinctReviewers = reviewCounts.Keys
                    .Where(k => k.AuthorId == author.Id)
                    .Select(k => k.ReviewerId)
                    .Distinct()
                    .Count();
                Console.WriteLine($"{author.Name} was reviewed by {distinctReviewers} different people.");
            }


        }
    }
}
