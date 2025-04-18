using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public class FacetedBuilderPattern
    {
        public class Faceted_Person
        {
            // Address
            public string StreetAddress, Postcode, City;

            // Employment
            public string CompanyName, Position;
            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, " +
                       $"{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }

        public class Faceted_PersonBuilder // This is a facade, It does not really build up person,
                                           // but it keeps of the reference to the person thats being built. 
                                           // Secondly, it allows us to access those sub-builders
        {
            // This is a reference object. This is important, because If you are building up a struct,
            // you might have a lot of problems. This can be mitigated.
            protected Faceted_Person faceted_Person = new Faceted_Person();

            public Faceted_PersonJobBuilder Works => new Faceted_PersonJobBuilder(faceted_Person);

            public Faceted_PersonAddressBuilder Lives => new Faceted_PersonAddressBuilder(faceted_Person);

            public static implicit operator Faceted_Person(Faceted_PersonBuilder pb)
            {
                return pb.faceted_Person;
            }

        }

        public class Faceted_PersonAddressBuilder : Faceted_PersonBuilder
        {
            // This does not work with value type
            public Faceted_PersonAddressBuilder(Faceted_Person person)
            {
                faceted_Person = person;
            }

            public Faceted_PersonAddressBuilder At(string streetAddress)
            {
                faceted_Person.StreetAddress = streetAddress;
                return this;
            }

            public Faceted_PersonAddressBuilder WithPostCode(string postCode)
            {
                faceted_Person.Postcode = postCode;
                return this;
            }

            public Faceted_PersonAddressBuilder In(string city)
            {
                faceted_Person.City = city;
                return this;
            }
        }


        public class Faceted_PersonJobBuilder : Faceted_PersonBuilder
        {
            public Faceted_PersonJobBuilder(Faceted_Person person)
            {
                this.faceted_Person = person;
            }

            public Faceted_PersonJobBuilder At(string companyName)
            {
                faceted_Person.CompanyName = companyName;
                return this;
            }

            public Faceted_PersonJobBuilder AsA(string position)
            {
                faceted_Person.Position = position;
                return this;
            }

            public Faceted_PersonJobBuilder Earns(int amount)
            {
                faceted_Person.AnnualIncome = amount;
                return this;
            }
        }




    }
}
