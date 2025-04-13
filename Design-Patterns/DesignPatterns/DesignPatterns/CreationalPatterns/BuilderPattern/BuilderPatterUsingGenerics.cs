using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person _Person = new Person();

        public Person Build()
        {
            return _Person;
        }
    }


    // Lets imagine we have two builders, first is PersonalInfoBuilder
    // where SELF : PersonalInfoBuilder<SELF> -> the meaning behind this is that there will only be 
    // one situation where we are allowing. We are allowing in the situation where self refers to the object
    // inheriting form this object. So, the derived class is going to be derived from PersonalInfoBuilder
    public class PersonalInfoBuilder<SELF> : PersonBuilder where SELF : PersonalInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            _Person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonalInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            _Person.Position = position;
            return (SELF)this;
        }
    }


}
