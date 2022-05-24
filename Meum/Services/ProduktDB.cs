using MeumLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Meum.Services
{
    public class ProduktDB : IProduktDB
    {
        private const string ConnectionString =
            @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Produkt Create(Produkt newItem)
        {
            string query =
                "Insert into Produkt (ProduktNavn, Beskrivelse, VareNummer, Pris, Image) values(@ProduktNavn, @Beskrivelse, @VareNummer, @Pris, @Image)";

            //string filename = "C:\\Users\\Danie\\source\\repos\\Meum\\Meum\\Images\\";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ProduktNavn", newItem.ProduktNavn);
                cmd.Parameters.AddWithValue("@Beskrivelse", newItem.Beskrivelse);
                cmd.Parameters.AddWithValue("@VareNummer", newItem.VareNummer);
                cmd.Parameters.AddWithValue("@Pris", newItem.Pris);
                cmd.Parameters.AddWithValue("@Image", newItem.Image);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }
        public Produkt Delete(int id)
        {
            Produkt deletedProdukt = GetByID(id);

            string query = "Delete From Produkt Where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Error, did not delete");
                }

                return deletedProdukt;
            }
        }

        public List<Produkt> GetAll()
        {
            List<Produkt> liste = new List<Produkt>();

            string query = "Select * From Produkt";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Produkt p = ReadProdukt(reader);
                    liste.Add(p);
                }
            }

            return liste;
        }

        public Produkt GetByID(int id)
        {
            string query = "Select * from Produkt where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Produkt p = ReadProdukt(reader);
                    return p;
                }
            }

            return null;
        }

        public Produkt Modify(Produkt modifiedItem)
        {
            string query =
                "Update Produkt set ProduktNavn=@ProduktNavn, Beskrivelse=@Beskrivelse, VareNummer=@VareNummer, Pris=@Pris, Image=@Image where Id=@UpdateId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ProduktNavn", modifiedItem.ProduktNavn);
                cmd.Parameters.AddWithValue("@Beskrivelse", modifiedItem.Beskrivelse);
                cmd.Parameters.AddWithValue("@VareNummer", modifiedItem.VareNummer);
                cmd.Parameters.AddWithValue("@Pris", modifiedItem.Pris);
                cmd.Parameters.AddWithValue("@Image", modifiedItem.Image);
                cmd.Parameters.AddWithValue("@UpdateId", modifiedItem.Id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                { 
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedItem;
            }
        }

        private Produkt FindLastInserted()
        {
            string query = "Select Top 1 * From Produkt Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Produkt p = ReadProdukt(reader);
                    return p;
                }
            }

            return null;
        }

        private Produkt ReadProdukt(SqlDataReader reader)
        {
            Produkt p = new Produkt();
            p.Id = reader.GetInt32(0);
            p.ProduktNavn = reader.GetString(1);
            p.Beskrivelse = reader.GetString(2);
            p.VareNummer = reader.GetInt32(3);
            p.Pris = reader.GetInt32(4);
            p.Image = reader.GetString(5);

            return p;
        }
    }
}
