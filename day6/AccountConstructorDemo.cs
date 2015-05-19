using System;

class Account
{
	// private member data
	private string name;
	private string address;
	private decimal balance;

	// constructors
	public Account (string inName, string inAddress, decimal inBalance)
	{
		name = inName;
		address = inAddress;
		balance = inBalance;
	}

	public Account (string inName, string inAddress) :
		this(inName, inAddress, 0)
	{
	}

	public Account (string inName) :
		this(inName, "Not defined", 0)
	{
	}

	// setters
	public void setBalance(decimal inBalance)
	{
		balance = inBalance;
	}

	// 
	public void printAccount ()
	{
		Console.WriteLine(name);
		Console.WriteLine(address);
		Console.WriteLine(balance);
		Console.WriteLine("---");

	}

	static void Main ()
	{
		//Account
		Account MyAccount;
		MyAccount = new Account("Brian", "Jerusalem", 1000);
		MyAccount.printAccount();

		//Account2
		Account MyAccount2;
		MyAccount2 = new Account("Luis", "Paris");
		MyAccount2.printAccount();

		//change the balance
		MyAccount2.balance = 200;
		MyAccount2.printAccount();

		//change the balance (2)
		MyAccount2.setBalance(400);
		MyAccount2.printAccount();

		//Account3
		Account MyAccount3;
		MyAccount3 = new Account("Jerry");
		MyAccount3.printAccount();

	}

}

