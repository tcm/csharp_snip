/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 27.04.2016
 * Time: 15:27
 * 
 */
using System;

public interface IAnt
{
	double GetOvarienSize();
}

namespace Class_Demo
{
	/// <summary>
	/// Description of Ant.
	/// </summary>
	public class Ant : Creature, ICreature, IAnt
	{
		public Ant()																
		{
			Console.WriteLine("You have created a Ant.");
		}
		
		public override void PrintCreatureType()
		{
			Console.WriteLine("Ant");
		}
		
		public double GetOvarienSize()
		{
			return 0.6  * base.GetSize();
			// return 0.6 * this.Size;
		} 
		
		
	}
}
