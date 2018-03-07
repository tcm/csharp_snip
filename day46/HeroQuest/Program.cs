using System;

namespace HeroQuest
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{

			Hero MyChar = HeroService.CreateBabarian ("Thor");
			Hero MyChar2 = HeroService.CreateMonster ("Orc");
					
			// Welchen Typ hat unser Charakter?
			Console.WriteLine ("MyChar is: {0}", MyChar.getHeroTyp());
			MyChar.printAttributes ();
			Console.WriteLine ("");

			// Welchen Typ hat unser Charakter?
			Console.WriteLine ("MyChar is: {0}", MyChar2.getHeroTyp());
			MyChar2.printAttributes ();


			// Würfelwerte ausgeben
			Console.WriteLine ("{0}",Dice.Dice6 (2)); // Normaler Würfel
			int[] array1 = Dice.DiceSpecial (4);
			foreach(var item in array1) // Kampfwürfel
			{
				Console.Write(item.ToString()+" ");
			} 
		}


	}
}
