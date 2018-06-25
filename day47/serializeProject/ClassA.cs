using System;
using System.Runtime.Serialization;



namespace serializeProject 
{

	[DataContract]
	public class ClassA 
	{
		// The value to serialize.
		[DataMember]
		private string myProperty_value;


		public string MyProperty
		{
			get { return myProperty_value; }
			set { myProperty_value = value; }
		}

		[DataMember]
		public int value;

		public ClassA ()
		{
		}


	}
}

