using System;
using System.Threading;

class ThreadDemo
{
	static private void busyLoop ()
	{
		long count;
		for (count = 0; count < 10000000000L; count++) {

		}
	}

	static void Main ()
	{
		int max = 3;

		ThreadStart busyLoopMethod = new ThreadStart (busyLoop);

		for (int  n = 0; n < max; n++) { // Start max Threads

			Thread t1 = new Thread (busyLoopMethod);


			t1.Start (); 

			if (t1.ThreadState == ThreadState.Running) {
				Console.WriteLine ("Thread " + t1.ManagedThreadId +  " is running...");
			}

			/* if (t1.ThreadState == ThreadState.Aborted) {
			    Console.WriteLine ("Thread " + t1.ManagedThreadId +  " is aborted...");
			} */


		}


	}
}