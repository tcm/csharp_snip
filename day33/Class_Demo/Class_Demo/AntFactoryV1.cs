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
	WorkerAnt
}

namespace Class_Demo
{
	/// <summary>
	/// Description of FactoryV1.
	/// </summary>
	static class AntFactoryV1
	{
		
		public static ICreature Get(AntType antType)
		{
			switch (antType)
			{	
				case AntType.QueenAnt:
					return new QueenAnt();
				case AntType.WorkerAnt:
					return new WorkerAnt();
				default:
					throw new NotImplementedException();
			}
		}
	}
}
