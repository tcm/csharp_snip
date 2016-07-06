/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 06.07.2016
 * Time: 12:45
 * 
 * Test ob ein einfaches Array auch schon ein Objekt ist.
 * Wenn ja, dann muß foreach auch gehen!
 */
using System;
using System.Collections; // wegen ArrayList!
using System.Collections.Generic; // wegen List!

namespace ArrayDemo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Fill_Array();
			Console.Write("\n");
			
			Fill_ArrayList();
			Console.Write("\n");
			
			Fill_List();
			Console.Write("\n");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void Fill_Array()
		{
			Console.WriteLine("Array:");
			
			const int ARRAY_SIZE = 10;
			
			// -----------------------
			// Einfaches Array
			// -----------------------
			int [] arr1 = new int[ARRAY_SIZE];
			
			arr1[0] = 5;
			arr1[1] = 10;
			arr1[2] = 15;
			
			// 1. Ausgabe über for-Schleife
			int i = 0;
			Console.Write("for: ");
			for ( i = 0 ; i < arr1.GetLength(0) ; i++ )
			{
				Console.Write("{0} ", arr1[i]);                 
			}
			Console.Write("\n");
			
			// 2. Ausgabe über foreach
			Console.Write("foreach: ");
			foreach (var element in arr1) {
				Console.Write("{0} ", element);
			}
			Console.Write("\n");
		}
		
		public static void Fill_ArrayList()
		{
			Console.WriteLine("ArrayList:");
			// -----------------------
			// ArrayList
			// (jeder Grundtyp erlaubt)
			// -----------------------
			var arr2 = new ArrayList();
			arr2.Add(24);
			arr2.Add(12);
			arr2.Add("blub");
			arr2.Add(8);
			
			// 1. Ausgabe über for-Schleife
			int i = 0;
			Console.Write("for: ");
			for (i = 0; i < arr2.Count; i++ )
			{
				Console.Write("{0} ",arr2[i]);
			}
			Console.Write("\n");
			
			// 2. Ausgabe über foreach
			Console.Write("foreach: ");
			foreach (var element in arr2) {
				Console.Write("{0} ", element);
			}
			Console.Write("\n");
		}
		
		
		public static void Fill_List()
		{
			Console.WriteLine("List:");
			// ----------------------------	
			// List
			// Typ wird vorher festgelegt.
			// ----------------------------
			var arr3 = new List<int>();
			arr3.Add(9);
			arr3.Add(18);
			arr3.Add(27);
			
			// 1. Ausgabe über for-Schleife
			int i = 0;
			Console.Write("for: ");
			for (i = 0; i < arr3.Count; i++ )
			{
				Console.Write("{0} ",arr3[i]);
			}
			Console.Write("\n");
			
			// 2. Ausgabe über foreach
			Console.Write("foreach: ");
			foreach (var element in arr3) {
				Console.Write("{0} ", element);
			}
			Console.Write("\n");
		}
	}
}