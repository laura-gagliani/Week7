using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    abstract class Veicolo
    {
        public string Targa { get; set; }

        public List<Contravvenzione> Contravvenzioni { get; set; } = new List<Contravvenzione>();

        public Veicolo (string targa)
        {
            Targa = targa;
        }
        public Veicolo()
        {

        }
    }
}
