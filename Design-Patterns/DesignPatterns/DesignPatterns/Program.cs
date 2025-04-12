using DesignPatterns.OpenClosedPrinciple.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns
{
    internal class Program
    {
        /*
         * Switch to select the pattern to demonstrate
         */
        private static Pattern _Pattern = Pattern.OpenClosedPrinciple;

        #region Enum for Patterns
        public enum Pattern
        {
            SingleResponsibilityPrinciple,
            OpenClosedPrinciple
        }
        #endregion

        #region Private Fields
        private static Action action = null;

        private static Dictionary<Pattern, Action> _PatternDict = new Dictionary<Pattern, Action>()
        {
            {Pattern.SingleResponsibilityPrinciple, SingleResponsibilityPrinciple },
            { Pattern.OpenClosedPrinciple, OpenClosedPrinciple }
        };

        #endregion

        public static void Main(string[] args)
        {
            // Based on the pre-set Pattern, find the action in the dictionary and invoke it
            if (_PatternDict.TryGetValue(_Pattern, out action))
            {
                action.Invoke();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(_Pattern));
            }
        }

        #region Private Methods

        #region Single Responsibility Principle
        private static void SingleResponsibilityPrinciple()
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");

            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
        #endregion

        #region Open/Closed Principle

        private static void OpenClosedPrinciple()
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
            foreach(var item in bf.Filter(products, new ColorSpecification(Colors.Green)))
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

        #endregion

        #endregion
    }
}
