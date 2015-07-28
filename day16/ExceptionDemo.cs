using System;

// Eigene Exceptions definieren.


public class MyTestClass
{
	public int a;
	public string b;

	// Konstruktor
	MyTestClass (int inInt, string inString)
	{
		// Fehlerüberprüfung
		if ( inString.Length == 0 ) 
		{
			throw new BankException( "Invalid String. StringLength = 0" );
		}

		this.a = inInt;
		this.b = inString;

	}


	void print ()
	{
		Console.WriteLine(this.a);
		Console.WriteLine(this.b);

	}



	static void Main()
	{
		MyTestClass obj;

		try
		{
			obj = new MyTestClass(1, "");
		}
		catch (BankException exception)
		{
			Console.WriteLine( "Error : " + exception.Message);
		}



	}
}

// Eigene Exception-Klasse
public class BankException : System.Exception
{
	public BankException (string message) :
		base (message) // Ruft den Konstruktor der Elterklasse auf.
	{                  // und übergibt 'message'.
	}
}


