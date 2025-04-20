using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public class Point
    {
        public int X, Y;

        public Point DeepCopy()
        {
            var p = new Point();
            p.X   = this.X;
            p.Y = this.Y;
            return p;
        }

    }

public class Line
{
    public Point Start, End;

    public Line DeepCopy()
    {
        var start = Start.DeepCopy();
        var end = End.DeepCopy();


        var lineCopy = new Line();
        lineCopy.Start = start;
        lineCopy.End = end;

        return lineCopy;
    }
}
}
