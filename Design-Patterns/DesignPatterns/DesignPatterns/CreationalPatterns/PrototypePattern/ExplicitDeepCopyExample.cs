using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Prototype_Person : IPrototype<Prototype_Person>
    {
        public string[] Names;
        public Prototype_Address Address;

        public Prototype_Person(string[] names, Prototype_Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public Prototype_Person DeepCopy()
        {
            return new Prototype_Person(Names, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} : {Address.ToString()}";
        }
    }

    public class Prototype_Address : IPrototype<Prototype_Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Prototype_Address(string streetName, int number)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = number;
        }

        public Prototype_Address DeepCopy()
        {
            return new Prototype_Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)} : {StreetName}, {nameof(HouseNumber)} : {HouseNumber}";
        }

    }


}
