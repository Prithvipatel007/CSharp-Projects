using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LiskovSubstitutionPrinciple
{
    public class Rectangle
    {
        public virtual int Width { get; set; } 
        public virtual int Height { get; set; }

        public Rectangle()
        {
            
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)} : {Width}; {nameof(Height)} : {Height}";
        }

    }

    public class Square : Rectangle
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get => base.Height;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
