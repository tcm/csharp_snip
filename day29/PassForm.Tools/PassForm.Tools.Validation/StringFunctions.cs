using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassForm.Tools.Validation
{
    public class StringFunctions
    {
        private int _classid;
        private string _name;
        
        public StringFunctions()
        {
        }

        public StringFunctions(int classId,string Name)
        {
            this._classid = classId;
            this._name = Name;
        }

        public string combineArrayStringWithSpace(string[] StringArray)
        {
            var builder = new StringBuilder();

            if (StringArray == null)
            {
                return string.Empty;
            }

            /* ----------------------------------------------------- */
            /* Strings aus dem Array mit Leerzeichen zusammenfügen.  */
            /* ----------------------------------------------------- */
            foreach (string value in StringArray)
            {
                builder.Append(value);
                builder.Append(" ");
            }

            /* letztes Leerzeichen entfernen. */
            int length = builder.Length;
            builder.Remove(length - 1, 1);

            return builder.ToString();
        }
    }

}
