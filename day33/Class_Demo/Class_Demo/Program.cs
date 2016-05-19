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
					
			var o_Creature = AntFactoryV1.Get(AntType.WorkerAnt);
			
			
			if ( !o_Creature.SetSize(5.2) )
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
				Console.WriteLine("Could not set all member variables!");
			}
		
			// Print Members;
			Console.WriteLine(o_Creature.GetSize() +" "+ o_Creature.GetSpeed() +" "+ o_Creature.GetGender());
			
			
			o_Creature.PrintCreatureType();
			
			// Console.WriteLine(o_Creature.GetOvarienSize());
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}