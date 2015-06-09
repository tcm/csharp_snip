using System;

// Speichern von Accounts in einem festen
// Array. Lineares speichern und suchen.


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


public class ArrayBank : IBank 
{
	private IAccount [] accounts;

	public ArrayBank( int bankSize )
	{
		accounts = new IAccount[bankSize];
	}


	public IAccount FindAccount (string name)
	{
		int position = 0;
		for (position = 0; position < accounts.Length; position++) 
		{
			if ( accounts[position] == null )
			{
				continue;
			}

			if (accounts[position].GetAccountName() == name)
			{
				return accounts[position]; 
			}
		}
		return null;

	}
	
	public bool StoreAccount (IAccount account)
	{
		int position = 0;
		for (position = 0; position < accounts.Length; position++) 
		{
			if ( accounts[position] == null )
			{
				accounts[position] = account;
				return true;
			}
		}
		return false;
	}

} 


// Jetzt geht's los....
public class BankDemo
{

  static void Main ()
	{
		// Ein Array für Konten anlegen.
		IBank DieGrosseBank = new ArrayBank (50);

		// Einen Account anlegen.
		IAccount MeinKonto = new Account ();
		MeinKonto.SetAccountName ("User1Account");
		Console.WriteLine ("AccountName: " + MeinKonto.GetAccountName ()); 
		// Einen 2. Account anlegen.
		IAccount MeinKonto2 = new Account ();
		MeinKonto.SetAccountName ("User2Account");
		Console.WriteLine ("AccountName: " + MeinKonto.GetAccountName ()); 

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