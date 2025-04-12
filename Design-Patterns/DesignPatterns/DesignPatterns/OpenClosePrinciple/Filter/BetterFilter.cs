using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.OpenClosedPrinciple.Filter
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specs)
        {
            foreach(var item in items)
            {
                if(specs.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }
}
