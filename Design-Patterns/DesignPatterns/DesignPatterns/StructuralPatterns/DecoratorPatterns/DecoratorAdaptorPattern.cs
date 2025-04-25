using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{

    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        #region MyStringBuilder delegating members

        public int EnsureCapacity(int capacity)
        {
            return sb.EnsureCapacity(capacity);
        }
        public string ToString(int startIndex, int length)
        {
            return sb.ToString(startIndex, length);
        }
        public MyStringBuilder Clear()
        {
            sb.Clear();
            return this;
        }
        public MyStringBuilder Append(char value, int repeatCount)
        {
            sb.Append(value, repeatCount);
            return this;
        }

        public MyStringBuilder Append(string value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder AppendLine()
        {
            sb.AppendLine();
            return this;
        }
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            sb.CopyTo(sourceIndex, destination, destinationIndex, count);
        }
        public MyStringBuilder Insert(int index, string value, int count)
        {
            sb.Insert(index, value, count);
            return this;
        }
        public MyStringBuilder Remove(int startIndex, int length)
        {
            sb.Remove(startIndex, length);
            return this;
        }
        public MyStringBuilder AppendFormat(string format, object arg0)
        {
            sb.AppendFormat(format, arg0);
            return this;
        }
        public MyStringBuilder Replace(string oldValue, string newValue)
        {
            sb.Replace(oldValue, newValue);
            return this;
        }
        public bool Equals(StringBuilder sb)
        {
            return sb.Equals(sb);
        }

        public int Capacity
        {
            get => sb.Capacity;

            set => sb.Capacity = value;
        }

        public int MaxCapacity => sb.MaxCapacity;

        public int Length
        {
            get => sb.Length;

            set => sb.Length = value;
        }

        #endregion

        // Adding appropriate members

        // Implicit operator
        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.Append(s);
            return msb;
        }

        // msb += "something"
        public static MyStringBuilder operator + (MyStringBuilder msb, string s)
        {
            msb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }


    }
}
