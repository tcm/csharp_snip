/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 23.03.2016
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestExceptionHandling2
{
	class Program
	{
		public static void Main(string[] args)
		{
			string[] names = { "Schrödinger", "Katze", "Freundin" };
			
			try
			{
				for ( int i = 0 ; i <= 3 ; i++ )
				{
					Console.WriteLine("Protagonist: {0}", names[i]);
				}
			}
			catch (IndexOutOfRangeException) {
				Console.WriteLine("So nicht - IndexOutOfRange");
			}
			catch (ArgumentException) {
				Console.WriteLine("So nicht - Argument passt nicht");
			}
			catch (Exception) {
				Console.WriteLine("So nicht - Allgemein");
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}