using System;

namespace HeroQuest
{
	class MainClass
	{
		static Random _random = new Random();

		public static void Main (string[] args)
		{
			var MyHero = new Hero (HeroTyp.Gnom);
			MyHero.Attack = 2;
			MyHero.Defense = 2;
			MyHero.Intelligence = 10;
			MyHero.Hitpoint = 7;
			MyHero.Speed = 2;

			Console.WriteLine ("MyHero is: {0}", MyHero.getHeroTyp());

			Console.WriteLine ("{0}",Dice6 (2));
		}

		public static int Dice6(int round)
		{
			int sum = 0;
			for (int i = 0; i < round; i++) {
				
				// Random random = new Random ();
				int randomNumber = _random.Next (1, 7);
				sum += randomNumber;
			}
			return sum;
		}
	}
}
