using System;

namespace generic_example3
{
	// Beim Singleton-Pattern muß eine Static-Instanzvariable und Methode Verwendet werden.
	public static class ObjectCreator
	{


		static MyObject myO = null;

		public static MyObject CreateSingelton()
		{
			if (myO == null)
				myO = new MyObject ();
			return myO;
		}
	}
}

