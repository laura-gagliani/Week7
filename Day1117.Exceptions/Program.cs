using System;
using System.Collections.Generic;
using System.IO;

namespace Day1117.Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region eccezione divisione per 0

            //int a = 8;
            //int b = 2;
            //int c = a / b;
            //Console.WriteLine($"Il risultato della divisione è {c}");

            ////int d = 8;
            ////int e = 0;
            ////int f = d/e;
            ////Console.WriteLine($"Il risultato della divisione è {f}");

            //try
            //{
            //    int d = 8;
            //    int e = 0;
            //    int f = d / e;
            //    Console.WriteLine($"Il risultato della divisione è {f}");
            //}
            //catch (DivideByZeroException ex0)  //si parte dal catch più specifico...
            //{
            //    Console.WriteLine("Errore , divisione per 0!!");
            //    Console.WriteLine(ex0.ToString());
            //}

            //catch (ArithmeticException ex1)  //catch "intermedio"...
            //{
            //    Console.WriteLine("Errore , eccezione aritmetica!!");
            //    Console.WriteLine(ex1.ToString());
            //}

            //catch (Exception ex)  // ...solo dopo il più generico, che cattura qualsiasi tipo di eccezione
            //{
            //    Console.WriteLine("Errore!");
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    Console.WriteLine("stampa in ogni caso");
            //}

            #endregion

            #region eccezione su stream reader
            //LeggiFile();
            #endregion

            //array lungh fissa (tipo 10)
            //chiedi utente di inserire la posizione in cui vuole scrivere un numero + il numero da inserire 
            //evitare i soliti controlli: catturare invece tutti i possibili errori con eccezioni (quella generica, sul formato, sull'indice outofrange...)

            try
            {
                int[] array = new int[10];
                int numeriInseriti = 0;
                int index;
                int num;
                List<int> indexChiamati = new List<int>();
                Console.WriteLine("Hai a disposizione un array con 10 posizioni che puoi riempire di interi");
                Console.WriteLine("Regola: non puoi sovrascrivere una posizione dove hai già inserito \n");
                do
                {
                    Console.WriteLine("In che posizione vorresti inserire un numero?");
                    index = int.Parse(Console.ReadLine());                          //system format exception
                    

                    Console.WriteLine("Qual è il numero da inserire?");
                    num = int.Parse(Console.ReadLine());                            //format

                    foreach (var item in indexChiamati)
                    {
                        if (item == index)
                        {
                            throw new Exception("Non puoi sovrascrivere posizione nell'array!!");
                        }
                    }
                    indexChiamati.Add(index);
                    array[index] = num;                                             //out of range
                    numeriInseriti++;

                } while (numeriInseriti < 10);
            }
            catch(FormatException)
            {
                Console.WriteLine($"Errore! ");
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Errore! {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Errore! {ex.Message}");
            }
            
            



        }



        private static void LeggiFile()
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(@"F:\Laura\Documenti\Avanade\Academy\Week7\Week7\Day1117.Exceptions\FileDaLeggere.txt");
                string contenutoFile = sr.ReadToEnd();
                Console.WriteLine(contenutoFile);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Errore, file non trovato. {ex.Message}");
            } 
            catch (Exception ex0)
            {
                Console.WriteLine($"errore - catch più generica possibile");
            }
            finally
            {
                if (sr != null) //se lo sr è diverso da null, ovvero "se la connessione è ancora aperta"
                {
                    sr.Close();
                }
            }
        }
    }
}
