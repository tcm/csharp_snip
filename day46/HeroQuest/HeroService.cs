using System;

namespace HeroQuest
{
	public static class HeroService
	{
		

		public static Hero CreateBabarian(string inName)
		{
			var NewChar = new Hero (HeroTyp.Bararian, inName);
			NewChar.Attack = 2;
			NewChar.Defense = 2;
			NewChar.Intelligence = 10;
			NewChar.Hitpoint = 7;
			NewChar.Speed = 2;

			return NewChar;
		}

		public static Hero CreateMonster(string inName)
		{
			var NewChar = new Hero (HeroTyp.Monster, inName);
			NewChar.Attack = 2;
			NewChar.Defense = 2;
			NewChar.Hitpoint = 1;
			NewChar.Speed = 2;
			NewChar.Intelligence = 10;

			return NewChar;
		}
	}
}

