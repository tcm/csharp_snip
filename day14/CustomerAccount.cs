using System;


// Klasse mit Plausibiltätsprüfungen.
//
// Anmerkung:
// ValidateName wurde im Beispiel
// eingentlich mit static definiert,
// damit keine Objekt-Instanz benötigt
// wird. Geht aber irgendwie nicht1
// Mono-Einschränkung?

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


	// Test-Routinen.
	static void Main ()
	{
		int errorCount = 0;
		string reply;

		// Test auf Leerstrings und Null.
		CustomerAccount a = new CustomerAccount ();
		reply = a.ValidateName (null);
		if (reply != "Name parameter null") {
			Console.WriteLine ("Null name test failed");
			errorCount++;
		}
		reply = a.ValidateName ("");
		if (reply != "No text in the name") {
			Console.WriteLine ("Empty name test failed");
			errorCount++;
		}
		reply = a.ValidateName ("   ");
		if (reply != "No text in the name") {
			Console.WriteLine ("Blank string name test failed");
			errorCount++;
		}

        // Set-Tests mit und ohne Trim.
		CustomerAccount b = new CustomerAccount ();
		if (!b.SetName ("Jim")) {
			Console.WriteLine ("Jim SetName failed");
			errorCount++;
		}
		if (b.GetName () != "Jim") {
			Console.WriteLine ("Jim GetName failed");
			errorCount++;
		}
		if (!b.SetName ("   Pete   ")) {
			Console.WriteLine ("Pete trim SetName failed");
			errorCount++;
		}
		if (b.GetName () != "Pete") {
			Console.WriteLine ("Pete GetName failed");
			errorCount++;
		}

		if (errorCount > 0 )
		{
			Console.WriteLine(errorCount);
		}
	}
}

