using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace PassForm.Tools.Validation
{
    // TODO: Muß noch als TestUnit umgeschrieben werden.

    public class TestCustomRegex
    {
        public TestCustomRegex()
        {
        }

        public void TestpatternTelefonNumber()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("09270-98551");
            TestStringList.Add("+4909270-98551");
            TestStringList.Add("09270-(98551)");
            TestStringList.Add("(09270)98551");
            TestStringList.Add("+49(09270)98551");
            TestStringList.Add("+49 9270 98551");
            TestStringList.Add("049-9270-98551");
            TestStringList.Add("-51");

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternTelefonNumber, TestString));
            }
        }


        public void TestpatternEmailAddress()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("herr.heinzelmann@zwergenhausen.org");
            TestStringList.Add("dieter.buergy@calgon.co.uk");
            TestStringList.Add("heinzstrunk@info-mailcom");


            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternEmailAddress, TestString));
            }
        }

        public void TestpatternEuropeanVATNumber()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("ATU12345678"); 			// Austria
            TestStringList.Add("U99999999");
            TestStringList.Add("BE0999999999");			// Belgium
            TestStringList.Add("BG999999999");			// Bulgaria
            TestStringList.Add("99999999L");			// Cyprus
            TestStringList.Add("CY99999999L");
            TestStringList.Add("CZ99999999");	        // Czech Republic
            TestStringList.Add("CZ999999999");
            TestStringList.Add("CZ9999999999");
            TestStringList.Add("DE999999999");			// Germany
            TestStringList.Add("DK999999999");			// Denmark
            TestStringList.Add("EE999999999");			// Estonia
            TestStringList.Add("GR999999999");			// Greece
            TestStringList.Add("EL999999999");
            TestStringList.Add("X9999999X");	        // Spain			
            TestStringList.Add("FI99999999");           // Finland		
            TestStringList.Add("FR999999999");  		// France
            TestStringList.Add("XX999999999");
            TestStringList.Add("GB999999999"); 			// United Kingdom
            TestStringList.Add("GB999999999999");
            TestStringList.Add("GB999");
            TestStringList.Add("XX999");
            TestStringList.Add("HU99999999");           // Hungary
            TestStringList.Add("9S99999L");  			// Ireland
            TestStringList.Add("IE9S99999L");
            TestStringList.Add("IT99999999999");		// Italy
            TestStringList.Add("LT999999999");			// Lithuania	
            TestStringList.Add("LU99999999");			// Luxembourg
            TestStringList.Add("MT99999999");			// Malta
            TestStringList.Add("NL999999999B99");		// Netherlands
            TestStringList.Add("PL999999999");			// Poland
            TestStringList.Add("PT999999999");			// Portugal
            TestStringList.Add("RO99");					// Romania
            TestStringList.Add("RO9999999999");
            TestStringList.Add("SE999999999999");		// Sweden
            TestStringList.Add("SI99999999");			// Slovenia
            TestStringList.Add("SK999999999");	        // Slovakia



            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternEuropeanVATNumber, TestString));
            }
        }

        public void TestpatternFourDigits()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("1234");

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternFourDigits, TestString));
            }
        }

        public void TestpatternWord()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZÜÖÄß");
            TestStringList.Add("abcdefghijklmnopqrstuvwxyzüöÄß");
          
            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternWord, TestString));
            }
        }

        public void TestpatternDimensionOneValue()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("4,5");

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternDimensionOneValue, TestString));
            }
        }

        public void TestpatternDimensionTwoValues()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("4,5 x 3,2");

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternDimensionTwoValues, TestString));
            }
        }

        public void TestpatternZIPCodeNumerical()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("1234");
            TestStringList.Add("12345");
            TestStringList.Add("123456");
            TestStringList.Add("1234567");

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternZIPCodeNumerical, TestString));
            }
        }

        public void TestpatternZIPCodeAlpha()
        {
            var StringIn = new CustomRegex();
            var TestStringList = new ArrayList();
            string TestString;

            TestStringList.Add("CODUB");
         

            int position = 0;
            for (position = 0; position < TestStringList.Count; position++)
            {
                TestString = (string)TestStringList[position];
                Console.WriteLine(TestString + " " + StringIn.Is_Regex(RegexPattern.PatternZIPCodeAlpha, TestString));
            }
        } 
    }
}
