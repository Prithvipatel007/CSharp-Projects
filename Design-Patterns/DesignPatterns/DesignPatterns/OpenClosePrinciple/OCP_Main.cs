using DesignPatterns.OpenClosedPrinciple.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.OpenClosePrinciple
{
    public static class OCP_Main
    {
        public static void OpenClosedPrinciple()
        {
            var apple = new Product("Apple", Colors.Red, Sizes.Small);
            var tree = new Product("Tree", Colors.Green, Sizes.Large);
            var house = new Product("House", Colors.Green, Sizes.Medium);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old) : ");

            foreach (var p in pf.FilterByColor(products, Colors.Green))
            {
                Console.WriteLine($" {p.Name} is Green");
            }
            /*
             * Better Filter
             */
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new) : ");
            foreach (var item in bf.Filter(products, new ColorSpecification(Colors.Green)))
            {
                Console.WriteLine($" {item.Name} is Green");
            }

            Console.WriteLine("Filter by size : ");
            foreach (var item in bf.Filter(products, new SizeSpecification(Sizes.Small)))
            {
                Console.WriteLine($" {item.Name} is Small");
            }

            Console.WriteLine("Filter by size and color : ");
            foreach (var item in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Colors.Green),
                                                                                    new SizeSpecification(Sizes.Medium))))
            {
                Console.WriteLine($" {item.Name} is Green and Medium");
            }

        }
    }
}
