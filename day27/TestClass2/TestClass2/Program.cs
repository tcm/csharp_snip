/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 17.12.2015
 * Time: 12:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestClass2
{
	class Program
	{
		public static void Main(string[] args)
		{
		
			
			ClassA aa = new ClassA();
			aa.CurrentPrice = 123;
			Console.WriteLine(aa.CurrentPrice);
			
			
			ClassB bb = new ClassB();
			bb.CurrentPrice = 456;
			Console.WriteLine(bb.CurrentPrice);
				
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}