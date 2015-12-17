/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 17.12.2015
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestClass
{
	class Program
	{
		public static void Main(string[] args)
		{
		
			
			ClassA aa = new ClassA();
			aa.Name1 = "123";
			
			ClassB bb = new ClassB();
			bb.Name1 = "456";
			
			
			bb.TestMethod();
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}