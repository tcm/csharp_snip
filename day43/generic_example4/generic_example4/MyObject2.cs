using System;

namespace generic_example4
{
	public class MyObject2
	{
		int value1;
		string value2;

		public MyObject2 ()
		{
		} 

		// Value1
		public void setValue1(int value)
		{
			this.value1 = value;
		}

		public int getValue1()
		{
			return this.value1;
		}

		// Value2
		public void setValue2(string value)
		{
			this.value2 = value;
		}
			
		public string getValue2()
		{
			return this.value2;
		}
	}
}

