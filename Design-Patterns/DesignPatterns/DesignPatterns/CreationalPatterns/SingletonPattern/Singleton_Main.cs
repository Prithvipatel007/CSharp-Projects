using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    public static class Singleton_Main
    {
        public static void SingletonImplementation()
        {
            var db = SingletonDatabase.Instance;
            Console.WriteLine(db.GetPopulation("Tokyo"));
        }

        public static void MonostatePattern()
        {
            var ceo = new CEO();
            ceo.Name = "John Doe";
            ceo.Age = 45;

            var ceo2 = new CEO();

            Console.WriteLine(ceo);
            Console.WriteLine(ceo2);
        }

        public static void PreThreadedSingletonPattern()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"t1 : {PerThreadSingleton.Instance.Id}");
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"t2 : {PerThreadSingleton.Instance.Id}");
                Console.WriteLine($"t2 : {PerThreadSingleton.Instance.Id}");
            });

            Task.WaitAll(t1, t2);

        }

        public static void AmbientContextPattern()
        {
            var house = new Buildings();

            // Ground 3000 of height
            using(new BuildingContext(3000))
            {
                house.Walls.Add(new Wall(new WallPoint(0, 0), new WallPoint(5000, 0)));
                house.Walls.Add(new Wall(new WallPoint(0, 0), new WallPoint(0, 4000)));

                using(new BuildingContext(3500))
                {
                    // 1st floor - height is 3500 
                    house.Walls.Add(new Wall(new WallPoint(0, 0), new WallPoint(5000, 0)));
                    house.Walls.Add(new Wall(new WallPoint(0, 0), new WallPoint(0, 4000)));
                }

                // Back to ground floor
                house.Walls.Add(new Wall(new WallPoint(5000, 0), new WallPoint(5000, 4000)));
            }

            Console.WriteLine(house);


        }


        [TestFixture]
        public class SingletonTests
        {
            [Test]
            public void IsSingletonTest()
            {
                var db = SingletonDatabase.Instance;
                var db2 = SingletonDatabase.Instance;

                Assert.That(db, Is.SameAs(db2));

                Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
            }

            [Test]
            public void SingletonTotalPopulationTest()
            {
                var rf = new SingletonRecordFinder();
                var names = new List<string> { "Tokyo", "Seoul", "Mexico City" };

                int tp = rf.GetTotalPopulation(names);

                Assert.That(tp, Is.EqualTo(33200000 + 17500000 + 17400000));
            }

            [Test]
            public void ConfigurablePopulationTest()
            {
                var rf = new ConfigurableRecordFinder(new DummyDatabase());
                var tp = rf.GetTotalPopulation(new List<string> { "alpha", "beta" });

                Assert.That(tp, Is.EqualTo(3));
            }

            [Test]
            public void DIPopulationTest()
            {
                var cb = new ContainerBuilder();
                cb.RegisterType<OrdinaryDatabase>()
                  .As<IDatabase>()
                  .SingleInstance();
                cb.RegisterType<ConfigurableRecordFinder>();

                using(var container = cb.Build())
                {
                    var rf = container.Resolve<ConfigurableRecordFinder>();
                    var tp = rf.GetTotalPopulation(new List<string> { "Tokyo", "Seoul", "Mexico City" });
                    Assert.That(tp, Is.EqualTo(33200000 + 17500000 + 17400000));
                }

            }

        }
        
    }

    
}
