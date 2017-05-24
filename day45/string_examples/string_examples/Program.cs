using System;

namespace string_examples
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string teststring = "The quick brown fox jumps over the lazy dog!";
		

			Console.WriteLine (teststring);

			teststring = ReverseMe (teststring);
			Console.WriteLine (teststring);
		}

		public static string ReverseMe( string inStr )
		{
			int length = inStr.Length;
			char[] reverse = new char[inStr.Length+1];

			int j = 0;
			// Array von hinten durchlaufen.
			for ( int i = length-1; i >= 0 ; i--)
			{
				reverse [j++] = inStr [i];
			}
			return new string(reverse);
		}

		public static void FindExpr( string inStr )
		{
			int length = inStr.Length;
			// TODO:

		}


	}
}
