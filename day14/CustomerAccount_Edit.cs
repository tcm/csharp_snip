using System;


// Klasse mit Plausibiltätsprüfungen.
//
// Mit Edit-Klasse.

public interface IAccount
{
	string GetName();
	bool SetName( string inName );

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

	public static string ValidateName (string name)
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

	public void DoEdit ()
	{
		string command;
		
		do
		{
			Console.WriteLine ( "Editing account for {0}", account.GetName() );
			Console.WriteLine ( "Enter name to edit name" );
			Console.WriteLine ( "Enter pay to pay in funds" );
			Console.WriteLine ( "Enter draw to draw out funds" );
			Console.WriteLine ( "Enter exit to exit program" );
			Console.Write ("Enter command : ");
			command = Console.ReadLine();
			command = command.Trim();
			command = command.ToLower();
			switch ( command )
			{
				
			case "name" :
				EditName();
				break;
			case "pay" :
				//PayInFunds();
				Console.WriteLine("Not implemented.");
				break;
			case "draw" :
				//WithDrawFunds();
				Console.WriteLine("Not implemented.");
				break;
				
			}
		} while ( command != "exit" );
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
			reply = CustomerAccount.ValidateName(newName);
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
		CustomerAccount a = new CustomerAccount("Account1");

		AccountEditTextUI menue = new AccountEditTextUI(a);
		menue.DoEdit();
		
	}
}