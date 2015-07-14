using System;


// Klasse mit Plausibiltätsprüfungen.
//
// Mit Edit-Klasse.

public interface IAccount
{
	string GetName();
	bool SetName( string inName );
	string ValidateName( string name );
}


public class CustomerAccount : IAccount
{
	private string name;

	public CustomerAccount (string inName)
	{
		this.name = inName;
	} 

	public string GetName()
	{
		return this.name;
	}

	public bool SetName (string inName)
	{
		string reply;

		reply = ValidateName (inName);
		if ( reply.Length > 0 ) {
			return false;
		}

		this.name = inName;
		return true;
	}

	public string ValidateName (string name)
	{
		if (name == null) {
			return "Name parameter null.";
		}
		string trimmedName = name.Trim ();
		if (trimmedName.Length == 0) {
			return "Name parameter empty.";
		}
		return "";
	}	

	
}

public class AccountEditTextUI
{
	private IAccount account;

	public AccountEditTextUI( IAccount inAccount)
	{
		this.account = inAccount;
	}

	public void EditName ()
	{
		string newName;
		Console.WriteLine( "Name Edit" );

		while (true)
		{
			Console.Write ( "Enter new name : " ) ;
			newName = Console.ReadLine();
			string reply;
			reply = this.account.ValidateName(newName);
			if ( reply.Length == 0 )
			{
				break;
			}
			Console.WriteLine( "Invalid name : " + reply );
		}
		this.account.SetName(newName);
	}

}

public class Program
{
	static void Main ()
	{
		CustomerAccount a = new CustomerAccount("Ted");
		AccountEditTextUI edit = new AccountEditTextUI(a);
		
		edit.EditName();
		
	}
}