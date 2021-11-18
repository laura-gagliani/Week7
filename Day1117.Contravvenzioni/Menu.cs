using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    class Menu
    {
        static DbManager db = new DbManager();

        internal static void Start()
        {

            bool quit = false;

            do
            {
                Console.WriteLine(".......... MENU ..........");
                Console.WriteLine("[1] Visualizza tutte le contravvenzioni");
                Console.WriteLine("[2] Visualizza le contravvenzioni per il vigile selezionato");
                Console.WriteLine("[3] Visualizza le contravvenzioni per il veicolo selezionato");

                Console.WriteLine("[0] Esci");

                int choice;
                //choice = GetMenuInt(0, 3);
                choice = GetMenuIntWithEx();

                switch (choice)
                {
                    case 0:
                        quit = true;
                        Console.WriteLine("Chiusura in corso...");
                        break;

                    case 1:
                        VisualizzaTutte();
                        break;

                    case 2:
                        VisualizzaPerVigile();
                        break;

                    case 3:
                        VisualizzaPerVeicolo();
                        break;

                    case -1:
                        Console.WriteLine("Input incorretto!");
                        break;

                     default:
                        Console.WriteLine("Scelta errata dal menu");
                        break;
                        
                        }


            } while (!quit);

        }

        private static int GetMenuIntWithEx()
        {
            
            try
            {
                Console.WriteLine("Seleziona dal menu:");
                int num = int.Parse(Console.ReadLine());
                return num;
            }
            catch
            {
                Console.WriteLine("Errore nell'inserimento");
                return -1;
            }

           
        }

        private static void VisualizzaPerVeicolo()
        {
            string id = SelectTarga();
            List<Contravvenzione> multeVeicoli = db.GetByVeicoloId(id);
            foreach (var item in multeVeicoli)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static string SelectTarga()
        {
            Console.WriteLine("Inserisci la targa del veicolo richiesto:");
            string id = Console.ReadLine();

            return id;
        }

        private static void VisualizzaPerVigile()
        {
            int id = SelectMatricola();
            List<Contravvenzione> multeVigile = db.GetByVigileId(id);
            foreach (var item in multeVigile)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static int SelectMatricola()
        {
            int id = 0;
            try
            {
                
                Console.WriteLine("Inserisci la targa del veicolo richiesto:");
                id = int.Parse(Console.ReadLine());
                
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Errore!");
                

            }
            return id;


        }

        private static void VisualizzaTutte()
        {

            List<Contravvenzione> multe = db.GetAll();
            Console.WriteLine("Le contravvenzioni in database sono:");
            foreach (var item in multe)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static int GetMenuInt(int min, int max)
        {
            bool isInt;
            int num;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out num);

            } while (!isInt || num < min || num > max);

            return num;
        }
    }
}
