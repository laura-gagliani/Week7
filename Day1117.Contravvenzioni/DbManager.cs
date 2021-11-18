using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1117.Contravvenzioni
{
    class DbManager : IDbManager<Contravvenzione>
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PoliziaUrbana;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Contravvenzione> GetAll()
        {
            List<Contravvenzione> contravvenzioni = new List<Contravvenzione>();
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();              //data.sqlclient.sqlexception
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Contravvenzione"; //sqlexception

                    SqlDataReader reader = command.ExecuteReader(); 

                    while (reader.Read())
                    {
                        Contravvenzione c = new Contravvenzione();

                        c.NumeroVerbale = (int)reader["NumeroVerbale"];
                        c.Data = (DateTime)reader["Data"];
                        c.Luogo = (string)reader["Luogo"];
                        c.TargaVeicolo = (string)reader["Veicolo"];
                        c.MatricolaVigile = (int)reader["Vigile"];

                        contravvenzioni.Add(c);
                    }
                    connection.Close();
                }
                
                return contravvenzioni;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"errore connessione al DB. Messaggio: {ex.Message}");
                return contravvenzioni;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"errore! Messaggio: {ex.Message}");
                return contravvenzioni;
            }
            finally
            {
                if (connection != null) //se ero entrato nel try, e quindi aperto la connessione...
                {
                    connection.Close(); //... chiudi la connessione. chiusura di sicurezza, che abbia dovuto fare il catch o no
                }
            }
            

        }

        public List<Contravvenzione> GetByVeicoloId(string id)
        {
            List<Contravvenzione> multeVeicolo = new List<Contravvenzione>();
            SqlConnection connection = null;
            try
            {

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();             
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Contravvenzione where Veicolo = @t";
                    command.Parameters.AddWithValue("@t", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Contravvenzione c = new Contravvenzione();

                        c.NumeroVerbale = (int)reader["NumeroVerbale"];
                        c.Data = (DateTime)reader["Data"];
                        c.Luogo = (string)reader["Luogo"];
                        c.TargaVeicolo = (string)reader["Veicolo"];
                        c.MatricolaVigile = (int)reader["Vigile"];

                        multeVeicolo.Add(c);
                    }
                    connection.Close();
                }
                if (multeVeicolo.Count == 0)
                {
                    throw new EmptyListException();
                }
                return multeVeicolo;
            }
            catch (EmptyListException ex)
            {
                Console.WriteLine(ex.Message);
                return multeVeicolo;
            }
            

            finally
            {
                if (connection != null)
                {
                    connection.Close(); 
                }
            }

        }

        public List<Contravvenzione> GetByVigileId(int id)
        {
            List<Contravvenzione> multeVigile = new List<Contravvenzione>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();            
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Contravvenzione where Vigile = @t";
                command.Parameters.AddWithValue("@t", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contravvenzione c = new Contravvenzione();

                    c.NumeroVerbale = (int)reader["NumeroVerbale"];
                    c.Data = (DateTime)reader["Data"];
                    c.Luogo = (string)reader["Luogo"];
                    c.TargaVeicolo = (string)reader["Veicolo"];
                    c.MatricolaVigile = (int)reader["Vigile"];

                    multeVigile.Add(c);
                }
                connection.Close();
            }
            return multeVigile;
        }


        //public Veicolo GetByTarga(string targa)
        //{
        //    Automobile auto = new Automobile();
        //    Motociclo moto = new Motociclo();



        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "select * from Veicolo where Targa = @t";
        //        command.Parameters.AddWithValue("@t", targa);

        //        SqlDataReader reader = command.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            string tipoVeicolo = (string)reader["Tipo"];

        //            if (tipoVeicolo == "Automobile")
        //            {
        //                auto.Potenza = (double)reader["Potenza"];
        //            }
        //            else if (tipoVeicolo == "Motociclo")
        //            {
        //                moto.NumeroTelaio = (string)reader["NumeroTelaio"];

        //            }

        //        }
        //        connection.Close();

        //        if (moto.NumeroTelaio == null)
        //        {
        //            auto.Targa = targa;
        //            return auto;
        //        }
        //        else 
        //        {
        //            moto.Targa = targa;
        //            return moto;
        //        }

        //    }

        //}
    }
}
