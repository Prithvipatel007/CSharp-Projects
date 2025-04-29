using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{
    public abstract class DDDShape
    {
        public abstract string AsString();
    }

    public class DDDCircle : DDDShape
    {
        private float radius;

        public DDDCircle(float radius)
        {
            this.radius = radius;
        }

        public override string AsString() => $"A circle of radius {radius}";

        public void Resize(float factor)
        {
            this.radius *= factor;
        }
    }

    public class DDDSquare : DDDShape
    {
        private float side;

        public DDDSquare(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }

    public abstract class ShapeDecorator : DDDShape
    {
        // Here, we will store the list of types we have decorated.
        protected internal readonly List<Type> types = new List<Type>();

        protected internal DDDShape shape;

        public ShapeDecorator(DDDShape shape)
        {
            this.shape = shape;
            if(shape is ShapeDecorator sd)
                types.AddRange(sd.types);

        }

        public override string AsString()
        {
            return shape.AsString();
        }
    }

    public abstract class ShapeDecorator<TSelf, TCyclePolicy> : ShapeDecorator
        where TCyclePolicy : ShapeDecoratorCyclePolicy, new()
    {
        protected readonly TCyclePolicy policy = new TCyclePolicy();

        protected ShapeDecorator(DDDShape shape) : base(shape)
        {
            if(policy.TypeAdditionAllowed(typeof(TSelf), types))
            {
                types.Add(typeof(TSelf));
            }
        }
    }

    // If we want to set default policy, then do something like this
    public class ShapeDecoratorWithPolicy<T> 
        : ShapeDecorator<T, ThrowOnCyclePolicy>
    {
        public ShapeDecoratorWithPolicy(DDDShape shape) : base(shape)
        {
            
        }
    }


    public class ColoredShape :
        ShapeDecorator<ColoredShape, AbsorbCyclePolicy>
    //ShapeDecoratorWithPolicy<ColoredShape>
    {
        private string color;

        public ColoredShape(DDDShape shape, string color) : base(shape)
        {
            this.color = color;
        }

        public override string AsString()
        {
            //return $"{shape.AsString()} has {color} color";
            var sb = new StringBuilder($"{shape.AsString()}");

            // At this point, types are already initialized
            // type[0] -> current class
            // types[1...] -> what it wraps
            if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList()))
                sb.Append($" has the color {color}");

            return sb.ToString();
        }
    }

    public class TransparentShape : DDDShape
    {
        private DDDShape shape;
        private float opacity;

        public TransparentShape(DDDShape shape, float op)
        {
            this.shape = shape;
            this.opacity = op;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has {opacity * 100} transparency";
        }
    }

    public abstract class ShapeDecoratorCyclePolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);
    }

    public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
    {
        private bool handler(Type type, IList<Type> allTypes)
        { 
            if (allTypes.Contains(type))
                throw new InvalidOperationException($"Cycle detected. Type is already a {type.FullName}");

            return true;
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }
    }

    public class CyclesAllowedPolicy : ShapeDecoratorCyclePolicy
    {
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }
    }

    public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
    {
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return !allTypes.Contains(type);
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }
    }



}
