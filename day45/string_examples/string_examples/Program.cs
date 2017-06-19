using System;
using System.Diagnostics;

namespace string_examples
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string teststring = "The quick brown fox jumps over the lazy dog!";
			string suchstring = "fox";

			Debug.WriteLine (teststring);

			/* teststring = ReverseMe (teststring);
			Console.WriteLine (teststring);*/

			int pos = FindExpr (teststring, suchstring);
			Debug.WriteLine (pos);

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

		public static int FindExpr( string text, string pattern )
		{
			int text_length    = text.Length;
            int pattern_length = pattern.Length;
			int position = 0;
			int e = 0;
			int d = 0;
			
			if (pattern_length > text_length) {
   				 return -1;
  			}

			for (int c = 0; c <= text_length - pattern_length; c++) 
			{
					position = e = c;
				
					for (d = 0; d < pattern_length; d++) {
      					if (pattern[d] == text[e]) {
        					e++;
      					}
				      	else {
				      	  break;
				      	}
				      	
				      	if (d == pattern_length) {
     						 return position;
    					}     
				}
			}
			return -1;
		}


	}
}
