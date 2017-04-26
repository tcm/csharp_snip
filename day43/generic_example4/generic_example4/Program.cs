using System;

namespace generic_example4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// MyObject
			var obj1 = ObjectCreator<MyObject>.CreateSingleton ();
			obj1.setValue1 (1);
			obj1.setValue2 ("eins");
			Console.WriteLine (obj1.getValue1().ToString());
			Console.WriteLine (obj1.getValue2());

			// MyObject2
			var obj2 = ObjectCreator<MyObject2>.CreateSingleton ();
			obj2.setValue1 (2);
			obj2.setValue2 ("zwei");
			Console.WriteLine (obj2.getValue1().ToString());
			Console.WriteLine (obj2.getValue2());

			// MyObject mit obj3
			var obj3 = ObjectCreator<MyObject>.CreateSingleton ();
			Console.WriteLine ();
			Console.WriteLine (obj3.getValue1().ToString());
			Console.WriteLine (obj3.getValue2());
		}
	}
}
