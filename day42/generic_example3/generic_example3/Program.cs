using System;

namespace generic_example3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Ein Objekt das mit dem Singelton-Pattern erzeugt wurde,
			// liefert immer das gleicht Objekt zurück.
			MyObject obj = ObjectCreator.CreateSingelton ();

			obj.setValue1 (1);
			obj.setValue2 ("eins");

			Console.WriteLine (obj.getValue1().ToString());
			Console.WriteLine (obj.getValue2());


			MyObject obj2 = ObjectCreator.CreateSingelton ();

			Console.WriteLine (obj.getValue1().ToString());
			Console.WriteLine (obj.getValue2());

		}
	}
}
