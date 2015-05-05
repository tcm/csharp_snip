using System;

//enum
enum AccountState
{
	New,
	Active,
	UnderAudit,
	Frozen,
	Closed
};

struct Account
{
	public AccountState State;
	public string Name;
	public string Adress;
	public int AccountNumber;
	public int Balance;
	public int Overdraft;
};

 

class BankProgram
{
	public static void Main()
	{
		Account MyAccount;

		MyAccount.State = AccountState.Active;
		MyAccount.AccountNumber = 1000;
		MyAccount.Name = "Peter";
		MyAccount.Adress = "Gartenweg 1";
		MyAccount.Balance = 0;
		MyAccount.Overdraft = -500;

		// Console.WriteLine("Name is: " + MyAccount.Name);
		// Console.WriteLine("Balance is: " + MyAccount.Balance);

		PrintAccount(MyAccount);
	}

	public static void PrintAccount (Account a)
	{
		Console.WriteLine("State is: " + a.State);
		Console.WriteLine("AccountNumber is: " + a.AccountNumber);
		Console.WriteLine("Name is: " + a.Name);
		Console.WriteLine("Adress is: " + a.Adress);
		Console.WriteLine("Balance is: " + a.Balance);
		Console.WriteLine("Adress is : " + a.Overdraft);
	}

}


