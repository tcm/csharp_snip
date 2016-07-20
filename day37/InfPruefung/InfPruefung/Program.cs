/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 13.07.2016
 * Time: 14:35
 * Informatik Sommersemester 97
 */
using System;

namespace InfPruefung
{
	class Program
	{
		public static void Main(string[] args)
		{
				
			int[] feld = { -2, 2, 5, 6, 10, 1, 3, -3, 7, 9, 11, 4, -1, 1 };
			
			int w1 = func_w1(ref feld);
			double w2 = func_w2(ref feld);
			int w3 = func_w3(ref feld);
			
			Console.WriteLine("w1: {0}",w1);
			Console.WriteLine("w2: {0}",w2);
			Console.WriteLine("w3: {0}",w3);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		/* Kleinste negative Zahl */
		public static int func_w1(ref int[] array)
		{
			int w1 = -1;
			
			for (int i = 0 ; i < array.GetLength(0); i++ )
			{
				if ( array[i] < 0 )
				{
					if ( array[i] < w1)
					{
						w1 = array[i];
					}
				}
			}
			
			return w1;
		}
		
		/* Mittlere quadratische Abweichung */
		public static double func_w2(ref int[] array)
		{
			double w2 = 0;
			double M = 0; /* Arithmetisches Mittel */
			int N = 0;    /* Anzahl der Elemente */
			double summe = 0;
			double summe2 = 0;
			
			N = array.GetLength(0);
			
			if ( N == 1)
				return 0;
			
			/* M */
			for (int i = 0; i < N; i++ )
			{
				summe = summe + array[i];
			}
			M = summe / N;
			
			/* w2 */
			for (int i = 0 ; i < N ; i ++)
			{
				summe2 = summe2 + Math.Pow(( array[i] - M ),2);
			}
			
			w2 = ((double)1/(N-1)) * summe2; /* Der Ausdruck in Klammer muß gecastet werden, da das Ergebnis sonst 0 wird. */
											 /* Das Ergebis wird zu 0, weil ein Integer in der Rechnung vorkommt.          */
			 					
			return w2;
			
		}
			
		/* Summenbildung */
		public static int func_w3(ref int[] array)
		{
			int w3 = 0;
			int summand = 0;
			int faktor = 2;
			
			for (int i = 0 ; i < array.GetLength(0); i++ ) 
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
	}
}