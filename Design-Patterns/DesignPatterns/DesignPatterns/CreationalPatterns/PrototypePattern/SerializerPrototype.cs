using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public static class ExtensionMethods
    {
        // Extension method to deep copy using binary serializer
        public static T DeepCopyBinary<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);

            stream.Seek(0, SeekOrigin.Begin);   // its the offset of zero from the beginning.
            object copy = formatter.Deserialize(stream);
            stream.Close();

            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);

                ms.Position = 0;    // Reset the position of the stream to the beginning
                return (T)s.Deserialize(ms);
            }
        }
    }

    public class SerialProto_Person
    {
        public string[] Names;
        public SerialProto_Address Address;

        public SerialProto_Person()
        {
            
        }

        public SerialProto_Person(string[] names, SerialProto_Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} : {Address.ToString()}";
        }
    }

    public class SerialProto_Address
    {
        public string StreetName;
        public int HouseNumber;

        public SerialProto_Address()
        {
            
        }

        public SerialProto_Address(string streetName, int number)
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
