using System;
using System.Collections;

// wegen Hashtable!
using System.IO;

// Speichern von Accounts in einer
// Hashtable.
// Anschließend speichern wir
// die Struktur in einem File.
//
// Lesen geht jetzt!
// Allerdings noch nicht die Optimal-Lösung.



// Interfaces
public interface IAccount
{
	void SetAccountName (string inName);
	string GetAccountName ();
	void SetAccountBalance (decimal inBalance);
	decimal GetAccountBalance ();
	void Save (TextWriter textOut);
}

public interface IBank
{
	Account FindAccount (string name);
	bool StoreAccount (Account account);
	void Print ();
	bool Save (String filename);
	void Save (TextWriter textOut);
	// bool Load(string filename);
} 


// Classes
public class Account : IAccount
{
	private string name = "";
	private decimal balance = 0;

	public Account ()
	{
	}

	public Account (string inName, decimal inBalance)
	{
		name = inName;
		balance = inBalance;
	}

	public void SetAccountName (string inName)
	{
		this.name = inName;
	}

	public string GetAccountName ()
	{
		return this.name;
	}

	public void SetAccountBalance (decimal inBalance)
	{
		this.balance = inBalance;
	}

	public decimal GetAccountBalance ()
	{
		return this.balance;
	}

	public static Account Load (TextReader textIn)
	{
		Account result = null;
		
		try
		{
			string name = textIn.ReadLine();            // read Name
			string balanceText = textIn.ReadLine();     // read Balance
			decimal balance = decimal.Parse(balanceText);
			result = new Account(name, balance);
		}
		catch
		{
			return null;
		}
		return result;

	} 

	public void Save (TextWriter textOut)
	{
		textOut.WriteLine (name);
		textOut.WriteLine (balance);
	}
}

public class HashBank : IBank
{
	Hashtable bankHashtable = new Hashtable ();


	// Suchen.
	public Account FindAccount (string name)
	{
		return bankHashtable [name] as Account;

	}

	// Speichern im Arbeitspeicher.
	public bool StoreAccount (Account account)
	{
		bankHashtable.Add (account.GetAccountName (), account);
		return true;
	}

	public void Print ()
	{
		foreach (Account account in bankHashtable.Values) {
			Console.WriteLine (account.GetAccountName ());
			Console.WriteLine (account.GetAccountBalance ());
		}
	}

	// Lesen der Accounts aus dem File.
	/* public bool Load (string filename)
	{
		TextReader textIn = null;

		try {
			textIn = new StreamReader (filename);
			Load (textIn);
			
		} catch {
			return false;
			
		} finally {
			
			if (textIn != null) {
				textIn.Close ();
			}
		}
		return true;
	} */

	public static HashBank Load (TextReader textIn)
	{
		HashBank result = new HashBank();
		string countString = textIn.ReadLine();
		int count = int.Parse(countString);
		for (int i = 0; i < count; i++)
		{
			Account account = Account.Load(textIn);
			result.bankHashtable.Add(account.GetAccountName(), account);

		}
		return result;
	} 


	// Speichern in File.
	public bool Save (string filename)
	{
		TextWriter textOut = null;

		try {
			textOut = new StreamWriter (filename);
			Save (textOut);

		} catch {
			return false;

		} finally {

			if (textOut != null) {
				textOut.Close ();
			}
		}
		return true;
	}

	public void Save (TextWriter textOut)
	{
		textOut.WriteLine (bankHashtable.Count);
		foreach (Account account in bankHashtable.Values) {
			account.Save (textOut);
		}

	}	
} 


// Jetzt geht's los....
public class BankDemo
{

	static void Main ()
	{
		// Ein Hash für Konten anlegen.
	    HashBank DieGrosseBank = new HashBank ();

		// Einen Account anlegen.
		Account MeinKonto = new Account ("Ted", 100);
		Account MeinKonto2 = new Account ("Edi", 200);
		Account MeinKonto3 = new Account ("Fritz", 300);

		// Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto)) {
			Console.WriteLine ("Account stored in mem. OK");
		}
		// 2. Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto2)) {
			Console.WriteLine ("Account stored in mem. OK");
		}
		// 3. Account in der Bank speichern.
		if (DieGrosseBank.StoreAccount (MeinKonto3)) {
			Console.WriteLine ("Account stored in mem. OK");
		}

		// In File speichern.
		if (DieGrosseBank.Save ("HashBank.dat")) {
			Console.WriteLine ("Accounts stored in file. OK");
		}

		// DieGrosseBank.Print();


		// Einen leeren Hash für Konten anlegen.
		HashBank Die_neue_GrosseBank = new HashBank ();

		TextReader textIn = new StreamReader("HashBank.dat");
		Die_neue_GrosseBank = HashBank.Load (textIn);
		Die_neue_GrosseBank.Print();
	}
}