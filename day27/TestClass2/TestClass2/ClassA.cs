/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 17.12.2015
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestClass2
{
	/// <summary>
	/// Description of ClassA.
	/// </summary>
	public class ClassA
	{
		decimal currentPrice; // Das private Hintergrundfeld.
		
		public decimal CurrentPrice // Die öffentliche Eigenschaft.
		{
			get { return currentPrice; }
			private set { currentPrice = value; }
		}
		
		public ClassA()
		{
			
		}
	}
}
