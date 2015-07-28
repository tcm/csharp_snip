// Library erzeugen mit: mcs /target:library AccountManagement.cs

// Namespaces!
namespace CustomerBanking
{

public class Account
{
	private decimal balance = 0;
	public void PayInFunds ( decimal amount )
	{
		balance = balance + amount;
	}
	public decimal GetBalance ()
	{
		return balance;
	}
	public bool WithDrawFunds ( decimal amount )
	{
		if ( amount < 0 )
		{
			return false ;
		}
		if ( balance >= amount )
		{
			balance = balance - amount ;
			return true;
		}
		else
		{
			return false ;
		}
	}
}

}