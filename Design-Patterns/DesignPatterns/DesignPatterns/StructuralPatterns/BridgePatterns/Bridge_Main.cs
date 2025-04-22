using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePatterns
{
    public static class Bridge_Main
    {
        public static void BridgePattern()
        {
            /*
             * By simply passing the renderer to the circle
             */
            //IRenderer renderer =  new RasterRenderer();
            IRenderer renderer =  new VectorRenderer();

            var circle = new Circle(renderer, 5);

            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }

        public static void DIBridgePattern()
        {
            // Having to pass the renderer is tedious for 100s of objects. So dependency injection is easier ways
             
            var container = new ContainerBuilder();
            container.RegisterType<VectorRenderer>().As<IRenderer>()
                .SingleInstance();

            container.Register((context, parameter) => new Circle(
                                                        context.Resolve<IRenderer>(),           // Resolve via context
                                                        parameter.Positional<float>(0)));       // Provide value as position

            using (var c = container.Build())
            {
                var circle = c.Resolve<Circle>(
                        new PositionalParameter(0, 5.0f)        // position at 0 and value provided as float is 5.0
                    );

                circle.Draw();
                circle.Resize(2);
                circle.Draw();
            }
        }

        public static void BridgeCodingExercise()
        {
            Console.WriteLine(new Triangle(new CERasterRenderer()).ToString());
        }
    }
}
