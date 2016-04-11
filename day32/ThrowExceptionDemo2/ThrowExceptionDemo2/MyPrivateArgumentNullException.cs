using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionDemo2
{
    class MyPrivateArgumentNullException : ArgumentNullException
    {
        public MyPrivateArgumentNullException( string ZusatzInfos )
        {
            zusatzinfos = ZusatzInfos;
        }
        public string zusatzinfos { get; set; }

       
    }
}
