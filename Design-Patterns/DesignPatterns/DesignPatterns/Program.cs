using DesignPatterns.CreationalPatterns.BuilderPattern;
using DesignPatterns.DependencyInversionPrinciple;
using DesignPatterns.InterfaceSegregationPrinciple;
using DesignPatterns.LiskovSubstitutionPrinciple;
using DesignPatterns.OpenClosedPrinciple.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private static Pattern _Pattern = Pattern.BuilderPatternWithRecursiveGenerics;

        #region Enum for Patterns
        public enum Pattern
        {
            SingleResponsibilityPrinciple,
            OpenClosedPrinciple,
            LiskovSubstitutionPrinciple,
            InterfaceSegregationPrinciple,
            DependencyInversionPrinciple,
            BuilderPattern,
            BuilderPatternWithRecursiveGenerics,
            StepwiseBuilderPattern,
            FunctionalBuilderPattern,
            FacetedBuilderPattern,
        }
        #endregion

        #region Private Fields
        private static Action action = null;

        private static Dictionary<Pattern, Action> _PatternDict = new Dictionary<Pattern, Action>()
        {
            { Pattern.SingleResponsibilityPrinciple, SingleResponsibilityPrinciple },
            { Pattern.OpenClosedPrinciple, OpenClosedPrinciple },
            { Pattern.LiskovSubstitutionPrinciple, LiskovSubstitutionPrinciple},
            { Pattern.InterfaceSegregationPrinciple, InterfaceSegregationPrinciple},
            { Pattern.DependencyInversionPrinciple, DependencyInversionPrinciple},
            { Pattern.BuilderPattern, BuilderPattern},
            { Pattern.BuilderPatternWithRecursiveGenerics, BuilderPatternWithRecursiveGenerics},
            { Pattern.StepwiseBuilderPattern, StepwiseBuilderPattern},
            { Pattern.FunctionalBuilderPattern, FunctionalBuilderPattern},
            { Pattern.FacetedBuilderPattern, FacetedBuilderPattern}

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

        #region Liskov Substitution Principle

        public static int Area(Rectangle r) => r.Width * r.Height;
        private static void LiskovSubstitutionPrinciple()
        {
            Rectangle rc = new Rectangle(5, 10);
            Console.WriteLine($"Area of Rectangle : {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 5;
            Console.WriteLine($"Area of Square : {Area(sq)}");
        }

        #endregion

        #region Interface Segregation Principle

        private static void InterfaceSegregationPrinciple()
        {
            var printer = new Printer();
            var scanner = new Scanner();
            var fax = new FaxMachine();

            printer.Print(new Document("Printer", "Printer Content"));
            scanner.Scan(new Document("Scanner", "Scanner Content"));
            fax.Fax(new Document("Fax", "Fax Content"));

            var multiPrinter = new MultiPrinter(printer, scanner, fax);
            multiPrinter.Print(new Document("MultiPrinter", "Printing Content"));
            multiPrinter.Scan(new Document("MultiPrinter", "Scannning Content"));
            multiPrinter.Fax(new Document("MultiPrinter", "Faxing Content"));
        }


        #endregion

        #region Dependency Inversion Principle

        private static void DependencyInversionPrinciple()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Anna" };

            var Relationships = new Relationships();
            Relationships.AddParentAndChild(parent, child1);
            Relationships.AddParentAndChild(parent, child2);

            // Now we want to perform the research. Basically, we want to take the low level module 
            // and we want to somehow access it to a high level research module. 
            // So, one of the ways - not the best way - is to simply allow the high level module to access some of the internals
            // of the low level module by giving it the list of relations. 

            new Research(Relationships);
        }

        #endregion


        #region Creational patterns

        #region Builder Pattern
        
        private static void BuilderPattern()
        {
            var hello = "hello";

            // We have this text and we want to turn it into a html paragraph. 
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] {"hello", "world" };
            sb.Clear();

            sb.Append("<ul>");
            foreach(var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("</ul>");

            Console.WriteLine(sb);

            /*
             * With Builder
             */
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello")
                   .AddChild("li", "World");

            Console.WriteLine(builder.ToString());
        }

        private static void BuilderPatternWithRecursiveGenerics()
        {
            var me = CreationalPatterns.BuilderPattern.Person.New
                        .Called("Prithvi")
                        .WorksAsA("Developer")
                        .Build();

            Console.WriteLine(me.ToString());
        }

        private static void StepwiseBuilderPattern()
        {
            var car = CarBuilder.Create()   // we get ISpecifyCarType
                                .OfCarType(CarType.Crossover) // here, we get ISpecifyWheelType
                                .WithWheels(19)  // here, we get IBuildCar
                                .Build();  // Here we get car
        }

        private static void FunctionalBuilderPattern()
        {
            var person = new FuncPersonBuilder()
                            .WorkAs("Developer")
                            .Called("Prithvi")
                            .Build();
        }

        private static void FacetedBuilderPattern()
        {

        }


        #endregion

        #endregion

        #endregion
    }
}
