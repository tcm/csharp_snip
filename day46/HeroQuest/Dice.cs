using System;

namespace HeroQuest
{
	public static class Dice
	{
		static Random _random = new Random();

	/*	public Dice ()
		{
		} */

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

