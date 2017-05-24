using System;

namespace string_examples
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string teststring = "The quick brown fox jumps over the lazy dog!";
			string suchstring = "fox";

			Console.WriteLine (teststring);

			/* teststring = ReverseMe (teststring);
			Console.WriteLine (teststring);*/

			int pos = FindExpr (teststring, suchstring);
			Console.WriteLine (pos);

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

		public static int FindExpr( string inStr, string findStr )
		{
			int length = inStr.Length;
			int length_f = findStr.Length;
			int pos = 0;

			for (int i = 0; i < (length - length_f); i++) 
			{
				for (int j = 0; j < length_f; j++) 
				{
					pos = i;
					if (inStr [i + j ] == findStr [j])
						return pos;
				}
			}
			return 0;
		}


	}
}
