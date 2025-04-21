using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.StructuralPatterns.AdaptorPatterns.Dimensions;

namespace DesignPatterns.StructuralPatterns.AdaptorPatterns
{
    // Vector2f, Vector3i

    public static class Dimensions
    {
        public interface IInteger
        {
            int Value { get; }
        }

        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }


    public class Vector< TSelf, T, D>   where D : IInteger, new()
                                        where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] data;

        public Vector()
        {
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                data[i] = values[i];

        }

        // This acts as a iterator on the data array. Lets user access each element of data.
        // This is an indexer using which people can access the data
        public T this [int idx]
        {
            get => data[idx];
            set => data[idx] = value;
        }

        public T X
        {
            get => data[0];
            set => data[0] = value;
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();

            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                result.data[i] = values[i];

            return result;
        }

    }

    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D> where D : IInteger, new()
    {
        public VectorOfInt()
        {

        }

        public VectorOfInt(params int[] values) : base(values)
        {

        }

        public static VectorOfInt<D> operator + (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var res = new VectorOfInt<D>();

            var dim = new D().Value;

            for(int i = 0; i < dim; i++)
            {
                res[i] = lhs[i] + rhs[i];
            }

            return res;
        }
    }

    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D>
                    where D : IInteger, new()
                    where TSelf : Vector<TSelf, float, D>, new()
    {
        public VectorOfFloat()
        {
        }

        public VectorOfFloat(params float[] values) : base(values)
        {

        }
    }



    public class Vector3f : VectorOfFloat<Vector3f, Dimensions.Three>
    {
        public Vector3f()
        {
            
        }

        public Vector3f(params float[] values) : base(values)
        {
        }

        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i()
        {
            
        }

        public Vector2i(params int[] values) : base(values)
        {

        }
    }
}
