using DesignPatterns.CreationalPatterns.PrototypePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    // Typically, this would be a singleton
    public sealed class BuildingContext : IDisposable
    {
        public int WallHeight;
        private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            if(stack.Count > 1)
                stack.Pop();
        }
    }

    public class  Buildings
    {
        public List<Wall> Walls = new List<Wall>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Building:");
            foreach (var wall in Walls)
            {
                sb.AppendLine(wall.ToString());
            }
            return sb.ToString();
        }
    }

    public struct WallPoint
    {
        private int x, y;

        public WallPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }


    public class Wall
    {
        public WallPoint Start, End;
        public int Height;

        public Wall(WallPoint start, WallPoint end)
        {
            Start = start;
            End = end;
            Height = BuildingContext.Current.WallHeight;
        }

        public override string ToString()
        {
            return $"Wall from {Start} to {End} with height {Height}";
        }
    }

}
