using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassForm.Tools.Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCustomRegex regExp = new TestCustomRegex();

            Console.WriteLine(Environment.NewLine + "TestpatternTelefonNumber():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternTelefonNumber();

            Console.WriteLine(Environment.NewLine + "TestpatternEmailadress():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternEmailAddress();

            Console.WriteLine(Environment.NewLine + "TestpatternEuropeanVATNumber():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternEuropeanVATNumber();

            Console.WriteLine(Environment.NewLine + "TestpatternFourDigits():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternFourDigits();

            Console.WriteLine(Environment.NewLine + "TestpatternWord():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternWord();

            Console.WriteLine(Environment.NewLine + "TestpatternPatternDimensionOneValue():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternDimensionOneValue();

            Console.WriteLine(Environment.NewLine + "TestpatternPatternDimensionTwoValues():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternDimensionTwoValues();

            Console.WriteLine(Environment.NewLine + "TestpatternPatternZIPCodeNumerical():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternZIPCodeNumerical();

            Console.WriteLine(Environment.NewLine + "TestpatternPatternZIPCodeAlpha():");
            Console.WriteLine("-------------------------------------------------");
            regExp.TestpatternZIPCodeAlpha();




            Console.Write(Environment.NewLine + "Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
