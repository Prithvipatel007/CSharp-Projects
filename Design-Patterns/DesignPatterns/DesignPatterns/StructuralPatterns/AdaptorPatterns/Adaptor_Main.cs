using Autofac;
using Autofac.Builder;
using Autofac.Features.Metadata;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdaptorPatterns
{
    public static class Adaptor_Main
    {
        public static void VectorRasterPattern()
        {
            VectorRasterDemo.Draw();
            VectorRasterDemo.Draw();
        }

        public static void GenericValueAdaptorPattern()
        {
            var vector = new Vector2i(1,2);
            vector[0] = 1;

            var v2 = new Vector2i(3, 2);

            var result = vector + v2;

            Vector3f u = Vector3f.Create(1.0f, 2.0f, 3.0f);

        }

        public static void DIAdaptorPattern()
        {
            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name","Save");
            b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            //b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>( cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();
                foreach (var button in editor.Buttons)
                {
                    button.PrintMe();
                    button.Click();
                }
            }
        }

        public static void AdaptorCodingExercise()
        {
            var square = new SquareToRectangleAdapter(new Square(5));
            int area = square.Area();

        }

    }
}
