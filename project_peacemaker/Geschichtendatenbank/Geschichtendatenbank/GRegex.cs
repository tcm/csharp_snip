using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Geschichtendatenbank
{
  

    class GRegex
    {
        private string pattern;

        
		public GRegex ()
		{
		}

        public bool Is_TelefonNumber (string StringIn)
		{
			bool isValid = false;
			this.pattern = @"^((\+[0-9]{2,4}([ -][0-9]+?[ -]| ?\([0-9]+?\) ?))|(\(0[0-9 ]+?\) ?)|(0[0-9]+? ?( |-|\/) ?))([0-9]+?[ \/-]?)+?[0-9]$";

			Regex regExp = new Regex (pattern);
			isValid = regExp.IsMatch(StringIn);
			return isValid; 
		}

        public bool Is_Four_Digits (string StringIn)
		{
			bool isValid = false;
			this.pattern = @"^\d\d\d\d$";

			Regex regExp = new Regex (pattern);
			isValid = regExp.IsMatch(StringIn);
			return isValid; 
		}
    }
}
