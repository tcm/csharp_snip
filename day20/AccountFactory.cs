using System;
using System.IO;

// Interfaces
public interface IAccount
{

	string GetName ();
	bool WithdrawFunds ( decimal amount );
	decimal GetBalance ();
	void Save (TextWriter textOut);
}

// Classes
public class CustomerAccount : IAccount
{
	private string name = "";
	private decimal balance = 0;

	public CustomerAccount ()
	{
	}

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

	public void Save (TextWriter textOut)
	{
		textOut.WriteLine (name);
		textOut.WriteLine (balance);
	}
}

public class BabyAccount : CustomerAccount
{
	private string parentName;

	/* public BabyAccount ()
	{
	} */

	/* public BabyAccount (string inName, decimal inBalance)
	{
		name = inName;
		balance = inBalance;
	} */

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

	public BabyAccount(
		string newName,
		decimal initialBalance,
		string inParentName)
		: base(newName, initialBalance)
	{
		parentName = inParentName;
	}
}


// Jetzt geht's los....
public class AccountFactory
{

	static void Main ()
	{

		// Einen CustomerAccount anlegen.
		CustomerAccount MeinKonto = new CustomerAccount ("Ted", 100);

		// Einen BabyAccount anlegen.
		// BabyAccount MeinBabyKonto = new BabyAccount ("Snuffles", 200);

	}
}