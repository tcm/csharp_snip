/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 27.04.2016
 * Time: 14:06
 * 
 */
 
using System;


namespace Class_Demo
{
	
	class Program
	{
		public static void Main(string[] args)
		{
			
			var o_Creature = new Ant(1,2,GenderType.Female);
			
			Console.WriteLine(o_Creature.GetSize());
			o_Creature.PrintCreatureType();
			o_Creature.GetOvarienSize();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}