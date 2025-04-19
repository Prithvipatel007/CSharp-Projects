using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private static int _Counter = 0;
        private readonly List<WeakReference<Person>> factories = new List<WeakReference<Person>>();

        public Person CreatePerson(string name)
        {
            var person = new Person
            {
                Id = _Counter++,
                Name = name
            };
            factories.Add(new WeakReference<Person>(person));
            return person;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach(var factory in factories)
                {
                    if (factory.TryGetTarget(out var person))
                    {
                        sb.AppendLine($"Id: {person.Id}, Name: {person.Name}");
                    }
                    else
                    {
                        sb.AppendLine("Person has been garbage collected");
                    }
                }

                return sb.ToString();
            }
        }

    }


}
