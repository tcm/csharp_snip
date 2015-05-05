using System;

class Account
{
	public string Name;
};

class StructsAndObjectsDemo_2
{
	public static void Main ()
	{
		Account MyAccount;
		MyAccount = new Account();
		MyAccount.Name = "Heinz";

		Console.WriteLine(MyAccount.Name);
	}
}