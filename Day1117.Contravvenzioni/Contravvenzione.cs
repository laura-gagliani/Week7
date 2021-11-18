using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    class Contravvenzione
    {
        public int NumeroVerbale { get; set; }
        public DateTime Data { get; set; }
        public string Luogo { get; set; }

        public Veicolo Veicolo { get; set; } 
        public Vigile Vigile { get; set; } 


        public string TargaVeicolo { get; set; }
        public int MatricolaVigile { get; set; }


        public Contravvenzione(int numeroVerbale, DateTime data, string luogo, Veicolo veicolo, Vigile vigile)
        {
            NumeroVerbale = numeroVerbale;
            Data = data;
            Luogo = luogo;
            Veicolo = veicolo;
            Vigile = vigile;
        }
        public Contravvenzione()
        {

        }

        public override string ToString()
        {
            return $"Numero di Verbale: {NumeroVerbale} Data: {Data} Luogo: {Luogo} - Targa veicolo: {TargaVeicolo} - Matricola Vigile: {MatricolaVigile} ";
        }
    }
}
