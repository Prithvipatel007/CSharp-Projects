using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInversionPrinciple
{
    public static class DIP_Main
    {
        public static void DependencyInversionPrinciple()
        {
            var parent = new DependencyInversionPrinciple.Person { Name = "John" };
            var child1 = new DependencyInversionPrinciple.Person { Name = "Chris" };
            var child2 = new DependencyInversionPrinciple.Person { Name = "Anna" };

            var Relationships = new Relationships();
            Relationships.AddParentAndChild(parent, child1);
            Relationships.AddParentAndChild(parent, child2);

            // Now we want to perform the research. Basically, we want to take the low level module 
            // and we want to somehow access it to a high level research module. 
            // So, one of the ways - not the best way - is to simply allow the high level module to access some of the internals
            // of the low level module by giving it the list of relations. 

            new Research(Relationships);
        }
    }
}
