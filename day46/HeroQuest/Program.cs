using System;

namespace HeroQuest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var MyHero = new Hero (HeroTyp.Gnom);
			MyHero.Attack = 2;
			MyHero.Defense = 2;
			MyHero.Intelligence = 10;
			MyHero.Hitpoint = 7;

			Console.WriteLine ("MyHero is: {0}", MyHero.getHeroTyp());
		}
	}
}
