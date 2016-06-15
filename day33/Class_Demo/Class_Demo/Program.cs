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
		/*	Create_AntV1(AntType.WorkerAnt, 1.1, 1.5, GenderType.Female);
			Console.WriteLine("");
			Create_AntV1(AntType.QueenAnt, 3.1, 1.3, GenderType.Female);
			Console.WriteLine("");
			Create_AntV1(AntType.MaleAnt, 1.3, 1.6, GenderType.Male);
		*/	
			Create_AntV3(AntType.WorkerAnt, 1.1, 1.5, GenderType.Female);
			Console.WriteLine("");
			Create_AntV3(AntType.QueenAnt, 3.1, 1.3, GenderType.Female);
			Console.WriteLine("");
			Create_AntV3(AntType.MaleAnt, 1.3, 1.6, GenderType.Male);
				
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void Create_AntV1(AntType inAntType, double inSize, double inSpeed, GenderType inGenType)
		{
			int errorCount = 0;
					
			var o_Creature = AntFactoryV1.Get(inAntType);
			
			
			if ( !o_Creature.SetSize(inSize) )
			{
				Console.WriteLine("SetSize failed");
				errorCount++;
			}
			if ( !o_Creature.SetSpeed(inSpeed) )
			{
				Console.WriteLine("SetSpeed failed");
				errorCount++;
			}
			if ( !o_Creature.SetGender(inGenType) )
			{
				Console.WriteLine("SetGender failed");
				errorCount++;
			}
			if (errorCount > 0)
			{
				Console.WriteLine("Could not set all member variables!");
			}
			
			o_Creature.PrintCreatureType();
			Console.WriteLine("---------------------------");
			// Print Members;
			Console.WriteLine("Size: " + o_Creature.GetSize() +" Speed: "+ o_Creature.GetSpeed() +" Gender: "+ o_Creature.GetGender());
			// Ovarien haben nur die Ameisen!
			Console.WriteLine("OvarienSize: " +o_Creature.GetOvarienSize());	
		}
		
		public static void Create_AntV3(AntType inAntType, double inSize, double inSpeed, GenderType inGenType)
		{
			int errorCount = 0;
					
			var o_Creature = new AntFactoryV3().Get(inAntType);

			if ( !o_Creature.SetSize(inSize) )
			{
				Console.WriteLine("SetSize failed");
				errorCount++;
			}
			if ( !o_Creature.SetSpeed(inSpeed) )
			{
				Console.WriteLine("SetSpeed failed");
				errorCount++;
			}
			if ( !o_Creature.SetGender(inGenType) )
			{
				Console.WriteLine("SetGender failed");
				errorCount++;
			}
			if (errorCount > 0)
			{
				Console.WriteLine("Could not set all member variables!");
			}
			
			o_Creature.PrintCreatureType();
			Console.WriteLine("---------------------------");
			// Print Members;
			Console.WriteLine("Size: " + o_Creature.GetSize() +" Speed: "+ o_Creature.GetSpeed() +" Gender: "+ o_Creature.GetGender());
			// Ovarien haben nur die Ameisen!
			Console.WriteLine("OvarienSize: " +o_Creature.GetOvarienSize());	
		}
		
		
	}
}