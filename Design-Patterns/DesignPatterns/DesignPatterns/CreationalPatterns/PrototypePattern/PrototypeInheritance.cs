using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);

        // Incase of .NET Core, default interface methods can be implemented right here. So that, it shall not be implemented in the same classes everywhere.
        T DeepCopy();
    }

    public class ProtoInherit_Address : IDeepCopyable<ProtoInherit_Address>
    {
        public string StreetName;
        public int HouseNumber;

        public ProtoInherit_Address()
        {
            
        }

        public ProtoInherit_Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public void CopyTo(ProtoInherit_Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }

        public ProtoInherit_Address DeepCopy()
        {
            var copy = new ProtoInherit_Address();
            CopyTo(copy);
            return copy;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)} : {StreetName}, " +
                   $"{nameof(HouseNumber)} : {HouseNumber}";
        }
    }

    public class ProtoInherit_Person : IDeepCopyable<ProtoInherit_Person>
    {
        public string[] Names;
        public ProtoInherit_Address Address;

        public ProtoInherit_Person()
        {
            
        }

        public ProtoInherit_Person(string[] names, ProtoInherit_Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public void CopyTo(ProtoInherit_Person target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }

        public ProtoInherit_Person DeepCopy()
        {
            var copy = new ProtoInherit_Person();
            CopyTo(copy);
            return copy;
        }

        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ", Names)}, " +
                   $"{nameof(Address)} : {Address.ToString()}";
        }
    }

    public class Employee : ProtoInherit_Person, IDeepCopyable<Employee>
    {
        public int Salary;

        public Employee()
        {
            
        }

        public Employee(string[] names, ProtoInherit_Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, " +
                   $"{nameof(Salary)} : {Salary}";
        }

        public Employee DeepCopy()
        {
            var copy = new Employee();
            CopyTo(copy);
            return copy;
        }
    }

    //public static class ExtensionMethods
    //{
    //    public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
    //    {
    //        return item.DeepCopy();
    //    }
    //}

}
