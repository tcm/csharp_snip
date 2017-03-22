using System;

namespace generic_example2
{
	public class WaitingQueue<T>
	{
		T[] queue;
		int idx = 0;

		public WaitingQueue (int size)
		{
			this.queue = new T[size];
		}

		public void Push (T item)
		{
		}
			
		public T Pop()
		{
			return this.queue [idx];;
		}

		public void Clear()
		{
		}
	}
}

