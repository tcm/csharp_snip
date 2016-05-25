/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 25.05.2016
 * Time: 13:31
 * 
 */
using System;

namespace Class_Demo
{
	/// <summary>
	/// Description of IAnt.
	/// </summary>
	public interface IAnt
	{
	double GetSize();
	bool SetSize(double inSize);
	
	double GetSpeed();
	bool SetSpeed(double inSpeed);
	
	GenderType GetGender();
	bool SetGender(GenderType inGender);
	
	void PrintCreatureType();
	double GetOvarienSize();
 	}
	
}
