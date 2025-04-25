using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPatterns
{
    /*
     * Click into the class's empty area and Alt + Insert (einfg)
     * and select delegate members
     * 
     * Using find and replace
     * Find -> return builder.(.+)$
     * Replace -> builder.$1\nreturn this;
     */
    public class CodeBuilder
    {
        private StringBuilder builder = new StringBuilder();

        public override string ToString()
        {
            return builder.ToString();
        }


        public int EnsureCapacity(int capacity)
        {
            return builder.EnsureCapacity(capacity);
        }
        public string ToString(int startIndex, int length)
        {
            return builder.ToString(startIndex, length);
        }
        public CodeBuilder Clear()
        {
            builder.Clear();
            return this;
        }
        public CodeBuilder Append(char value, int repeatCount)
        {
            builder.Append(value, repeatCount);
            return this;
        }
        public CodeBuilder AppendLine()
        {
            builder.AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(string text)
        {
            builder.AppendLine(text);
            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            builder.CopyTo(sourceIndex, destination, destinationIndex, count);
        }
        public CodeBuilder Insert(int index, string value, int count)
        {
            builder.Insert(index, value, count);
            return this;
        }
        public CodeBuilder Remove(int startIndex, int length)
        {
            builder.Remove(startIndex, length);
            return this;
        }
        public CodeBuilder AppendFormat(string format, object arg0)
        {
            builder.AppendFormat(format, arg0);
            return this;
        }
        public CodeBuilder Replace(string oldValue, string newValue)
        {
            builder.Replace(oldValue, newValue);
            return this;
        }
        public bool Equals(StringBuilder sb)
        {
            return builder.Equals(sb);
        }

        public int Capacity
        {
            get => builder.Capacity;

            set => builder.Capacity = value;
        }

        public int MaxCapacity => builder.MaxCapacity;

        public int Length
        {
            get => builder.Length;

            set => builder.Length = value;
        }
    }

}
