/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 19.05.2016
 * Time: 14:09
 * 
 */
using System;

public enum AntType
{
	QueenAnt,
	WorkerAnt,
	MaleAnt
}

namespace Class_Demo
{
	/// <summary>
	/// Factory mit 'case'. Ab Framework 1.0
	/// </summary>
	static class AntFactoryV1
	{
		
		public static IAnt Get(AntType antType)
		{
			switch (antType)
			{	
				case AntType.QueenAnt:
					return new QueenAnt();
				case AntType.WorkerAnt:
					return new WorkerAnt();
				case AntType.MaleAnt:
					return new MaleAnt();
				default:
					throw new NotImplementedException();
			}
		}
	}
}
