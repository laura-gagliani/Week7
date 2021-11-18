using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    class Vigile
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int NumeroMatricola { get; set; }

        public List<Contravvenzione> Contravvenzioni { get; set; } = new List<Contravvenzione>();

        public Vigile (string nome, string cognome, int numeroMatricola)
        {
            Nome = nome;
            Cognome = cognome;
            NumeroMatricola = numeroMatricola;
        }
        public Vigile()
        {

        }
    }
}
