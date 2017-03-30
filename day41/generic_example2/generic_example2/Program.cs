using System;

namespace generic_example2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
		
			// Integer FIFO
			var Qi = new WaitingQueue<int>(10);
			int item;

			Qi.Push (3);
			Qi.Push (5);
			Qi.Push (7);

			item = Qi.Pop();
			Console.WriteLine ("Qi: {0}", item);

			item = Qi.Pop();
			Console.WriteLine ("Qi: {0}", item);

			item = Qi.Pop();
			Console.WriteLine ("Qi: {0}", item);

			item = Qi.Pop();
			Console.WriteLine ("Qi: {0}", item);

			Qi.Push (1);
			Qi.Push (2);
			Qi.Push (3);

			item = Qi.Pop();
			Console.WriteLine ("Qi: {0}", item);



			// String FIFO
			var Qs = new WaitingQueue<string>(10);
			string item2;

			Qs.Push ("Hund");
			Qs.Push ("Katze");
			Qs.Push ("Maus");

			item2 = Qs.Pop();
			Console.WriteLine ("Qs: {0}", item2);

			item2 = Qs.Pop();
			Console.WriteLine ("Qs: {0}", item2);

			item2 = Qs.Pop();
			Console.WriteLine ("Qs: {0}", item2);

			item2 = Qs.Pop();
			Console.WriteLine ("Qs: {0}", item2);

			Qs.Push ("Fahrrad");
			Qs.Push ("Auto");
			Qs.Push ("Bus");

			item2 = Qs.Pop();
			Console.WriteLine ("Qs: {0}", item2);



		}
	}
}
