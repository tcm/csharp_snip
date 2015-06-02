using System;

interface IStaffMember
{
	int Age
	{
		get;
		set;
	}

	int AgeInMonth
	{
		get;
	}
}

public class StaffMember
{
	private int ageValue;

	// Declare a Property.
	public int Age 
	{
		set 
		{
			if ( (value > 0) && (value < 120) )
			{
				this.ageValue = value;
			}
		}

		get 
		{
			return this.ageValue;
		}
	}

	// Another Property.
	public int AgeInMonths
	{
		get
		{
			return this.ageValue*12;
		}
	}
		
	static void Main ()
	{
		StaffMember MyMember = new StaffMember();

		MyMember.Age = 10;
		Console.WriteLine("Age:" + MyMember.Age);
		Console.WriteLine("AgeInMonth:" + MyMember.AgeInMonths);

	} 
}


