using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdaptorPatterns
{
    public class PixelPoint
    {
        public int X, Y;

        public PixelPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class PixelLine
    {
        public PixelPoint Start, End;

        public PixelLine(PixelPoint start, PixelPoint end)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
        }

        public override string ToString()
        {
            return $"[{Start.X}, {Start.Y}] - [{End.X}, {End.Y}]";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start != null ? Start.GetHashCode() * 397 : 0) ^ ( End != null ? End.GetHashCode() : 0);
            }
        }
    }

    public class VectorObject : Collection<PixelLine>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new PixelLine(new PixelPoint(x, y), new PixelPoint(x + width, y)));
            Add(new PixelLine(new PixelPoint(x + width, y), new PixelPoint(x + width, y + height)));
            Add(new PixelLine(new PixelPoint(x + width, y + height), new PixelPoint(x, y + height)));
            Add(new PixelLine(new PixelPoint(x, y + height), new PixelPoint(x, y)));
        }
    }


    // This is an adaptor which converts line to point
    public class LineToPointAdaptor : IEnumerable<PixelPoint>
    {
        private static int count;

        // Caching
        private static Dictionary<int, List<PixelPoint>> cache = new Dictionary<int, List<PixelPoint>>();

        public LineToPointAdaptor(PixelLine line)
        {
            var hash = line.GetHashCode();
            if(cache.ContainsKey(hash))
            {
                return;
            }

            Console.WriteLine($"{++count} : Generating points for line {line.ToString()}");

            var points = new List<PixelPoint>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = bottom - top;

            // We can only draw pixels
            if(dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new PixelPoint(left, y));
                }
            }
            else if(dy == 0)
            {
                for(int x = left; x <= right; ++x)
                {
                    points.Add(new PixelPoint(x, top));
                }
            }

            cache.Add(hash, points);

        }

        public IEnumerator<PixelPoint> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public static class VectorRasterDemo
    {

        /*
         * Given data
         */

        // Someone comes and ask to draw this vector objects and all can draw is a pixel

        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1, 1, 10, 10),
            new VectorRectangle(3, 3, 6, 6),
        };

        // We can only draw pixels
        public static void DrawPoint(PixelPoint p)
        {
            Console.Write(".");
        }
        public static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var l in vo)
                {
                    var adaptor = new LineToPointAdaptor(l);
                    adaptor.ForEach(DrawPoint);
                    Console.WriteLine();
                }
            }
        }
    }
}
