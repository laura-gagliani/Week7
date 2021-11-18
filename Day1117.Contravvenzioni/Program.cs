using System;

namespace Day1117.Contravvenzioni
{
    class Program
    {
        static void Main(string[] args)
        {


            //dipendente comunale che accede ed ha un menu con
            //1. visualizza tutte contravvenzioni
            //2. visualizza contravvenzioni dato il vigile (es. tramite matricola)
            //3. visualizza contravvenzioni dato il veicolo (tramite targa)

            //lavoriamo tramite DB (ADO) -> attenzione ai "SQL exception" (stringa sbagliata, query sbagliata...)

            //partiamo dalle classi e controlliamo quelle - poi si prosegue

            Menu.Start();
        }
    }
}
