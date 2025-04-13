using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    #region Interfaces

    public interface ISpecifyCarType
    {
        ISpecifyWheelType OfCarType(CarType carType);
    }

    public interface  ISpecifyWheelType
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        Car Build();
    }

    #endregion


    public class CarBuilder 
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelType, IBuildCar
        {
            private Car car = new Car();

            public ISpecifyWheelType OfCarType(CarType carType)
            {
                car.Type = carType;
                return this;
            }
            public IBuildCar WithWheels(int size)
            {
                switch(car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Invalid size for Wheel type {car.Type}");
                }

                car.WheelSize = size;
                return this;

            }
            public Car Build()
            {
                return car;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }


}
