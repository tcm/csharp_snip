using System;

namespace performance_measure
{
	class MainClass
	{
		static DateTime timer;
		static Random rnd = new Random (DateTime.Now.Millisecond);


		public static void Main (string[] args)
		{
			StartMeasure ("Start");
			const int max = 100000000;

			int[] data = new int[max];


			for (int i = 0; i < max; i++) 
			{
				data [i] = rnd.Next(max);
			}
			EndMeasure ("End1");

			for (int i = 0; i < max; i++) 
			{
				data [i] = rnd.Next(max);
			}
			EndMeasure ("End1");

		}

		static void StartMeasure(string text)
		{
			Console.WriteLine(text);
			timer = DateTime.Now;
		}

		static void EndMeasure(string text)
		{
			double seconds = DateTime.Now.Subtract (timer).TotalSeconds;
			Console.WriteLine ("{0}: {1}sec", text, seconds);
			timer = DateTime.Now;
		}


	}
}
