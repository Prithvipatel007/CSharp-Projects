using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{
    public interface IDDDShape
    {
        string AsString();
    }

    public class DDDCircle : IDDDShape
    {
        private float radius;

        public DDDCircle(float radius)
        {
            this.radius = radius;
        }

        public string AsString() => $"A circle of radius {radius}";

        public void Resize(float factor)
        {
            this.radius *= factor;
        }
    }

    public class DDDSquare : IDDDShape
    {
        private float side;

        public DDDSquare(float side)
        {
            this.side = side;
        }

        public string AsString() => $"A square with side {side}";
    }

    public class ColoredShape : IDDDShape
    {
        private IDDDShape shape;
        private string color;

        public ColoredShape(IDDDShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has a color of {color}";
        }
    }

    public class TransparentShape : IDDDShape
    {
        private IDDDShape shape;
        private float opacity;

        public TransparentShape(IDDDShape shape, float op)
        {
            this.shape = shape;
            this.opacity = op;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has {opacity * 100} transparency";
        }
    }

}
