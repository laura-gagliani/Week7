using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1118.NumeriComplessi
{
    class NumeroComplesso
    {
        //a + ib

        public double ParteReale { get; set; }
        public double ParteImmaginaria { get; set; }

        //vogliamo gestire un'eccezione personalizzata per la divisione tra numeri complessi
        // definisco quindi in questa classe un metodo che mi fa la divisione tra numeri complessi

        public NumeroComplesso Dividi(NumeroComplesso value)
        {
            // un metodo non static così sarà chiamato da uno dei due numeri, e prenderà in input l'altro numero per cui dividere!

            // ( (ac + bd)/(c^2 + d^2) + i ((bc-ad)/(c^2 + d^2))

            //facciamo intanto il denominatore
            double denom = Math.Pow(value.ParteReale,2) + Math.Pow(value.ParteImmaginaria,2);

            // if denom == 0 voglio lanciare un'eccezione personalizzata
            if (denom == 0)
            {
                throw new NumeroComplessoException("denominatore nullo, impossibile procedere con l'operazione")
                {
                    Dividendo = this,
                    Divisore = value
                }; //sto quindi istanziando la classe ! e gli sto dicendo chi sono gli attributi
            }

            double parteRealeRisultato = ((ParteReale*value.ParteReale)+(ParteImmaginaria*value.ParteImmaginaria))/ denom;
            double parteImmaginariaRisultato = ((ParteImmaginaria*value.ParteReale)-(ParteReale*value.ParteImmaginaria)) / denom;

            return new NumeroComplesso
            {
                ParteReale = parteRealeRisultato,
                ParteImmaginaria = parteImmaginariaRisultato
            };
        }

        public override string ToString()
        {
            if (ParteImmaginaria < 0)
            {
                return $"{ParteReale} - i{Math.Abs(ParteImmaginaria)}";
            }

            return $"{ParteReale} + {ParteImmaginaria}i";
        }
    }
}
