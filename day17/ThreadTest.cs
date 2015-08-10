using System;
using System.Threading;


// Ein etwas besseres Thread-Beispiel.
// Ausführlich ist das Ganze im C#-Thread-Buch.


class ThreadTest
{
  static void Main()
  {
		Thread t = new Thread(WriteY);  // Kick off a new thread
		t.Start ();						// running WriteY()

		// Simultaneously, do something on the main thread.
		for (int i = 0; i < 1000; i++) Console.Write ("x");
  }

  static void WriteY()
  {
	for (int i = 0; i < 1000; i++) Console.Write ("y");
  }

}