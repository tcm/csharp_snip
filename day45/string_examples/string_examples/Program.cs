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

		
			/* teststring = ReverseMe (teststring);
			Console.WriteLine (teststring);*/

			Debug.WriteLine (teststring);
			int pos = FindExpr (teststring, suchstring);
			Debug.WriteLine (pos);
			
			Debug.WriteLine (teststring);
			int pos2 = FindExpr (teststring, suchstring);
			Debug.WriteLine (pos2);

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

		// C-Lösung
		public static int FindExpr( string text, string pattern )
		{
			int text_length = text.Length;
            int pattern_length = pattern.Length;
			int position = -1;
			int e = 0;
			int d = 0;
			
			if (pattern_length > text_length) {
   				 return -1;
  			}

			
			for (int c = 0; c <= text_length - pattern_length; c++) {
					position = e = c;
				
					for (d = 0; d < pattern_length; d++) {
      					if (pattern[d] == text[e]) {
        					e++;
      					}
				      	else {
				      	  break;
				      	} 
				}
					
				if (d == pattern_length) {
     						 return position;
    			}
					
			}
			return -1;
		}
		
		
		// C#-Lösung aus Schrödinger
		public static int FindExpr2( string text, string pattern )
		{
			int position = -1;
			bool found = true;
			
			for (int i = 0; i < text.Length - pattern.Length; i++) {
				
				position = i;
				
				for (int j = 0; j < pattern.Length; j++) {
					if ( text[i + j] != pattern[j]) {
						found = false;
						break;
		      		}
					if (found)
						break;
		    	}
		    }
			return position;
	    }
		
		
		
		
	  }
	}

