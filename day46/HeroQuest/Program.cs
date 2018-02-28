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
			/* Console.WriteLine ("{0}",Dice6 (2)); // Normaler Würfel
			int[] array1 = DiceSpecial (4);
			foreach(var item in array1) // Kampfwürfel
			{
				Console.Write(item.ToString()+" ");
			} */
		}

		// Normaler Würfel
		public static int Dice6(int round)
		{
			int sum = 0;
			for (int i = 0; i < round; i++) {
				int randomNumber = _random.Next (1, 7);
				sum += randomNumber;
			}
			return sum;
		}

		// Die Kampf-Würfel
		public static int[] DiceSpecial(int round)
		{
			int[] DiceArray = new int[] { 0, 0, 0 };
			for (int i = 0; i < round; i++) {

				int randomNumber = _random.Next (1, 7);

				switch (randomNumber)
				{
				case 1: // Schwarzer Schild
					DiceArray[0] += 1;
					break;

				case 2: // Totenkopf
				case 3:
				case 4:
					DiceArray[1] += 1;
					break;

				case 5: // Normaler Schild
				case 6:
					DiceArray[2] += 1;
					break;
				}
			}
			return DiceArray;
		}
	}
}
