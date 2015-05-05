using System;


class ReturnDemo
{
	static int sillyReturnPlus (int i)
	{
		Console.WriteLine("i is: "+i);
		i += 1;
		return i;
	}

	static void Main ()
	{
		int res;

		res = sillyReturnPlus (101);
		Console.WriteLine("res is: "+res);

		res = sillyReturnPlus (102);
		Console.WriteLine("res is: "+res);
	}
}
