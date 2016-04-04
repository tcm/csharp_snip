using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionDemo
{
    class MyPersonalException  : Exception
    {
        public string Zusatzinfos { get; set; }
    }
}
