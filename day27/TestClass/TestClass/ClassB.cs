/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 17.12.2015
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestClass
{
	/// <summary>
	/// Description of ClassB.
	/// </summary>
	public class ClassB : ClassA
	{
		public ClassB()
		{
		}
		
		public void TestMethod()
		{
		
			base.Name1 = "123";
			base.Name3 = "789";
			
			Console.WriteLine("Name1: " + base.Name1 + "   Name3: " + base.Name3);
		}
	}
}
