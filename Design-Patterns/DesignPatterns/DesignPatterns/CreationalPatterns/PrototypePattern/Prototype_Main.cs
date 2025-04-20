using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public static class Prototype_Main
    {
        public static void IClonableIsBadExample()
        {
            var john = new Person(new[] { "John", "Doe" }, new Address("Main St", 123));

            Console.WriteLine(john);

            var jane = (Person)john.Clone();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(jane);
        }

        public static void CopyConstructorExample()
        {
            var john = new CopyCtor_Person(new[] { "John", "Doe" }, new CopyCtor_Address("Main St", 123));

            Console.WriteLine(john);

            var jane = new CopyCtor_Person(john);
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(jane);
        }

        public static void ExplicitDeepCopy()
        {
            var john = new Prototype_Person(new[] { "John", "Doe" }, new Prototype_Address("Main St", 123));
            Console.WriteLine(john);

            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(jane);
        }

        public static void PrototypeInheritance()
        {
            var john = new Employee();
            john.Names = new[] { "John", "Doe" };
            john.Address = new ProtoInherit_Address("Main St", 123);
            john.Salary = 1000;

            var copy = john.DeepCopy();
            copy.Names[0] = "Jane";
            copy.Address.HouseNumber = 456;
            copy.Salary = 2000;

            Console.WriteLine(john);
            Console.WriteLine(copy);
        }

        public static void SerializerPrototype()
        {
            var john = new SerialProto_Person(new[] { "John", "Doe" }, new SerialProto_Address("Main St", 123));
            Console.WriteLine(john);

            // using binary serializer, all the classes must be marked as [Serializable]
            // var jane = john.DeepCopyBinary(); 
            // Alternative is XML serializer
            var jane = john.DeepCopyXml();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(jane);
        }

        public static void PrototypeCodingExercise()
        {
            var p1 = new Point()
            {
                X = 0,
                Y = 0
            };

            var p2 = new Point()
            {
                X = 10,
                Y = 10
            };

            var line = new Line()
            {
                Start = p1,
                End = p2
            };

            Console.WriteLine(line);

            var copy = line.DeepCopyXml();

            copy.Start.X = 5;
            copy.Start.Y = 5;

            Console.WriteLine(copy);
        }


    }
}
