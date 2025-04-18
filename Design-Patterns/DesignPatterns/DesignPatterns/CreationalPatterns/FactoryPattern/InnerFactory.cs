using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public class InnerFactory
    {
        public class InnerPoint
        {
            private double x, y;

            public override string ToString()
            {
                return $"X = {x}, Y = {y}";
            }

            private InnerPoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static class InnerFactory
            {
                // This is call factory method - design pattern
                public static InnerPoint NewCartesianPoint(double x, double y)
                {
                    return new InnerPoint(x, y);
                }

                public static InnerPoint NewPolarPoint(double rho, double theta)
                {
                    return new InnerPoint(rho * Math.Cos(theta), rho * Math.Sin(theta));
                }
            }

        }

    }
}
