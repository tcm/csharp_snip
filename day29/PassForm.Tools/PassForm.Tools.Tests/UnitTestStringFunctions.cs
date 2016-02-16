using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassForm.Tools.Validation;

namespace PassForm.Tools.Tests
{
    [TestClass]
    public class UnitTestStringFunctions
    {
        [TestMethod]
        public void Test_EmptyString_combineArrayStringWithSpace()
        {
            var stringOutput = new StringFunctions();
            string[] stringArray = null;
            string expected = string.Empty;
            string actual;

            actual = stringOutput.combineArrayStringWithSpace(stringArray);
            Assert.AreEqual(expected, actual);
            // Indicates that an assertion cannot be proven true or false. 
            // Also used to indicate an assertion that has not yet been implemented. 
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void Test_NormalString_combineArrayStringWithSpace()
        {

            string expectedResult = "Today is the wonderful day of my life";
            string[] actualStringArray = new string[] { "Today", "is", "the", "wonderful", "day", "of", "my", "life" };
            var stringOutput = new StringFunctions();

            string actualResult = stringOutput.combineArrayStringWithSpace(actualStringArray);
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_ClassStringFunctions()
        {
         var SampleClass = new StringFunctions(5, "China Mieville");
         var pobject = new PrivateObject(SampleClass);

            Assert.AreEqual<int?>(5, pobject.GetFieldOrProperty("_classid") as int?);
            Assert.AreEqual<string>("China Mieville", pobject.GetFieldOrProperty("_name") as string);
        }
    }
}
