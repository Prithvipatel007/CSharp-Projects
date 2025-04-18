using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.CreationalPatterns.BuilderPattern.FacetedBuilderPattern;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public static class Builder_Main
    {

        public static void BuilderPattern()
        {
            var hello = "hello";

            // We have this text and we want to turn it into a html paragraph. 
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();

            sb.Append("<ul>");
            foreach (var word in words)
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

        public static void BuilderPatternWithRecursiveGenerics()
        {
            var me = CreationalPatterns.BuilderPattern.Person.New
                        .Called("Prithvi")
                        .WorksAsA("Developer")
                        .Build();

            Console.WriteLine(me.ToString());
        }

        public static void StepwiseBuilderPattern()
        {
            var car = CarBuilder.Create()   // we get ISpecifyCarType
                                .OfCarType(CarType.Crossover) // here, we get ISpecifyWheelType
                                .WithWheels(19)  // here, we get IBuildCar
                                .Build();  // Here we get car
        }

        public static void FunctionalBuilderPattern()
        {
            var person = new FuncPersonBuilder()
                            .WorkAs("Developer")
                            .Called("Prithvi")
                            .Build();
        }

        public static void FacetedBuilderPattern()
        {
            var pb = new Faceted_PersonBuilder();
            // Implicit call from pb to Faceteed_Person
            Faceted_Person person = pb.Works.At("Engelmann GmbH")
                                            .AsA("Software Engineer")
                                            .Earns(100000)
                                      .Lives.At("Goethe str 5")
                                            .WithPostCode("69181")
                                            .In("Leimen");

            Console.WriteLine(person.ToString());

        }

        public static void BuilderPatternCodingExercise()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }

    }
}
