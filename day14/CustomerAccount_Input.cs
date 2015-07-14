using System;


// Klasse mit Plausibiltätsprüfungen.
//
// Einfache Eingabeschleife.

interface IAccount
{
	string GetName();
	bool SetName( string inName );
	string ValidateName( string name );
}


class CustomerAccount : IAccount
{
	private string name;

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



	static void Main ()
	{
		string newName;
		CustomerAccount account = new CustomerAccount();

		while (true)
		{
			Console.Write ( "Enter new name : " ) ;
			newName = Console.ReadLine();

			string reply;
			reply = account.ValidateName(newName);
			if ( reply.Length == 0 )
			{
				break;
			}
			Console.WriteLine( "Invalid name : " + reply );
		}
		account.SetName(newName);
	}
}

