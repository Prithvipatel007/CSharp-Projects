using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    public interface IDatabase
    {
        int GetPopulation(string name);  // get population of a city
    }

    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;
        
        private static int count = 0;
        public static int Count => count;

        private string path = "D:\\Personal Work\\CSharp-Projects\\Design-Patterns\\DesignPatterns\\DesignPatterns\\CreationalPatterns\\SingletonPattern\\capitals.txt";

        private SingletonDatabase()
        {
            count++;
            Console.WriteLine("Initializing Database");
            capitals = File.ReadAllLines(path)
                       .Batch(2)
                       .ToDictionary(
                            list => list.ElementAt(0).Trim(),   // City Name
                            list => int.Parse(list.ElementAt(1)) // population
                        );
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
        
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;


        private string path = "D:\\Personal Work\\CSharp-Projects\\Design-Patterns\\DesignPatterns\\DesignPatterns\\CreationalPatterns\\SingletonPattern\\capitals.txt";

        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing Database");
            capitals = File.ReadAllLines(path)
                       .Batch(2)
                       .ToDictionary(
                            list => list.ElementAt(0).Trim(),   // City Name
                            list => int.Parse(list.ElementAt(1)) // population
                        );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>()
            {
                {"alpha", 1 },
                {"beta", 2},
                {"gamma", 3},
                {"delta", 4},
                {"epsilon", 5}
            }[name];
        }
    }

    


}
