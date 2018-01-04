using System;

public enum HeroTyp { Bararian,
	           Elf,
	           Gnom,
	           Magican }

namespace HeroQuest
{
	public class Hero
	{
		private HeroTyp typ;

		public Hero (HeroTyp inTyp)
		{
			typ = inTyp;
		}

		public int Intelligence { get ; set; }
		public int Hitpoint { get ; set; }
		public int Attack { get ; set; }
		public int Defense { get ; set; }

		public HeroTyp getHeroTyp()
		{
			return typ;
		}

	}
}

