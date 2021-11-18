using System;

namespace Day1118.NumeriComplessi
{
    class Program
    {
        static void Main(string[] args)
        {
            // (a + ib) / (c + id)
            Console.WriteLine("------ Divisione tra numeri complessi ------");
            
            Console.WriteLine("\nDividendo -> inserisci la parte reale:");
            double.TryParse(Console.ReadLine(), out double a);

            Console.WriteLine("\nDividendo -> inserisci la parte immaginaria:");
            double.TryParse(Console.ReadLine(), out double b);

            Console.WriteLine("\nDivisore -> inserisci la parte reale:");
            double.TryParse(Console.ReadLine(), out double c);

            Console.WriteLine("\nDivisore -> inserisci la parte immaginaria:");
            double.TryParse(Console.ReadLine(), out double d);

            NumeroComplesso dividendo = new NumeroComplesso { ParteImmaginaria = b, ParteReale = a };
            NumeroComplesso divisore = new NumeroComplesso { ParteImmaginaria = d, ParteReale = c };
            try
            {
                NumeroComplesso risultato = dividendo.Dividi(divisore);
                Console.WriteLine($"\nIl risultato è {risultato.ToString()}");
            }
            catch(NumeroComplessoException ncex)
            {
                Console.WriteLine(ncex.Message);
                Console.WriteLine($"Dividendo: {ncex.Dividendo} - Divisore: {ncex.Divisore}");

            }
            
        }
    }
}
