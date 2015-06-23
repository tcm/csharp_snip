using System;
using System.IO;


// Einfache Demo-Klasse,
// um das Speichern von
// Objekten in einer Text-
// Datei zu demonstrieren.
//
// Ein Account pro Datei!

public interface IAccount
{
	void PayInFunds ( decimal amount );
	bool WithdrawFunds ( decimal amount );
	decimal GetBalance ();
	string GetName();
	bool Save ( string filename );
	CustomerAccount Load (string filename);
	void PrintAccount();
}

public class CustomerAccount : IAccount
{
	// Constructor.
	public CustomerAccount(
		string newName,
		decimal initialBalance)
	{
		name = newName;
		balance = initialBalance;
	}

	private decimal balance = 0;
	private string name;


	// Auszahlen.
	public virtual bool WithdrawFunds ( decimal amount )
	{
		if ( balance < amount )
		{
			return false;
		}
		balance = balance - amount ;
		return true;
	}

	// Einzahlen.
	public void PayInFunds ( decimal amount )
	{
		balance = balance + amount ;
	}
	
	// Kontostand.
	public decimal GetBalance ()
	{
		return this.balance;
	}

	// Account-Name.
	public string GetName()
	{
		return this.name;
	}

	// Speichern.
	public bool Save (string filename)
	{
		try 
		{
			StreamWriter writer = new StreamWriter (filename);
			writer.WriteLine (name);
			writer.WriteLine (balance);
			writer.Close ();

		} 
		catch 
		{
			return false;
		}

		return true;
	}

	public void PrintAccount ()
	{
		Console.WriteLine (this.name);
		Console.WriteLine (this.balance);
	}


	public CustomerAccount Load (string filename)
	{
		CustomerAccount result = null;
		StreamReader textIn = null;

		try 
		{
			// Textfile öffnen.
			textIn = new StreamReader (filename);

			// Zwei Strings lesen.
			string nameText = textIn.ReadLine ();
			string balanceText = textIn.ReadLine ();
			// Konvertieren von balance.
			decimal balance = decimal.Parse (balanceText);

			result = new CustomerAccount (nameText, balance);
		} 
		catch 
		{
			return null;
		} 
		finally 
		{
			// Bei Bedarf, Datei schließen.
			if (textIn != null ) textIn.Close();
		}

		return result;

	}
		
	static void Main ()
	{
		CustomerAccount MeinKonto = new CustomerAccount ("Ted", 100);
		CustomerAccount MeinKonto2 = new CustomerAccount ("Edi", 200);

		// Konto 1 und 2 anzeigen.
		MeinKonto.PrintAccount ();
		MeinKonto2.PrintAccount ();

		// ... und speichern.
		// 1
		if (MeinKonto.Save ("account1.dat")) {
			Console.WriteLine ("Account gespeichert.");
		} 
		else 
		{
			Console.WriteLine ("Fehler beim Account speichern.");
		}

		// 2
		if (MeinKonto2.Save ("account2.dat")) {
			Console.WriteLine ("Account gespeichert.");
		} 
		else 
		{
			Console.WriteLine ("Fehler beim Account speichern.");
		}



		// Daten wieder einlesen.
		CustomerAccount result = new CustomerAccount("---", 0);
		result = result.Load("account1.dat");
		result.PrintAccount();
				 
	}

}
