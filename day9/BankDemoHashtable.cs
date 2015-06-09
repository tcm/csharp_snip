using System;
using System.Collections; // wegen Hashtable!

// Speichern von Accounts in einer
// Hashtable.


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


public class HashBank : IBank 
{
	Hashtable bankHashtable = new Hashtable();

	
	public IAccount FindAccount (string name)
	{
		return bankHashtable[name] as IAccount;

	}
	
	public bool StoreAccount (IAccount account)
	{
		bankHashtable.Add(account.GetAccountName(), account);
		return true;
	}

} 


// Jetzt geht's los....
public class BankDemo
{

  static void Main ()
	{
		// Ein Hash für Konten anlegen.
		IBank DieGrosseBank = new HashBank ();

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