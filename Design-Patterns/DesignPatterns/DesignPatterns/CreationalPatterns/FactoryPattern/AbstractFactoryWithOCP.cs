using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public class Abstract_FactoryWithOCP
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public Abstract_FactoryWithOCP()
        {
            foreach(var type in typeof(IHotDrinkFactory).Assembly.GetTypes())
            {
                if(typeof(IHotDrinkFactory).IsAssignableFrom(type) && 
                    !type.IsInterface)
                {
                    factories.Add(Tuple.Create(
                            type.Name.Replace("Factory", string.Empty),
                            Activator.CreateInstance(type) as IHotDrinkFactory
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("List of available drinks");
            
            for(int idx = 0; idx < factories.Count; idx++ )
            {
                var tuple = factories[idx];
                Console.WriteLine($"{idx} : {tuple.Item1}");
            }

            while(true)
            {
                string s;
                if((s = Console.ReadLine()) != null &&
                    int.TryParse(s, out var i) &&
                    i >= 0 && i < factories.Count)
                {
                    Console.WriteLine("Specify Amount");
                    s = Console.ReadLine();

                    if (s != null && int.TryParse(s, out var amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again");
            }

        }
    }
}
