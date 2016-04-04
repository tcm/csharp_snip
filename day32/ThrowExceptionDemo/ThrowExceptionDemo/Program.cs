using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine().Trim();

            WriteHello(name);

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }

        static void WriteHello(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
                // throw new MyPersonalException { Zusatzinfos = "können ebenfalls gesetzt werden." };
            
            Console.WriteLine("Hello {0}", name);
        }
    }
}
