using System;

namespace generic_example4
{
	public static class ObjectCreator<T> where T:class, new()
	{
		static T myT = default(T);

		public static T CreateSingleton()
		{
			if (myT == default(T))
				myT = new T ();
			return  myT;
		}
	}
}