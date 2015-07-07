using System;
using System.Collections; // wegen Hashtable!
using System.IO;

// Speichern von Accounts in einer
// Hashtable.


// Interfaces
public interface IAccount
{
	void SetAccountName(string inName);
	string GetAccountName();
	void Save(TextWriter textOut);
	// Account Load(TextReader textIn);
}

public interface IBank
{
	Account FindAccount(string name);
	bool StoreAccount(Account account);
	void Print();
	bool Save(String filename);
	void Save(TextWriter textOut);
	//HashBank Load(string filename);
	//HashBank Load(StreamReader textIn);

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

	public void Save (TextWriter textOut)
	{
		textOut.WriteLine(name);
	}

	/* public Account Load (TextReader textIn)
	{
		Account result = null;
		
		try
		{
			string name = textIn.ReadLine();
			result = new Account();
			result.SetAccountName(name);
		}
		catch
		{
			return null;
		}
		return result;

	} */
}


public class HashBank : IBank 
{
	Hashtable bankHashtable = new Hashtable();


	// Suchen.
	public Account FindAccount (string name)
	{
		return bankHashtable[name] as Account;

	}

	// Speichern im Arbeitspeicher.
	public bool StoreAccount (Account account)
	{
		bankHashtable.Add(account.GetAccountName(), account);
		return true;
	}

	public void Print ()
	{
		foreach (Account account in bankHashtable.Values) 
		{
			Console.WriteLine(account.GetAccountName());

		}
	}


	// Speichern in File.
	public bool Save (string filename)
	{
		TextWriter textOut = null;

		try
		{
			textOut = new StreamWriter(filename);
			Save(textOut);
		}
		catch
		{
			return false;
		}
		finally
		{
			if (textOut != null)
			{
				textOut.Close();
			}
		}
		return true;
	}

	public void Save (TextWriter textOut)
	{
		textOut.WriteLine (bankHashtable.Count);
		foreach (Account account in bankHashtable.Values) 
		{
			account.Save (textOut);
		}

	}

	// Lesen aus File.
	/* public HashBank Load (string filename)
	{
		HashBank result = null;
		StreamReader textIn = null;
		
		try 
		{
			// Textfile öffnen.
			textIn = new StreamReader (filename);
			result = Load(textIn);
			
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

	public HashBank Load (StreamReader textIn)
	{

		HashBank result = new HashBank();

		
		try
		{
			string countString = textIn.ReadLine();

			int count = int.Parse(countString);
			for (int i = 0; i < count; i++)
			{
				Account account = Account.Load(textIn);
				result.bankHashtable.Add(account.GetAccountName(), account);
			}
		}
		catch
		{
			return null;
		}
		return result;
	} */


} 


// Jetzt geht's los....
public class BankDemo
{

  static void Main ()
	{
		// Ein Hash für Konten anlegen.
		HashBank DieGrosseBank = new HashBank ();


		// Einen Account anlegen.
		Account MeinKonto = new Account ();
		MeinKonto.SetAccountName ("User1Account");
		Console.WriteLine ("AccountName: " + MeinKonto.GetAccountName ()); 
		// Einen 2. Account anlegen.
		Account MeinKonto2 = new Account ();
		MeinKonto2.SetAccountName ("User2Account");
		Console.WriteLine ("AccountName: " + MeinKonto2.GetAccountName ()); 

		// Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto)) {
			Console.WriteLine ("Account stored in mem. OK");
		}
		// 2. Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto2)) {
			Console.WriteLine ("Account stored in mem. OK");
		}


		// In File speichern.
		if (DieGrosseBank.Save ("HashBank.dat")) 
		{
			Console.WriteLine ("Accounts stored in file. OK");
		}
		

  }

}