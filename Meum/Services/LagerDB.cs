using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public class LagerDB : ILagerDB
    {
        private const string ConnectionString =
            @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Lager> GetAll()
        {
            List<Lager> liste = new List<Lager>();

            string query = "Select * From Lager";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lager l = ReadLager(reader);
                    liste.Add(l);
                }
            }

            return liste;
        }

        public Lager GetByID(int ID)
        {
            string query = "Select * from Lager where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lager l = ReadLager(reader);
                    return l;
                }
            }

            return null;
        }

        public Lager Create(Lager newItem)
        {
            string query =
                "Insert into Lager (VareNummer, Navn, Beskrivelse, Antal) values(@VareNummer, @Navn, @Beskrivelse, @Antal)";
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@VareNummer", newItem.VareNummer);
                cmd.Parameters.AddWithValue("@Navn", newItem.Navn);
                cmd.Parameters.AddWithValue("@Beskrivelse", newItem.Beskrivelse);
                cmd.Parameters.AddWithValue("@Antal", newItem.Antal);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }

        public Lager Delete(int ID)
        {
            Lager deletedLager = GetByID(ID);

            string query = "Delete From Lager Where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", ID);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Error, did not delete");
                }

                return deletedLager;
            }
        }

        public Lager Modify(Lager modifiedItem)
        {
            string query =
                "Update Lager set VareNummer=@Varenummer, Navn=@Navn, Beskrivelse=@Beskrivelse, Antal=@Antal where Id=@UpdateId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Varenummer", modifiedItem.VareNummer);
                cmd.Parameters.AddWithValue("@Navn", modifiedItem.Navn);
                cmd.Parameters.AddWithValue("@Beskrivelse", modifiedItem.Beskrivelse);
                cmd.Parameters.AddWithValue("@Antal", modifiedItem.Antal);
                cmd.Parameters.AddWithValue("@UpdateId", modifiedItem.Id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedItem;
            }
        }

        private Lager FindLastInserted()
        {
            string query = "Select Top 1 * From Lager Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Lager l = ReadLager(reader);
                    return l;
                }
            }

            return null;
        }

        private Lager ReadLager(SqlDataReader reader)
        {
            Lager l = new Lager();
            l.Id = reader.GetInt32(0);
            l.VareNummer = reader.GetInt32(1);
            l.Navn = reader.GetString(2);
            l.Beskrivelse = reader.GetString(3); 
            l.Antal = reader.GetInt32(4);

            return l;
        }
    }
}
