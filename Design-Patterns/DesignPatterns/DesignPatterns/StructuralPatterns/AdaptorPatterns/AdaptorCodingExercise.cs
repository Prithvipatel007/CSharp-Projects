using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdaptorPatterns
{
    public class Square
    {
        public int Side;

        public Square()
        {
            
        }

        public Square(int side)
        {
            Side = side;
        }

    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square _Square;

        public SquareToRectangleAdapter(Square square)
        {
            _Square = square ?? throw new ArgumentNullException(nameof(square));
        }

        public int Width => _Square.Side;

        public int Height => _Square.Side;
    }
}
