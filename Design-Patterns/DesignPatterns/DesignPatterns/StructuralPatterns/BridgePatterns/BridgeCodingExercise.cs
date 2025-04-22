using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePatterns
{
    public interface ICERenderer
    {
        string WhatToRenderAs { get; }
    }

    public class CEVectorRenderer : ICERenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class CERasterRenderer : ICERenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class CEShape
    {
        public string Name { get; set; }

        protected ICERenderer renderer;

        protected CEShape(ICERenderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer));

            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }

    }

    public class Triangle : CEShape
    {
        public Triangle(ICERenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : CEShape
    {
        public Square(ICERenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
}
