using System;

// Eigene Exception-Klassen definieren.
// und anwenden.


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
			throw new BankExceptionBadString( "StringLength = 0" );
		}

		// Fehlerüberprüfung
		if ( inInt < 0 ) 
		{
			throw new BankExceptionBadInteger( "Integer < 0" );
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

		// 1. Versuch
		try
		{
			obj = new MyTestClass(1, "");
		}
		catch (BankExceptionBadString stringException)
		{
			Console.WriteLine("Invalid string : " +
			                  stringException.Message);
		}
		catch (BankExceptionBadInteger intException)
		{
			Console.WriteLine("Invalid integer : " +
			                  intException.Message);
		}
		catch (System.Exception exception )
		{
			Console.WriteLine("System exception : " +
			                  exception.Message);
		}

		// 2. Versuch
		try
		{
			obj = new MyTestClass(-1, "Testsring");
		}
		catch (BankExceptionBadString stringException)
		{
			Console.WriteLine("Invalid string : " +
			                  stringException.Message);
		}
		catch (BankExceptionBadInteger intException)
		{
			Console.WriteLine("Invalid integer : " +
			                  intException.Message);
		}
		catch (System.Exception exception )
		{
			Console.WriteLine("System exception : " +
			                  exception.Message);
		}
	}
}

// Eigene Exception-Klassen
public class BankExceptionBadString : System.Exception
{
	public BankExceptionBadString (string message) :
		base (message) // Ruft den Konstruktor der Elterklasse auf.
	                   // und übergibt 'message'.
	{
	}
}

public class BankExceptionBadInteger : System.Exception
{
	public BankExceptionBadInteger (string message) :
		base (message) 
	{
	}
}



