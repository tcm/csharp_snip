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
	public class WorkerAnt : Creature, ICreature, IAnt
	{
		public WorkerAnt()																
		{
			Console.WriteLine("You have created a WorkerAnt.");
		}
		
		public override void PrintCreatureType()
		{
			Console.WriteLine("WorkerAnt");
		}
		
		public double GetOvarienSize()
		{
			return 0.1  * base.GetSize();
		} 
		
		
	}
}
