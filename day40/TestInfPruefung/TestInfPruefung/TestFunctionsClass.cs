using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInfPruefung
{
    using NUnit.Framework;

    [TestFixture]
    class TestFunctionsClass
    {

        [Test]
        public void Testfunc_w1_StandardField1()
        {
            int result = -1;
            var obj = new FunctionsClass();

            /* Test 1 */
            int[] feld = { 1, 2, -1, -2, 4, 5, 6, 0, 10, 9, 0 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void Testfunc_w1_StandardField2()
        {
            int result = -1;
            var obj = new FunctionsClass();

            /* Test 2 */
            int[] feld = { -1, -2, -1, -4, -5, -6, 0, 1, 2, 5 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-6, result);
        }

        [Test]
        public void Testfunc_w1_AllNegative()
        {
            int result = -1;
            var obj = new FunctionsClass();

            /* Test 3 */
            int[] feld = { -11, -11, -11 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-11, result);
        }
            
        [Test]
        public void Testfunc_w1_4_AllZero()
        {
            int result = -1;
            var obj = new FunctionsClass();

            /* Test 4 */
            int[] feld = { 0, 0, 0, 0 ,0, 0 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(0, result); 
        }


        [Test]
        public void Testfunc_w1_AllPositive()
        {
            int result = -1;
            var obj = new FunctionsClass();

            /* Test 4 */
            int[] feld = { 3, 3, 3 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(0, result);
        }


        [Test]
        public void Testfunc_w2_StandardField2()
        {
            double result = -1;
            var obj = new FunctionsClass();

            /* Test 5 */
            int[] feld = { 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 ,5 ,5 };
            result = obj.func_w2(ref feld);
            Assert.AreEqual(1.31, Math.Round(result,2));
        }

    }
}
