using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingForFun.ReviewerAlgorithms
{
    public interface IReviewerStrategy
    {
        Dictionary<Person, Person> GetNextReviewRound();
    }
}
