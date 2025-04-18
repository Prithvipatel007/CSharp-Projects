using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.CreationalPatterns.FactoryPattern.AsyncFactoryMethod;
using static DesignPatterns.CreationalPatterns.FactoryPattern.InnerFactory;
using static DesignPatterns.CreationalPatterns.FactoryPattern.SimpleFactoryMethod;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public static class Factory_Main
    {
        public static void SimpleFactoryMethod()
        {
            var point = PointFactory.NewPolarPoint(1, Math.PI / 2);
            Console.WriteLine(point);
        }

        public static async Task AsyncFactoryMethod()
        {
            var foo = await Foo.CreateAsync();
        }

        public static void ObjectTrackingAndBulkReplacementFactoryPattern()
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);

            Console.WriteLine(factory.Info);

            var factory2 = new ReplacableThemeFactory();
            var magicTheme = factory2.CreateTheme(true);
            Console.WriteLine(magicTheme.Value.TextColor);
            Console.WriteLine(magicTheme.Value.BgrColor);

            factory2.ReplaceTheme(false);
            Console.WriteLine(magicTheme.Value.TextColor);
            Console.WriteLine(magicTheme.Value.BgrColor);

        }

        public static  void InnerFactoryPattern()
        {
            var point = InnerPoint.InnerFactory.NewPolarPoint(1, Math.PI / 2);
            Console.WriteLine(point);
        }

        public static void AbstractFactoryPattern()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 10);
            drink.Consume();
        }

        public static void AbstractFactoryWithOCPPattern()
        {
            var machine = new Abstract_FactoryWithOCP();
            var drink = machine.MakeDrink();
            drink.Consume();

        }


    }
}
