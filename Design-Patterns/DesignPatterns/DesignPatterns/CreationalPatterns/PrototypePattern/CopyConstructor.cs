using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public class CopyCtor_Person
    {
        public string[] Names;
        public CopyCtor_Address Address;

        public CopyCtor_Person(string[] names, CopyCtor_Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public CopyCtor_Person(CopyCtor_Person other)
        {
            Names = other.Names.ToArray();
            Address = new CopyCtor_Address(other.Address);
        }


        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} : {Address.ToString()}";
        }
    }

    public class CopyCtor_Address
    {
        public string StreetName;
        public int HouseNumber;

        public CopyCtor_Address(CopyCtor_Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public CopyCtor_Address(string streetName, int number)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = number;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)} : {StreetName}, {nameof(HouseNumber)} : {HouseNumber}";
        }

    }
}
