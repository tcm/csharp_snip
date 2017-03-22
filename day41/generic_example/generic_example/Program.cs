using System;

namespace generic_example
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Integer LIFO
			var Ci = new TrashContainer<int> (10);
			Ci.Push(1);
			Ci.Push(4);
			Ci.Push (6);

			int lastValue = Ci.Pop ();
			Console.WriteLine ("lastValue: {0}", lastValue);

			// String LIFO
			var Cs = new TrashContainer<string> (10);
			Cs.Push ("Papiermüll");
			Cs.Push ("Metall");
			Cs.Push ("Plastik");

			string s = Cs.Pop ();
			Console.WriteLine ("s: {0}", s); 
			s = Cs.Pop ();
			Console.WriteLine ("s: {0}", s); 

		}
	}
}
