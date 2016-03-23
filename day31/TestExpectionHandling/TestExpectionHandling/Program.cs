/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 23.03.2016
 * Time: 13:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestExpectionHandling
{
	class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				string text = System.IO.File.ReadAllText("c:\\myFile.txt");
				Console.WriteLine("Der Text in der Datei lautet:");
				Console.WriteLine(text);
			}
			catch (System.IO.FileNotFoundException) {
				Console.WriteLine("Die Datei gibt es ja gar nicht!");
			}
			catch (System.IO.DirectoryNotFoundException) {
				Console.WriteLine("Der Ordner zur Datei existiert gar nicht.");
			}
			catch (UnauthorizedAccessException) {
				Console.WriteLine("Der Zugriff auf die Datei wurde verweigert.");
			}
				
			
			catch (Exception e)
			{
				Console.WriteLine("Da gibt es ein Problem.");
				Console.WriteLine(e.Message);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}