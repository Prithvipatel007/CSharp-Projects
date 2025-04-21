using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";
        }
    }
}
