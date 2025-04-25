using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.CompositePatterns
{

    public class GraphicObject
    {
        // here we use root class to act as a group for any kind of memeber, which is part of that group
        // so we can drag them together. 
        public virtual string Name { get; set; } = "Group";     
        public string Color;        // Color is configurable from the client

        // Since this graphic object, since its group of things, can have an optional set of children

        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();  // Lazy because if we dont need it, we dont initialize it.

        public List<GraphicObject> Children => children.Value;

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);   // default level is top level so it is 0
            return sb.ToString();
        }

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color}")
              .AppendLine(Name);

            foreach(var child in Children)
            {
                child.Print(sb, depth+1);
            }

        }


    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

}
