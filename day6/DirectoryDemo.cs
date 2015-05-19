using System;
using System.IO;
using System.Text.RegularExpressions;

class DirectoryDemo
{

	public void readTextFile (string path)
	{
		StreamReader reader;
		reader = new StreamReader(path);

		// Alle Zeilen lesen.
		while (reader.EndOfStream == false)
		{
			string line = reader.ReadLine();
			Console.WriteLine(line);

		}
		reader.Close();
	}

	public string readTextFile_and_findRegex (string path, string pattern)
	{
	
		StreamReader reader = new StreamReader(path);
		Regex regExp = new Regex(pattern);
		string result = "";

		
		// Alle Zeilen lesen und nach Muster suchen.
		while (reader.EndOfStream == false)
		{
			string line = reader.ReadLine();
			foreach (Match match in regExp.Matches(line))
			{
				//result += "\n" + match.ToString();
				result += "\n" +  line;
			}

		}
		reader.Close();
		return result;
	}

	public string findRegex (string line, string pattern)
	{
		Regex regExp = new Regex(pattern);
		string result = "";

		foreach (Match match in regExp.Matches(line))
		{
			result += "\n" + match.ToString();
		}
		return result; 
	}



	static void Main ()
	{
		DirectoryDemo AllFiles;
		AllFiles = new DirectoryDemo();

		string result;

		// Files auswählen.
		foreach (string file in Directory.EnumerateFiles("/home/user1/Dokumente","*.txt") ) 
		{
			Console.WriteLine(file);
			Console.WriteLine("=============");
			result = AllFiles.readTextFile_and_findRegex(file,"and");
			Console.WriteLine(result);
		
		}
	}


}
