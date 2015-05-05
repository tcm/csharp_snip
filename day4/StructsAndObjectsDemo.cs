using System;

struct AccountStruct
{
	public string Name;
};

class StructsAndObjectsDemo
{
	public static void Main ()
	{
		AccountStruct MyAccount;
		MyAccount.Name = "Heinz";

		Console.WriteLine(MyAccount.Name);
	}
}