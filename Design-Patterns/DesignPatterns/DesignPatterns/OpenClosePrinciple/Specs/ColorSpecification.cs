using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.OpenClosedPrinciple.Filter
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Colors _Color;

        public ColorSpecification(Colors color)
        {
            _Color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == _Color;
        }
    }
}
