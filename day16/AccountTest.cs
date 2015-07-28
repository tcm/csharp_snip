// Compilieren mit: 
// mcs /reference:AccountManagement.dll AccountTest.cs

using System;
using CustomerBanking; // Wichtig!


class AccountTest
{
	public static void Main ()
	{
		Account test = new Account();
		test.PayInFunds (50);
		Console.WriteLine ("Balance:" + test.GetBalance());
	}
}
