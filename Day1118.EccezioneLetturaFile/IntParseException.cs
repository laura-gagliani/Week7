using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1118.EccezioneLetturaFile
{
    class IntParseException :Exception
    {
        public string ToBeParsed { get; set; }

        public IntParseException()
        {

        }
        public IntParseException(string message) : base(message)
        {

        }
    }
}
