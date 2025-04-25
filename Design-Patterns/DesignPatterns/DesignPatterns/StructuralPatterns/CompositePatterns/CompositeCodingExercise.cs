using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.CompositePatterns
{

    public interface IValueContainer : IEnumerable<int>
    {
      
    }

    public class SingleValue : IValueContainer
    {
          public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

}
