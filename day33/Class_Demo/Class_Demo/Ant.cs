/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 27.04.2016
 * Time: 15:27
 * 
 */
using System;

namespace Class_Demo
{
	/// <summary>
	/// Description of Ant.
	/// </summary>
	public class Ant : Creature, ICreature
	{
		public Ant( int intSize, int inSpeed, GenderType inGender) :
			base(intSize, inSpeed, inGender)																	
		{
			Console.WriteLine("You have created a Ant.");
		}
		
		public override void PrintCreatureType()
		{
			Console.WriteLine("Ant");
		}
	}
}
