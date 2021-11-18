using System;
using System.Collections.Generic;
using System.IO;

namespace Day1118.EccezioneLetturaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //dato un file txt che contiene per ogni riga un numero intero
            //a un certo punto metto una stringa(o qualsiasi altra cosa) invece che un int
            //l'applicazione deve leggere questo file e mettere riga per riga in una lista di interi (e quindi la stringa darà eccezione)
            //questa lista va stampata a video

            //versione semplificata: fare senza lista...
            //deve leggere un singolo valore dal file e mettere in un int(se non è un int va in eccezione)

            string path = @"F:\Laura\Documenti\Avanade\Academy\Week7\Week7\Day1118.EccezioneLetturaFile\File.txt";



            //try
            //{
            //    Console.WriteLine(ReadValueFromFile(path));
            //}
            //catch(IntParseException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine($"Valore letto dal File: {ex.ToBeParsed}");
            //}

            try
            {
                ReadIntsFromFile(path);

            }
            catch (IntParseException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Valore letto dal File: {ex.ToBeParsed}");
            }



        }

        private static void ReadIntsFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {

                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(ParseValueFromString(lines[i]));
                }

            }


        }

        static int ParseValueFromString(string s)
        {

            bool parse = int.TryParse(s, out int value);

            if (!parse)
            {
                throw new IntParseException($"Errore nella conversione in int")
                {
                    ToBeParsed = s
                };

            }
            return value;


        }

        static int ParseValueFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string stringToParse = sr.ReadLine();
                bool parse = int.TryParse(stringToParse, out int value);

                if (!parse)
                {
                    throw new IntParseException($"Errore nella conversione in int")
                    {
                        ToBeParsed = stringToParse
                    };

                }
                return value;
            }

        }





    }
}
