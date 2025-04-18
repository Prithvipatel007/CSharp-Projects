using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LiskovSubstitutionPrinciple
{
    public static  class LSP_Main
    {
        public static int Area(Rectangle r) => r.Width * r.Height;
        public static void LiskovSubstitutionPrinciple()
        {
            Rectangle rc = new Rectangle(5, 10);
            Console.WriteLine($"Area of Rectangle : {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 5;
            Console.WriteLine($"Area of Square : {Area(sq)}");
        }
    }
}
