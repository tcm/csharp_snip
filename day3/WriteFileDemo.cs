using System;
using System.IO;

class WriteFileDemo
{


	static void Main ()
	{
		string path;

		path = @"testdatei.txt";

		StreamWriter writer;
		writer = new StreamWriter(path);

		writer.WriteLine("hello world");

		writer.Close();



	}

}
