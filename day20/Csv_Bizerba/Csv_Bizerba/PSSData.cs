using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csv_Bizerba
{
   
   
    class PssData
    {
    	
        public string Prefix
        {
            get;
            set;
        }

        public string Belegnummer
        {
            get;
            set;
        }

        public string Zusatzfeld
        {
            get;
            set;
        }

        public string Versandcode
        {
            get;
            set;
        }

        public string Versandtag
        {
            get;
            set;
        }

        public Decimal Gewicht
        {
            get;
            set;
        }

        public Decimal Preis
        {
            get;
            set;
        }
        
        public String Verfolgungsnummer
        {
        	get;
        	set;
        }
    }
}
