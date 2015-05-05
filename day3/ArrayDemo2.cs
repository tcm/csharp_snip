using System;

class ArrayDemo
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
		const int SCORE_SIZE = 3;
		int [] scores = new int [SCORE_SIZE]; // Array definieren.

		for (int i = 0; i < SCORE_SIZE; i++) 
		{
			scores[i] = readInt("Score:",0,1000);

		}
	}
}

