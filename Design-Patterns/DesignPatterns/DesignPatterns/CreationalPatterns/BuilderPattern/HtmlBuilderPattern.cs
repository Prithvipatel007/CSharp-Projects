using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    // A convenient API for constructing for all HTML elements
    public class HtmlBuilder
    {
        HtmlElement _Root = new HtmlElement(); // The root element
        private string _RootName;

        public HtmlBuilder(string rootName)
        {
            _Root.Name = rootName ?? throw new ArgumentNullException(nameof(rootName));
            _RootName = rootName;
        }
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            _Root.Elements.Add(element); // Add the child element to the root element
            return this; // This is something called fluent interface where you can chain methods
        }

        public override string ToString()
        {
            return _Root.ToString(); // Return the string representation of the root element
        }

        public void Clear()
        {
            // Clear the root element and reinitialize it
            _Root = new HtmlElement()
            {
                Name = _RootName
            };
        }
    }

    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int IndentSize = 2;

        public HtmlElement()
        {
            
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indent * IndentSize);
            sb.AppendLine($"{i}<{Name}>");

            if(!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', (indent + 1) * IndentSize));
                sb.AppendLine(Text);
            }

            foreach(var child in Elements)
            {
                sb.Append(child.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

    }
}
