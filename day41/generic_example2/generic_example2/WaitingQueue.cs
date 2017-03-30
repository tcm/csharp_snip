using System;

namespace generic_example2
{
	// Bei der Definition steht in der eckigen Klammer <T>
	// und beim Aufruf steht hier der Typ, z.B. <int>
	public class WaitingQueue<T>
	{
		T[] queue;
		int idxIn = 0;
		int idxOut = 0;

		public WaitingQueue (int size)
		{
			this.queue = new T[size];
		}

		public void Push (T item)
		{
			queue [idxIn] = item;
			idxIn++;
		}
			
		public T Pop()
		{
			T item;

			if (idxOut < idxIn) // Enthält unsere Queue noch nicht verarbeitete Elemente
			{
				item =  this.queue [idxOut];
				idxOut++;
			} 
			else
				item =  default(T);

			return  item;
		}

		public void Clear()
		{
			idxIn = 0;
			idxOut = 0;

			this.queue = new T[this.queue.Length];
		}
	}
}

