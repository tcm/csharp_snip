using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections; 



namespace PassForm.Tools.Tests
{
    [TestClass]
    public class UnitTestCustomRegex
    {
        [TestMethod]
        public void TestMethodPatternEmailAddress()
        {
            var regExp = new PassForm.Tools.Validation.CustomRegex();
            var TestStringListTrue = new ArrayList();
            var TestStringListFalse = new ArrayList();
            int position;

            /* ------------------------------------------  */
            /* Ergebnis: True                              */
            /* ------------------------------------------- */
            TestStringListTrue.Add("herr.heinzelmann@zwergenhausen.org");
            TestStringListTrue.Add("dieter.buergy@calgon.co.uk");

            position = 0;
            for (position = 0; position < TestStringListTrue.Count; position++)
            {
                string actualString = (string)TestStringListTrue[position];
                bool actualResult = regExp.Is_Regex(RegexPattern.PatternEmailAddress, actualString);
                Assert.IsTrue(actualResult);
            }

            /* ------------------------------------------  */
            /* Ergebnis: False                             */
            /* ------------------------------------------- */
            TestStringListFalse.Add("heinzstrunk@info-mailcom");

            position = 0;
            for (position = 0; position < TestStringListFalse.Count; position++)
            {
                string actualString = (string)TestStringListFalse[position];
                bool actualResult = regExp.Is_Regex(RegexPattern.PatternEmailAddress, actualString);
                Assert.IsFalse(actualResult);
            }
        }

        [TestMethod]
        public void TestMethodPatternTelefonNumber()
        {
            var regExp = new PassForm.Tools.Validation.CustomRegex();
            var TestStringListTrue= new ArrayList();
            var TestStringListFalse = new ArrayList();
            int position;

            /* ------------------------------------------  */
            /* Ergebnis: True                              */
            /* ------------------------------------------- */
            TestStringListTrue.Add("(09270)98551");
            TestStringListTrue.Add("09270-98551");
            TestStringListTrue.Add("+49(09270)98551");
            TestStringListTrue.Add("+49 9270 98551");
            TestStringListTrue.Add("049-9270-98551");

            position = 0;
            for (position = 0; position < TestStringListTrue.Count; position++)
            {
                string actualString = (string)TestStringListTrue[position];
                bool actualResult = regExp.Is_Regex(RegexPattern.PatternTelefonNumber, actualString);
                Assert.IsTrue(actualResult);
            }

            /* ------------------------------------------  */
            /* Ergebnis: False                             */
            /* ------------------------------------------- */
            TestStringListFalse.Add("+4909270-98551");
            TestStringListFalse.Add("09270-(98551)");
            TestStringListFalse.Add("-51");

            position = 0;
            for (position = 0; position < TestStringListFalse.Count; position++)
            {
                string actualString = (string)TestStringListFalse[position];
                bool actualResult = regExp.Is_Regex(RegexPattern.PatternTelefonNumber, actualString);
                Assert.IsFalse(actualResult);
            }
        }

       
    }
}
