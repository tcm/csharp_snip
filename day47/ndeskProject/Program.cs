using System;
using NDesk.Options;
using System.Collections.Generic;

namespace ndeskProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			string data = null;
			bool help   = false;
			int verbose = 0;

			var p = new OptionSet () {
				{ "file=",      v => data = v },
				{ "v|verbose",  v => { ++verbose; } },
				{ "h|?|help",   v => help = v != null },
			};
			List<string> extra = p.Parse (args);

			Console.WriteLine ("file={0} Help={1} Debug={2}",data,help,verbose);
		}
	}
}
