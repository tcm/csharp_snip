using System;

interface ITestClass
{
	int normalMethod();
	// int staticMethod(); 
	// Erzeugt einen Fehler,
	// weil Interfaces nur für Objekt-Methoden 
	// funktionieren.

}

public class TestClass : ITestClass
{

	public int normalMethod ()
	{
		return 1;
	}

	public static int staticMethod ()
	{
		return 2;

	}
}

public class Program
{
	static void Main ()
	{
		TestClass a = new TestClass();
		Console.WriteLine(a.normalMethod());
		Console.WriteLine(TestClass.staticMethod());
	}
}
