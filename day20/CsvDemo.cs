// mcs /reference:ReadWriteCsv.dll CsvDemo.cs

using System;
using ReadWriteCsv;


class CsvDemo
{

static void Main()
{
	WriteTest ();
	ReadTest ();

}

	static void WriteTest()
	{
		// Write sample data to CSV file
		using (CsvFileWriter writer = new CsvFileWriter("testdaten.csv"))
		{
			for (int i = 0; i < 100; i++)
			{
				CsvRow row = new CsvRow();
				for (int j = 0; j < 5; j++)
					row.Add(String.Format("Column{0}", j));
				writer.WriteRow(row);
			}
		}
	}

	static void ReadTest()
	{
		// Read sample data from CSV file
		using (CsvFileReader reader = new CsvFileReader("testdaten.csv"))
		{
			CsvRow row = new CsvRow();
			while (reader.ReadRow(row))
			{
				foreach (string s in row)
				{
					Console.Write(s);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
	}

}