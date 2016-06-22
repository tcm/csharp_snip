/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 22.06.2016
 * Time: 12:46
 * 
 */
using System;
using System.Collections.Generic;

namespace DictionaryDemo
{
	class Program
	{
		public static void Main(string[] args)
		{
			/* ---------------------------------*/
			/* Beispiel 1                       */
			/* Einfach: Wir speichern einen     */
			/* Integer und einen String.
			/* -------------------------------- */
			var _dict1 = new Dictionary<int,string>();
			_dict1.Add(1,"blub1");
			_dict1.Add(4,"blub4");
			_dict1.Add(5,"blub5");
			
			// Nur suchen
			if (_dict1.ContainsKey(4))
			{
				Console.WriteLine("4 habe ich gefunden!");
			}
			
			// Suchen und Wert zurückgeben. 
			string outString = "";
			_dict1.TryGetValue(5, out outString);
			Console.WriteLine("5: " + outString);
			
			// Alle Werte zurückgeben.
			foreach (KeyValuePair<int,string> pair in _dict1)
			{
				Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
			}
		
			/* -------------------------------------------*/
			/* Beispiel 2                                 */
			/* Fortgeschritten: Wir speichern ein Klassen-*/
			/* objekt. Wenn ich das richtig               */
			/* verstanden habe.                           */
			/* -------------------------------------------*/
			// var _dict2 = new Dictionary<int,ITestType>();      // So geht's eben nicht!
			var _dict2 = new Dictionary<int, Func<ITestType>>();
			_dict2.Add(10, () => new TestClass());
			_dict2.Add(11, () => new TestClass2());
			
			Func<ITestType> func;
	
			// Eine Klasse zurückliefern.
			if ( _dict2.TryGetValue(10, out func))
			{
				Console.WriteLine(func());
			}
			else
			{
				throw new NotImplementedException();
			}
			
			// Alle Klassen zurückgeben.
			foreach (KeyValuePair<int,Func<ITestType>> pair in _dict2)
			{
				Console.WriteLine("{0}, {1}", pair.Key, pair.Value()); // Die Klammer hinter Value() ist wichtig!
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}