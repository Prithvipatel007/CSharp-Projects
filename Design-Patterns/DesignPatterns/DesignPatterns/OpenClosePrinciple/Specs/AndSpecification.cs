using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OpenClosedPrinciple.Filter
{
    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> _First, _Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            if(first == null)
                throw new ArgumentNullException(nameof(first));

            if (second == null)
                throw new ArgumentNullException(nameof(second));

            _First = first;
            _Second = second;
        }

        public bool IsSatisfied(T t)
        {
            return _First.IsSatisfied(t) && _Second.IsSatisfied(t);
        }
    }
}
