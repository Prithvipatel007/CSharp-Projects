using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{
    public static class Decorator_Main
    {

        public static void CustomStringBuilder()
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
              .AppendLine("{")
              .AppendLine("\t props")
              .AppendLine("}");

            Console.WriteLine(cb.ToString());
        }

        public static void DecoratorAdaptorPattern()
        {
            MyStringBuilder s = "hello ";
            s += "world";
            Console.WriteLine(s);
        }

        public static void DecoratorMultipleInheritanceWithInterfaces()
        {
            var d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();
        }

        // Decorator on the top of decorator
        public static void DynamicDecoratorComposition()
        {
            //var sq = new DDDSquare(1.23f);
            //Console.WriteLine(sq.AsString());

            //var redSquare = new ColoredShape(sq, "Red");
            //Console.WriteLine(redSquare.AsString());

            //var transparent = new TransparentShape(redSquare, 0.8f);
            //Console.WriteLine(transparent.AsString());

            var circle = new DDDCircle(2);
            var colored1 = new ColoredShape(circle, "red");
            var colored2 = new ColoredShape(colored1, "blue");

            Console.WriteLine(colored2.AsString());

        }



    }
}
