using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{

    public class FieldElement
    {
        public string Name, DataType;
        public List<FieldElement> Elements = new List<FieldElement>();
        private const int IndentSize = 2;

        public FieldElement()
        {
            
        }

        public FieldElement(string name, string dataType)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.DataType = dataType ?? throw new ArgumentNullException(nameof(dataType));
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indent * IndentSize);

            if (!string.IsNullOrWhiteSpace(Name) && 
                !string.IsNullOrWhiteSpace(DataType))
            {
                if(indent == 0)
                {
                    sb.AppendLine($"{i}public {DataType} {Name}");
                    sb.AppendLine("{");
                }
                else
                {
                    sb.AppendLine($"{i}public {DataType} {Name};");
                }
            }

            foreach(var child in Elements)
            {
                sb.Append(child.ToStringImpl(indent + 1));
            }

            if(indent == 0)
            {
                sb.AppendLine("}");
            }

            return sb.ToString();

        }
    }


    public class CodeBuilder
    {
        FieldElement _Root = new FieldElement();
        private string _RootName;

        public CodeBuilder(string rootName)
        {
            _Root.Name = rootName ?? throw new ArgumentNullException(nameof(rootName));
            _Root.DataType = "class";
            _RootName = rootName;
        }

        public CodeBuilder AddField(string name, string dataType)
        {
            var element = new FieldElement(name, dataType);
            _Root.Elements.Add(element);
            return this;
        }
        public override string ToString()
        {
            return _Root.ToString();
        }


        public void Clear()
        {
            _Root = new FieldElement()
            {
                Name = _RootName,
                DataType = "class"
            };
        }
    }
}
