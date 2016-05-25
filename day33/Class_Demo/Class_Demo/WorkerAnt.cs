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
	public class WorkerAnt : Creature, IAnt
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
