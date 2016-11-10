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
    public void Testfunc_w1()
    {
            int result = 0;
            int[] feld = { };
            var obj = new FunctionsClass();

            /* Test 1 */
            int[] feld1 = { 1, 2, -1, 4, 5, 6, 0, 10, 9, 0 };
            result = obj.func_w1(ref feld);
            Assert.AreEqual(-1, result);
         
            /* Test 2 */
            int[] feld2 = { -1, -2, -1, -4, -5, -6, 0, 1, 2, 5 };
            result = obj.func_w1(ref feld2);
            Assert.AreEqual(-6, result);

            /* Test 3 */
            //int[] feld3 = { -2, -2, -2 };
            //result = obj.func_w1(ref feld3);
            //Assert.AreEqual(-2, result);

            /* Test 4 */
            //int[] feld4 = { 0, 0, 0 };
            //result = obj.func_w1(ref feld4);
            //Assert.AreEqual(0, result);

        }

    }
}
