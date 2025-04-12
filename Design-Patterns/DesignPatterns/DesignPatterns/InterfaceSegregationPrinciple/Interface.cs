using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.InterfaceSegregationPrinciple
{

    public class Document
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public Document(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public override string ToString()
        {
            return $"Document Name: {Name}, Content: {Content}";
        }
    }

    #region Interfaces
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IMultiFunctionMachine : IPrinter, IScanner, IFax
    {

    }

    #endregion

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine(d.ToString());
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {
            Console.WriteLine(d.ToString());
        }
    }

    public class FaxMachine : IFax
    {
        public void Fax(Document d)
        {
            Console.WriteLine(d.ToString());
        }
    }

    public class MultiPrinter : IMultiFunctionMachine
    {
        private IPrinter _Printer;
        private IScanner _Scanner;
        private IFax _Fax;

        public MultiPrinter(IPrinter printer, IScanner scanner, IFax fax)
        {
            if(printer == null)
                throw new ArgumentNullException(nameof(printer));

            if (scanner == null)
                throw new ArgumentNullException(nameof(scanner));

            if (fax == null)
                throw new ArgumentNullException(nameof(fax));

            _Printer = printer;
            _Scanner = scanner;
            _Fax = fax;
        }

        // Delegete the calls when the smaller interfaces are already implemented somewhere
        // This is actually Decorator pattern
        public void Fax(Document d) => _Fax.Fax(d);

        public void Print(Document d) => _Printer.Print(d);

        public void Scan(Document d) => _Scanner.Scan(d);
    }

    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            Console.WriteLine(d.ToString());
        }
        public void Scan(Document d)
        {
            Console.WriteLine(d.ToString());
        }
    }
}
