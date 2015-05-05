using System;

class WindowDemo
{
	static double ReadValue(
		string prompt,
		double min,
		double max
		)
	{
		double result = 0;

		do
		{

			Console.WriteLine(prompt + " between " + min + " and " + max);
			string ResultString = Console.ReadLine();
			result = double.Parse(ResultString);

		} while ( (result < min ) || (result > max) );
		return result;
	}


	static void Main ()
	{
		double age = ReadValue ("Enter your age: ", 10, 45);

		Console.WriteLine("Age: " + age);
	}
}
