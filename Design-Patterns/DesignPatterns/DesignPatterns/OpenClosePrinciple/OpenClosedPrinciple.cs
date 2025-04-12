using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OpenClosedPrinciple
{
    public class OpenClosedPrinciple
    {
        #region Enums
        public enum Colors
        {
            Red,
            Green,
            Blue
        }

        public enum  Sizes
        {
            Small,
            Medium,
            Large
        }

        #endregion

        public class Product
        {
            public string Name;
            public Colors Color;
            public Sizes Size;

            public Product(string name, Colors color, Sizes size)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                Name = name;
                Color = color;
                Size = size;
            }
        }

        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Sizes sizeToFilter)
            {
                foreach(var p in products)
                {
                    if(p.Size == sizeToFilter)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Colors colorToFilter)
            {
                foreach (var p in products)
                {
                    if (p.Color == colorToFilter)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Sizes sizeToFilter, Colors colorToFilter)
            {
                foreach (var p in products)
                {
                    if (p.Color == colorToFilter && p.Size == sizeToFilter)
                    {
                        yield return p;
                    }
                }
            }
        }

    }
}
