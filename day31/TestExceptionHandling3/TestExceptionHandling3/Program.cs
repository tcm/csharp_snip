/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 23.03.2016
 * Time: 14:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestExceptionHandling3
{
	class Program
	{
		public static void Main(string[] args)
		{
				string[] names = { "Schrödinger", "Katze", "Freundin" };
			
			try
			{	
				int lastIndex = 0;
				for ( int i = 0 ; i <= 4 ; i++ )
				{
					lastIndex = i;
					
					try
					{
						Console.WriteLine("Protagonist: {0}", names[i]);
					}
					catch (IndexOutOfRangeException) {
						Console.WriteLine("Hoppala, etwas zu weit gelaufen");
							Console.WriteLine("Index: {0}", lastIndex);
						Console.WriteLine("Last info: {0}", names[lastIndex]);
					}
						
				}
			}
			catch (IndexOutOfRangeException) {
				Console.WriteLine("So nicht - IndexOutOfRange");
			}
			catch (Exception) {
				Console.WriteLine("So nicht - Allgemein");
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}