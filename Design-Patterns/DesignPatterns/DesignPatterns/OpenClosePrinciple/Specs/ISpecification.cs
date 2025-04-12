using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OpenClosedPrinciple.Filter 
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
