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
        public void Testfunc_w1_1()
        {
            int result = 0;
            var obj = new FunctionsClass();

            /* Test 1 */
            int[] feld = { 1, 2, -1, -2, 4, 5, 6, 0, 10, 9, 0 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void Testfunc_w1_2()
        {
            int result = 0;
            var obj = new FunctionsClass();

            /* Test 2 */
            int[] feld = { -1, -2, -1, -4, -5, -6, 0, 1, 2, 5 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-6, result);
        }

        [Test]
        public void Testfunc_w1_3()
        {
            int result = 0;
            var obj = new FunctionsClass();

            /* Test 3 */
            int[] feld = { -11, -11, -11 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-11, result);
        }
            
        [Test]
        public void Testfunc_w1_4()
        {
            int result = 0;
            var obj = new FunctionsClass();

            /* Test 4 */
            int[] feld = { 0, 0, 0, 0 ,0, 0 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-1, result); 
        }


        [Test]
        public void Testfunc_w1_5()
        {
            int result = 0;
            var obj = new FunctionsClass();

            /* Test 4 */
            int[] feld = { 3, 3, 3 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-1, result);
        }

    }
}
