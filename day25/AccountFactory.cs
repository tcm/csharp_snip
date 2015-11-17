using System;
using System.IO;

// Interfaces
public interface IAccount
{

	string GetName ();
	bool WithdrawFunds ( decimal amount );
	decimal GetBalance ();
	bool Save (string filename);
	void Save (TextWriter textOut);
}

// Classes
public class CustomerAccount : IAccount
{
	private string name = "";
	private decimal balance = 0;

	
	public CustomerAccount (string inName, decimal inBalance)
	{
		name = inName;
		balance = inBalance;
	}
	
	public string GetName ()
	{
		return this.name;
	}

    public virtual bool WithdrawFunds (decimal amount)
	{
		if ( this.balance < amount )
		{
			return false ;
		}
		this.balance = this.balance - amount ;
		return true;
	}
		
	public decimal GetBalance ()
	{
		return this.balance;
	}

	public static CustomerAccount Load (TextReader textIn)
	{
		CustomerAccount result = null;
		
		try
		{
			string name = textIn.ReadLine();            // read Name
			string balanceText = textIn.ReadLine();     // read Balance
			decimal balance = decimal.Parse(balanceText);
			result = new CustomerAccount(name, balance);
		}
		catch
		{
			return null;
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


	public virtual void Save (TextWriter textOut)
	{
		textOut.WriteLine (name);
		textOut.WriteLine (balance);
	}
}

public class BabyAccount : CustomerAccount
{
	private string parentName;

	public BabyAccount(
		string inName, decimal inBalance, string inParentName) 
		: base(inName, inBalance)
	{
		parentName = inParentName;
	}


	public string GetParentName()
	{
		return parentName;
	}

	public override bool WithdrawFunds(decimal amount)
	{
		if (amount > 10)
		{
			return false;
		}
		return base.WithdrawFunds(amount);
	}

	public override void Save (TextWriter textOut)
	{
		base.Save(textOut);                      // Methode aus der Elternklasse aufrufen.
		textOut.WriteLine(parentName);
	}
}


// Jetzt geht's los....
public class AccountFactory
{

	static void Main ()
	{


		// TODO: Load für BabyAccount
		//       class hashBank anlegen, siehe day13!

		// Einen CustomerAccount anlegen.
		CustomerAccount MeinKonto = new CustomerAccount ("Ted", 100);
		MeinKonto.Save("caccounts.dat");

		// Einen BabyAccount anlegen.
		BabyAccount MeinBabyKonto = new BabyAccount ("Snuffles", 200, "Ted");
		MeinBabyKonto.Save("baccounts.dat");


		// Ausgabe zur Kontrolle.
		Console.WriteLine("CustomerAccount:");
		Console.WriteLine("Name:" + MeinKonto.GetName());
		Console.WriteLine("Balance: " + MeinKonto.GetBalance());
		Console.WriteLine("---");
		Console.WriteLine("BabyAccount:");
		Console.WriteLine("Name: " + MeinBabyKonto.GetName());
		Console.WriteLine("Balance: " + MeinBabyKonto.GetBalance());
		Console.WriteLine("Parent: " + MeinBabyKonto.GetParentName());
	}
}