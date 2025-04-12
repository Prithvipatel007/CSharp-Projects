using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.OpenClosedPrinciple.Filter
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Sizes _Size;

        public SizeSpecification(Sizes size)
        {
            _Size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return _Size == t.Size;
        }
    }
}
