using System;

public enum HeroTyp { 
	           Bararian,
	           Elf,
	           Gnom,
	           Magican,
               Monster }

namespace HeroQuest
{
	public class Hero
	{
		private HeroTyp typ;

		public Hero (HeroTyp inTyp)
		{
			typ = inTyp;
		}

		public string Name { get ; set; }
		public string Description { get ; set; }
		public int Intelligence { get ; set; }
		public int Hitpoint { get ; set; }
		public int Attack { get ; set; }
		public int AttackBonus { get ; set; }
		public int Defense { get ; set; }
		public int DefenseBonus { get ; set; }
		public int Speed { get ; set; }

		public HeroTyp getHeroTyp()
		{
			return typ;
		}

		public void printAttributes()
		{
			Console.WriteLine("Name: {0}",this.Name);
			Console.WriteLine("Description: {0}",this.Description);
			Console.WriteLine("Intelligence: {0}",this.Intelligence);
			Console.WriteLine("Hitpoint: {0}", this.Hitpoint);
			Console.WriteLine("Attack: {0}",this.Attack);
			Console.WriteLine("AttackBonus: {0}",this.AttackBonus);
			Console.WriteLine("Defense: {0}",this.Defense);
			Console.WriteLine("Defensebonus: {0}",this.DefenseBonus);
			Console.WriteLine("Speed: {0}",this.Speed);
		}

	}
}

