using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public class SimpleFactoryMethod
    {
        public static class PointFactory
        {
            // This is call factory method - design pattern
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }


        public class Point
        {
            private double x, y;

            public override string ToString()
            {
                return $"X = {x}, Y = {y}";
            }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

        }

    }
}
