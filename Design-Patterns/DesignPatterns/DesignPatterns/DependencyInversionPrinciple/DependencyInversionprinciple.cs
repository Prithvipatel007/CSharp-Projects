using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInversionPrinciple
{
    /*
     * Genealogy Application example
     */

    public enum RelationShip
    {
        Parent,
        Child, 
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    // Low level relationships
    public class Relationships : IRelationshipBrowser
    {
        // A private list of people with relationships
        private List<(Person, RelationShip, Person)> _Relations = new List<(Person, RelationShip, Person)>();

        // on the low level, we can define an API to add parent and child relationship
        public void AddParentAndChild(Person Parent, Person Child)
        {
            _Relations.Add((Parent, RelationShip.Parent, Child));   //=>  Relationship of parent to the child
            _Relations.Add((Child, RelationShip.Child, Parent));   //=>  Relationship of child to the parent
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _Relations.Where(x => x.Item1.Name == name && x.Item2 == RelationShip.Parent)
                             .Select(per => per.Item3);
        }
    }


    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }


    // This is High-level module, it just lies here to have an organized code.
    public class Research
    { 
        public Research(IRelationshipBrowser relationshipBrowser)
        {
            foreach(var child in relationshipBrowser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {child.Name}");
            }
        }
    }
}
