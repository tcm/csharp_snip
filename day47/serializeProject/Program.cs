using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace serializeProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			ClassA bsObj = new ClassA()  
			{  
				MyProperty = "C-sharpcorner",
				value = 10
			};  


			DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ClassA));
			MemoryStream msObj = new MemoryStream(); 
			js.WriteObject(msObj, bsObj);  
			msObj.Position = 0;  
			StreamReader sr = new StreamReader(msObj); 

			string json = sr.ReadToEnd();  

			Console.WriteLine("{0}",json);

			sr.Close();  
			msObj.Close();  
		}
	}
}
