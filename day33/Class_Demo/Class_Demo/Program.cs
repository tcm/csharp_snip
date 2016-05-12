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
			int errorCount = 0;
			string reply;
			
			
			var o_Creature = new Ant();
			
			if ( !o_Creature.SetSize(2.3) )
			{
				Console.WriteLine("SetSize failed");
				errorCount++;
			}
			if ( !o_Creature.SetSpeed(1.2) )
			{
				Console.WriteLine("SetSpeed failed");
				errorCount++;
			}
			if ( !o_Creature.SetGender(GenderType.Female) )
			{
				Console.WriteLine("SetGender failed");
				errorCount++;
			}
			if (errorCount > 0)
			{
				Console.WriteLine("Could not set all mamber variables!");
			}
		
			// Print Members;
			Console.WriteLine(o_Creature.GetSize() +" "+ o_Creature.GetSpeed() +" "+ o_Creature.GetGender());
			
			
			o_Creature.PrintCreatureType();
			
			Console.WriteLine(o_Creature.GetOvarienSize());
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}