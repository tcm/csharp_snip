using System;

class SwitchCaseDemo
{
	// String einlesen, der nicht
	// leer sein darf.
	static string readString (string prompt)
	{
		string result;

		do
		{
			Console.Write(prompt);
			result = Console.ReadLine();
		}
		while( result == "" );

		return result;
	}

	// Integer einlesen, die in einem
	// definierten Intervall liegen.
	static int readInt (string prompt, int low, int high)
	{

		int result;

			do
			{   
				string inStr = readString(prompt);
				result = int.Parse(inStr);
		
			} while ( (result < low) || (result > high) );
		

			

		return result;

	}

	static void Main ()
	{
		int auswahl;

		auswahl = readInt("Wahl:",0,100);

		switch (auswahl)
		{
			case 1:
			Console.WriteLine("1");
			break;

			case 2:
			Console.WriteLine("2");
			break;

			case 3:
			Console.WriteLine("3");
			break;

		    default:
			Console.WriteLine("groesser als 3");
			break;

		}


	}
}

