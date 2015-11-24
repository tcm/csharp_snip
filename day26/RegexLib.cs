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
			bool isValid = false;
			this.pattern = @"^((\+[0-9]{2,4}([ -][0-9]+?[ -]| ?\([0-9]+?\) ?))|(\(0[0-9 ]+?\) ?)|(0[0-9]+? ?( |-|\/) ?))([0-9]+?[ \/-]?)+?[0-9]$";

			Regex regExp = new Regex (pattern);
			isValid = regExp.IsMatch(StringIn);

			return isValid; 
		}

		static void Main ()
		{
			RegexLib teststring = new RegexLib ();
			string StringIn;

			StringIn = "(09270)1476";
			if (teststring.Test_TelefonNumber (StringIn)) {
				Console.WriteLine (StringIn + " -> true");
			} else 
			{
			    Console.WriteLine (StringIn + " -> false");
			}
			// Console.WriteLine(teststring.pattern);

			StringIn = "+49-678788--444444";
			if (teststring.Test_TelefonNumber (StringIn)) {
				Console.WriteLine (StringIn + " -> true");
			} else 
			{
				Console.WriteLine (StringIn + " -> false");
			}
			// Console.WriteLine(teststring.pattern);

				
		}
	}
}

