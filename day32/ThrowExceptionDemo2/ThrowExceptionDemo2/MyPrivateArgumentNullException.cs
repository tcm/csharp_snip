using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionDemo2
{
    class MyPrivateArgumentNullException : ArgumentNullException
    {
        public string Zusatzinfos { get; set; }  
    }
}
