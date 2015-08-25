using System;
using System.IO;
using System.Collections.Generic;

class Program
{

static void Main(string[] args)
{
	var reader = new StreamReader(File.OpenRead(@"test.csv"));
	List<string> listA = new List<string>();
	List<string> listB = new List<string>();
	while (!reader.EndOfStream)
	{
		var line = reader.ReadLine();
		var values = line.Split(',');
		
		listA.Add(values[0]);
		listB.Add(values[1]);
	}

    // Print listA
	Console.WriteLine("listA:");
	foreach ( string item in listA){
			Console.WriteLine(item);
    }

	// Print listB
	Console.WriteLine("listB:");
	foreach ( string item in listB){
			Console.WriteLine(item);
	}
}
}