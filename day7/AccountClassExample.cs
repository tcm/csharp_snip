using System;

// Methoden definieren.
public interface IAccount
{
	void PayInFunds ( decimal amount );
	bool WithdrawFunds ( decimal amount );
	decimal GetBalance ();
	string RudeLetterString();
}

public abstract class Account : IAccount
{
	private decimal balance = 0;

	public abstract string RudeLetterString();

	// Auszahlen.
	public virtual bool WithdrawFunds ( decimal amount )
	{
		if ( balance < amount )
		{
			return false ;
		}
		balance = balance - amount ;
		return true;
	}

	// Kontostand
	public decimal GetBalance ()
	{
		return balance;
	}

	public void PayInFunds ( decimal amount )
	{
		balance = balance + amount ;
	}
}

// Kindklasse definieren.
public class CustomerAccount : Account
{
	public override string RudeLetterString()
	{
		return "You are overdrawn" ;
	}
}

// Noch eine Kindklasse definieren.
public class BabyAccount : Account
{
	public override bool WithdrawFunds ( decimal amount )
	{
		if (amount > 10)
		{
			return false ;
		}
		return base.WithdrawFunds(amount);
	}
	public override string RudeLetterString()
	{
		return "Tell daddy you are overdrawn";
	}


	static void Main ()
	{
		CustomerAccount MeinKonto;
		MeinKonto = new CustomerAccount();

		// Und mal was einzahlen.
		Console.WriteLine("\n"+ "CustomerAccount");
		MeinKonto.PayInFunds(100);
		Console.WriteLine("Balance:" + MeinKonto.GetBalance());
		Console.WriteLine(MeinKonto.WithdrawFunds(110)); // Mehr auszahlen, als drin ist.
		Console.WriteLine(MeinKonto.RudeLetterString());

		BabyAccount MeinBabyKonto;
		MeinBabyKonto = new BabyAccount();
		
		// Und mal was einzahlen.
		Console.WriteLine("\n" + "BabyAccount");
		MeinBabyKonto.PayInFunds(100);
		Console.WriteLine("Balance:" + MeinBabyKonto.GetBalance());
		Console.WriteLine(MeinBabyKonto.WithdrawFunds(20)); // Mehr als 10 dürfen nicht ausgezahlt werden.
		Console.WriteLine("Balance:" + MeinBabyKonto.GetBalance());

		Console.WriteLine(MeinBabyKonto.WithdrawFunds(10)); 
		Console.WriteLine("Balance:" + MeinBabyKonto.GetBalance());

		Console.WriteLine(MeinBabyKonto.RudeLetterString());



	}
}