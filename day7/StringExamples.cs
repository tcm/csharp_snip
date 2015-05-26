using System;


public class StringExamples
{
	static void Main ()
	{
		//Zuweisungen.
		string s1="Rob";
		string s2=s1;
		s2 = "different";
		Console.WriteLine(s1 + " " + s2);

		// Vergleichen.
		s1="Juergen";
		s2="Juergen";
		if ( s1 == s2 )
		{
			Console.WriteLine("The same");
		}

		if ( s1.Equals(s2) )
		{
			Console.WriteLine("Still the same");
		}

		// Substrings
		s1="Robert";
		s1=s1.Substring(1,2);
		Console.WriteLine(s1);

		s1="Miles";
		s1=s1.Substring(2);
		Console.WriteLine(s1);

		// Laenge.
		Console.WriteLine ( "Length: " + s1.Length);

		// Großschreibung
		s1=s1.ToUpper();
		Console.WriteLine(s1);

		s1="     Troll    ";
		s1=s1.Trim();
		Console.WriteLine(s1);

	}

}


