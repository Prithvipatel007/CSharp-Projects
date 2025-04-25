using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{

	public interface IBird
	{
        int Weight { get; set; }
        void Fly();
	}

	public interface ILizard
	{
        int Weight { get; set; }
        void Crawl();
	}

	public class Bird : IBird
	{
        public int Weight { get; set; }

        public void Fly()
		{
            Console.WriteLine($"Soaring in the sky with weight {Weight}");
		}
	}

	public class Lizard : ILizard
	{
        public int Weight { get; set; }

        public void Crawl()
		{
            Console.WriteLine($"Crawling in the dirt with weight {Weight}");
		}
	}

    public class Dragon : IBird, ILizard
    {
		private Bird bird = new Bird();
		private Lizard lizard = new Lizard();
        private int weight;

        public int Weight 
        { 
            get { return weight; }
            set 
            {
                weight = value;
                bird.Weight = value; 
                lizard.Weight = value;
            } 
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
			bird.Fly();
        }
    }

}
