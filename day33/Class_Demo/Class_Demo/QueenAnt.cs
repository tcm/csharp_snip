﻿/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 12.05.2016
 * Time: 14:14
 * 
 */
using System;


namespace Class_Demo
{
	/// <summary>
	/// Description of QueenAnt.
	/// </summary>
	public class QueenAnt  : Creature, IAnt
	{
		public QueenAnt()
		{
			Console.WriteLine("You have created a QueenAnt.");
		}
		
		public override void PrintCreatureType()
		{
			Console.WriteLine("QueenAnt");
		}
		
		public double GetOvarienSize()
		{
			return 0.6  * base.GetSize();
		} 
	}
}
