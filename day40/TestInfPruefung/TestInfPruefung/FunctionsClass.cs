using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInfPruefung
{
    class FunctionsClass
    {
        # region func_w1
        /* Kleinste negative Zahl */
        public int func_w1(ref int[] array)
        {
            int w1 = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i] < 0)
                {
                    if (array[i] < w1)
                    {
                        w1 = array[i];
                    }
                }
            }

            return w1;
        }
        # endregion

        # region func_w2
        /* Mittlere quadratische Abweichung */
        public double func_w2(ref int[] array)
        {
            double w2 = 0;
            double M = 0;       /* Arithmetisches Mittel */
            int N = 0;          /* Anzahl der Elemente   */
            double summe = 0;
            double summe2 = 0;

            N = array.GetLength(0);

            if (N == 1)
                return 0;

            /* M */
            for (int i = 0; i < N; i++)
            {
                summe = summe + array[i];
            }
            M = summe / N;

            /* w2 */
            for (int i = 0; i < N; i++)
            {
                summe2 = summe2 + Math.Pow((array[i] - M), 2);
            }

            /* Der Ausdruck in Klammer muß gecastet werden, da das Ergebnis sonst 0 wird. */
            /* Das Ergebis wird zu 0, weil ein Integer in der Rechnung vorkommt.          */
            w2 = ((double)1 / (N - 1)) * summe2;

            return w2;
        }
        #endregion

        # region func_w3
        /* Summenbildung */
        public int func_w3(ref int[] array)
        {
            int w3 = 0;
            int summand = 0;
            int faktor = 2;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                summand = faktor * array[i];
                w3 = w3 + summand;

                if (faktor == 6)
                {
                    faktor = 2;
                }
                else
                {
                    faktor = faktor + 2;
                }
            }

            return w3;
        }
        #endregion
    }
}
