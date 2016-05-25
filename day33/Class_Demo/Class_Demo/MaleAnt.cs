/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 25.05.2016
 * Time: 13:44
 * 
 */
using System;

namespace Class_Demo
{
	/// <summary>
	/// Description of MaleAnt.
	/// </summary>
	public class MaleAnt : Creature, IAnt
	{
		public MaleAnt()
		{
			Console.WriteLine("You have created a MaleAnt.");
		}
		
		public override void PrintCreatureType()
		{
			Console.WriteLine("MaleAnt");
		}
		
		public double GetOvarienSize()
		{
			return 0;
		} 	
	}
}
