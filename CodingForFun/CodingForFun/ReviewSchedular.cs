using CodingForFun.ReviewerAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun
{
    public class ReviewScheduler
    {
        private IReviewerStrategy _strategy;

        public ReviewScheduler(IReviewerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IReviewerStrategy strategy)
        {
            _strategy = strategy;
        }

        public Dictionary<Person, Person> GetNextRound()
        {
            return _strategy.GetNextReviewRound();
        }
    }


}
