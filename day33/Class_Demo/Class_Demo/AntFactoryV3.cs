/*
 * Created by SharpDevelop.
 * User: juergen
 * Date: 15.06.2016
 * Time: 13:10
 * 
 */
using System;
using System.Collections.Generic;

namespace Class_Demo
{
	/// <summary>
	///  Factory mit 'Dictionary'. Ab Framework 2.0.
	/// Ich versteh's noch nicht, aber das eine Frage der Zeit.
	/// </summary>
	public class AntFactoryV3
	{
		public AntFactoryV3()
		{
            _Mappings = new Dictionary<AntType, Func<IAnt>>(3);
            
            _Mappings.Add(AntType.WorkerAnt, () => new WorkerAnt());
            _Mappings.Add(AntType.QueenAnt, () => new QueenAnt());
            _Mappings.Add(AntType.MaleAnt, () => new MaleAnt());
     
		}
		
		public IAnt Get(AntType antType)
        {
			Func<IAnt> func;
			
            if (_Mappings.TryGetValue(antType, out func))
            {
                return func();
            }
            else
                throw new NotImplementedException();
        }
        readonly Dictionary<AntType, Func<IAnt>> _Mappings;
	}
 }

