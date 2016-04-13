using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();

            //p.name = "blub";
            //p.name = "Schrödinger";
            try
            {
                 PrintPersonInfo(null);
                 //PrintPersonInfo(p);
            }
            catch ( MyPrivateArgumentNullException ex)
            {
                Console.WriteLine(ex.Zusatzinfos);
                throw ex;
            }
            


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        private static void PrintPersonInfo(Person p)
        {
            if (p == null)
                throw new MyPrivateArgumentNullException() { Zusatzinfos = "Das Objekt wurde nicht intialisiert." };
            if (p.name == null)
                throw new ArgumentException("The Name property is null.", "p");

            if (p.name.Contains("Schrödinger"))
                Console.WriteLine("Unser Held: {0}", p.name);
            else
                Console.WriteLine(p.name);
        }
    }
}
