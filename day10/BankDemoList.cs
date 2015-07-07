using System;
using System.Collections.Generic; // wegen List!

// Speichern von Accounts in einer
// Generic-List.
// Wieder mit linearer Suche!


// Interfaces
public interface IAccount
{
	void SetAccountName(string inName);
	string GetAccountName();
}

public interface IBank
{
	IAccount FindAccount(string name);
	bool StoreAccount(IAccount account);
} 


// Classes
public class Account : IAccount
{
	private string name = "";

	public void SetAccountName(string inName)
	{
		this.name = inName;
	}

	public string GetAccountName()
	{
		return this.name;
	}
	
}


public class ListBank : IBank 
{
	
	// Leere Generic-List anlegen.
	List<IAccount> bankList = new List<IAccount>();
	
	public IAccount FindAccount (string name)
	{
		int position = 0;

		for (position = 0; position < bankList.Count; position++) 
		{
			// Da in der List nur Referenzen gespeichert
			// werden, müßen wir die Referenz in einer realen
			// Variablen zwischenspeichern.
			//
			// Typecast fällt diesmal weg, das er schon
			// bei der Definition explizit angeben werden
			// muss.
			IAccount accounts = bankList[position];

			if ( accounts == null )
			{
				continue;
			}

			if ( accounts.GetAccountName() == name)
			{
				return accounts; 
			}
		}
		return null;

	}
	
	public bool StoreAccount (IAccount account)
	{
		bankList.Add(account);
		return true;

	}

} 


// Jetzt geht's los....
public class BankDemo
{

  static void Main ()
	{
		// Ein Hash für Konten anlegen.
		IBank DieGrosseBank = new ListBank();

		// Einen Account anlegen.
		IAccount MeinKonto = new Account ();
		MeinKonto.SetAccountName ("User1Account");
		Console.WriteLine ("AccountName: " + MeinKonto.GetAccountName ()); 
		// Einen 2. Account anlegen.
		IAccount MeinKonto2 = new Account ();
		MeinKonto2.SetAccountName ("User2Account");
		Console.WriteLine ("AccountName: " + MeinKonto2.GetAccountName ()); 

		// Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto)) 
		{
			Console.WriteLine ("Account stored OK");
		}
		// 2. Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto2)) 
		{
			Console.WriteLine ("Account stored OK");
		}


		IAccount gesuchterDatensatz = DieGrosseBank.FindAccount ("User2Account");

		if (gesuchterDatensatz == null) 
		{
			Console.WriteLine ("Nicht gefunden!");
		} 
		else 
		{
			Console.WriteLine("Gefunden: " + gesuchterDatensatz.GetAccountName());
		}




  }

}