using DesignPatterns.OpenClosedPrinciple.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns.StructuralPatterns.CompositePatterns
{
    public static class Composite_Main
    {
        /*
         * This example emulates a drawing application, where we have different shapes like squares and circles or whatever. 
         * But you can also group shapes together. Once you group several shapes together, you can drag that entire group. 
         * Thats what we are going to implement in the composite design pattern. 
         */
        public static void GeometricShapes()
        {
            var drawing = new GraphicObject
            {
                Name = "My Drawings"
            };

            drawing.Children.Add(new Square() { Color = "Red" });
            drawing.Children.Add(new Circle() { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle() { Color = "Blue" });
            group.Children.Add(new Square() { Color = "Blue" });


            drawing.Children.Add(group);

            Console.WriteLine(drawing.ToString());
        }

        // One component of machine learning is Neural Networks.
        // Here is how the composite design pattern can show up in the simple simulation of neurons and neuron layers and how 
        // they are connected
        public static void NeuralNetworks()
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);

            layer1.ConnectTo(neuron2);

        }

        public static void CompositeSpecification()
        {
            var apple = new CSProduct("Apple", CSColors.Red, CSSizes.Small);
            var tree = new CSProduct("Tree", CSColors.Green, CSSizes.Large);
            var house = new CSProduct("House", CSColors.Green, CSSizes.Medium);

            CSProduct[] products = { apple, tree, house };

            /*
             * CS Better Filter
             */
            var bf = new CSBetterFilter();
            Console.WriteLine("Green products (new) : ");
            foreach (var item in bf.Filter(products, new CSColorSpecification(CSColors.Green)))
            {
                Console.WriteLine($" {item.Name} is Green");
            }

            Console.WriteLine("Filter by size : ");
            foreach (var item in bf.Filter(products, new CSSizeSpecification(CSSizes.Small)))
            {
                Console.WriteLine($" {item.Name} is Small");
            }

            Console.WriteLine("Filter by size and color : ");
            foreach (var item in bf.Filter(products, new CSAndSpecification<CSProduct>(new CSColorSpecification(CSColors.Green),
                                                                                    new CSSizeSpecification(CSSizes.Medium))))
            {
                Console.WriteLine($" {item.Name} is Green and Medium");
            }
        }

        public static void CompositeCodingExercise()
        {
            var singleValue = new SingleValue { Value = 5 };
            var singleValueTwo = new SingleValue { Value = 4 };

            List<IValueContainer> listValues = new List<IValueContainer> { singleValue, singleValueTwo };

            int result = listValues.SumComposite();
            Console.WriteLine(result);

        }


    }
}
