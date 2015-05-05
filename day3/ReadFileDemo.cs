using System;
using System.IO;

class ReadFileDemo
{
	
	
	static void Main ()
	{
		string path;
		
		path = @"testdatei.txt";
		
		StreamReader reader;
		reader = new StreamReader(path);
		
		while (reader.EndOfStream == false)
		{
			string line = reader.ReadLine();
			Console.WriteLine(line);
		}
		reader.Close();
		
		
		
	}
	
}
