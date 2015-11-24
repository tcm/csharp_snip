using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Application
{
	public class RegexLib
	{
		private string pattern;

		public RegexLib ()
		{
		}

		public bool Test_TelefonNumber (string StringIn)
		{
			bool result = false;
			this.pattern = ".tt.";

			Regex regExp = new Regex (pattern);

			MatchCollection matchCollection = regExp.Matches(StringIn);
			int matchesFound = matchCollection.Count;

			if ( matchesFound > 0 ) { result = true; }

			return result; 
		}

		static void Main ()
		{
			RegexLib teststring = new RegexLib ();
			string StringIn;



			StringIn = "Otto";
			if (teststring.Test_TelefonNumber (StringIn)) {
				Console.WriteLine (StringIn + " -> true");
			} else 
			{
			    Console.WriteLine (StringIn + " -> false");
			}
			Console.WriteLine(teststring.pattern);

			StringIn = "Willi";
			if (teststring.Test_TelefonNumber (StringIn)) {
				Console.WriteLine (StringIn + " -> true");
			} else 
			{
				Console.WriteLine (StringIn + " -> false");
			}
			Console.WriteLine(teststring.pattern);

				
		}
	}
}

