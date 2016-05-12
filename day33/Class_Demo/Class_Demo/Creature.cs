/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 27.04.2016
 * Time: 14:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

public enum GenderType
{
	Male,
	Female
}

public interface ICreature
{
	double GetSize();
	bool SetSize(double inSize);
	
	double GetSpeed();
	bool SetSpeed(double inSpeed);
	
	GenderType GetGender();
	bool SetGender(GenderType inGender);
	
	void PrintCreatureType();

}

namespace Class_Demo
{
	/// <summary>
	/// Description of Creature.
	/// </summary>
	public abstract class Creature : ICreature
	{
		private double Size;
		private double Speed;
		private GenderType Gender;
		
		public Creature()
		{
			Console.WriteLine("You have created a creature.");
		}
		
		// Size
		public double GetSize()
		{
			return this.Size;
		}
		
		public bool SetSize( double inSize )
		{
			if ( inSize <= 1 && inSize <= 10)
			{
				return false;
			}
			
			this.Size = inSize;
			return true;
		}
		
		// Speed
		public double GetSpeed()
		{
			return this.Speed;
		}
		
		public bool SetSpeed( double inSpeed )
		{
			if ( inSpeed <= 1 && inSpeed <= 100)
			{
				return false;
			}
			
			this.Speed = inSpeed;
			return true;
		}
		
		// Gender
		public GenderType GetGender()
		{
			return this.Gender;
		}
		
		public bool SetGender(GenderType inGender)
		{
			this.Gender = inGender;
			return true;
		}
		
		public abstract void PrintCreatureType();
		
		
	}
}
