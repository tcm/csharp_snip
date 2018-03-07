using System;

namespace HeroQuest
{
	class MainClass
	{
		static Random _random = new Random();

		public static void Main (string[] args)
		{
			// Charakter anlegen (Held).
			var MyChar = new Hero (HeroTyp.Gnom, "Borin");
			MyChar.Attack = 2;
			MyChar.Defense = 2;
			MyChar.Intelligence = 10;
			MyChar.Hitpoint = 7;
			MyChar.Speed = 2;

			// Charakter anlegen (Monster).
			var MyChar2 = new Hero (HeroTyp.Monster, "Orc");
			MyChar2.Attack = 2;
			MyChar2.Defense = 2;
			MyChar2.Hitpoint = 1;
			MyChar2.Speed = 2;
			MyChar2.Intelligence = 10;


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
