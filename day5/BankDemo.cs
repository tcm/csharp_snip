using System;

class Account
{
	private decimal balance = 0;
	private static decimal income;
	private static int age;
	private static decimal minIncome =10000;
	private static int minAge = 18;



    public bool WithdrawFunds (decimal amount)
	{
		if (balance < amount) 
		{
			return false;
		}

		balance = balance - amount;
		return true;
	}

	public void PayInFunds (decimal amount)
	{
		balance = balance + amount;
	}


	public decimal GetBalance()
	{
		return balance;
	}

	public static bool AccountAllowed (decimal income, int age)
	{
		if ( ( income >= minIncome ) && ( age >= minAge ) )
		{
			return true;
		}
		else {
			return false;
		}
	}
   
}

class Bank
{
	public static void Main ()
	{

		if ( Account.AccountAllowed ( 25000, 21 ) )
		{
			Console.WriteLine ( "Allowed Account" );
		}

		Account MyAccount;
		MyAccount = new Account();

		if ( MyAccount.WithdrawFunds (5) )
		{
			Console.WriteLine ( "Cash Withdrawn" ) ;
		}
		else
		{
			Console.WriteLine ( "Insufficient Funds" ) ;
		}

		MyAccount.PayInFunds(10);
		Console.WriteLine("Balance: " + MyAccount.GetBalance() );

	}	
}