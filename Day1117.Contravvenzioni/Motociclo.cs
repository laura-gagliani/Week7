using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    class Motociclo : Veicolo
    {
        public string NumeroTelaio { get; set; }


        public Motociclo (string targa, string numeroTelaio) :base(targa)
        {
            NumeroTelaio = numeroTelaio;
        }
        public Motociclo()
        {

        }
    }
}
