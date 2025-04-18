using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.InterfaceSegregationPrinciple
{
    public static class ISP_Main
    {
        public static void InterfaceSegregationPrinciple()
        {
            var printer = new Printer();
            var scanner = new Scanner();
            var fax = new FaxMachine();

            printer.Print(new Document("Printer", "Printer Content"));
            scanner.Scan(new Document("Scanner", "Scanner Content"));
            fax.Fax(new Document("Fax", "Fax Content"));

            var multiPrinter = new MultiPrinter(printer, scanner, fax);
            multiPrinter.Print(new Document("MultiPrinter", "Printing Content"));
            multiPrinter.Scan(new Document("MultiPrinter", "Scannning Content"));
            multiPrinter.Fax(new Document("MultiPrinter", "Faxing Content"));
        }
    }
}
