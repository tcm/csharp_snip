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
	int GetSize();
	int GetSpeed();
	GenderType GetGender();
	void PrintCreatureType();
}

namespace Class_Demo
{
	/// <summary>
	/// Description of Creature.
	/// </summary>
	public abstract class Creature : ICreature
	{
		private int Size;
		private int Speed;
		private GenderType Gender;
		
		public Creature(int inSize, int inSpeed, GenderType inGender)
		{
			Size = inSize;
			Speed = inSpeed;
			Gender = inGender;
			Console.WriteLine("You have created a creature.");
		}
		
		public int GetSize()
		{
			return this.Size;
		}
		
		public int GetSpeed()
		{
			return this.Speed;
		}
		
		public GenderType GetGender()
		{
			return this.Gender;
		}
		
		public abstract void PrintCreatureType();
			
	}
}
