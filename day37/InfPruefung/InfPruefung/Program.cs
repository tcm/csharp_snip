/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 13.07.2016
 * Time: 14:35
 * 
 */
using System;

namespace InfPruefung
{
	class Program
	{
		public static void Main(string[] args)
		{
				
			int[] feld = { 2, 5, 6, 10, 1, 3, 7, 9, 11, 4 };
			
			int w3 = func_w3(ref feld);
			Console.WriteLine("w3: {0}",w3);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
			public static int func_w1()
		{
			return 0;
		}
		
		public static int func_w2()
		{
			return 0;
		}
			
		public static int func_w3(ref int[] array)
			{
			int w3 = 0;
			int summand = 0;
			int faktor = 2;
			
			for (int i = 0 ; i < array.GetLength(0); i++ ) {
				
				// Console.Write("{0}. ",array[i]);
				
				summand = faktor * array[i];
				//Console.WriteLine("{0} * {1} = {2}", faktor, array[i], summand);
				
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