using System;
using System.Collections.Generic; // wegen Dictionary!

// Speichern von Accounts in einer
// Dictionary.


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


public class DictionaryBank : IBank 
{
	Dictionary<string,IAccount> bankDictionary = new Dictionary<string,IAccount>();
		
	public IAccount FindAccount (string name)
	{
		return bankDictionary[name] as IAccount;

	}
	
	public bool StoreAccount (IAccount account)
	{
	
		bankDictionary.Add(account.GetAccountName(), account);
		return true;
	}

} 


// Jetzt geht's los....
public class BankDemo
{

  static void Main ()
	{
		// Ein Dictionary für Konten anlegen.
		IBank DieGrosseBank = new  DictionaryBank();

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