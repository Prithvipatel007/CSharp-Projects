using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.StructuralPatterns.CompositePatterns
{
    // We introduce two new interfaces that are open for extensions

    public enum CSColors
    {
        Red,
        Green,
        Blue
    }

    public enum CSSizes
    {
        Small,
        Medium,
        Large
    }

    public class CSProduct
    {
        public string Name;
        public CSColors Color;
        public CSSizes Size;

        public CSProduct(string name, CSColors color, CSSizes size)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Color = color;
            Size = size;
        }
    }


    public abstract class ICSSpecification<T>
    {
        public abstract bool IsSatisfied(T t);

        public static ICSSpecification<T> operator & (ICSSpecification<T> first, ICSSpecification<T> second)
        {
            return new CSAndSpecification<T>(first, second);
        }
    }

    public interface ICSFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ICSSpecification<T> spec);
    }

    public class CSColorSpecification : ICSSpecification<CSProduct>
    {
        private CSColors color;

        public CSColorSpecification(CSColors color)
        {
            this.color = color;
        }


        public override bool IsSatisfied(CSProduct t)
        {
            return t.Color == this.color;
        }
    }

    public class CSSizeSpecification : ICSSpecification<CSProduct>
    {
        private CSSizes size;

        public CSSizeSpecification(CSSizes size)
        {
            this.size = size;
        }

        public override bool IsSatisfied(CSProduct t)
        {
            return t.Size == this.size;
        }
    }

    public abstract class CompositeSpecification<T> : ICSSpecification<T> 
    {
        protected readonly ICSSpecification<T>[] specs;

        /*
         * Composite specification is basically keeping a collection of specifications. 
         * So, thats the classic composite design.
         */

        public CompositeSpecification(params ICSSpecification<T>[] specs)
        {
            this.specs = specs;
        }
    }

    /*
     * AndSpecification is typically what we call a combinator which combines other things together
     * The choice for first and second element can be completely arbitrary. 
     */
    public class CSAndSpecification<T> : CompositeSpecification<T>
    {
        public CSAndSpecification(params ICSSpecification<T>[] specs) : base(specs)
        {
            
        }

        public override bool IsSatisfied(T t)
        {
            // If we use Any, we get an OR specification
            return specs.All(i => i.IsSatisfied(t));
        }
    }

    public class CSBetterFilter : ICSFilter<CSProduct>
    {
        public IEnumerable<CSProduct> Filter(IEnumerable<CSProduct> items, ICSSpecification<CSProduct> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }





}
