using MeumLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Meum.Services
{
    public class KundeDB : IKundeDB
    {

        private const string ConnectionString = @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Kunde Create(Kunde newItem)
        {
            string query =
                "Insert Into Kunde (Fornavn, Efternavn, TelefonNr, Email, Addresse, AbonnomentNr, Nyhedsbrev) values(@Fornavn, @Efternavn, @TelefonNr, @Email, @Addresse, @AbonnomentNr, @Nyhedsbrev)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Fornavn", newItem.ForNavn);
                cmd.Parameters.AddWithValue("@Efternavn", newItem.EfterNavn);
                cmd.Parameters.AddWithValue("@TelefonNr", newItem.TelefonNr);
                cmd.Parameters.AddWithValue("@Email", newItem.EMail);
                cmd.Parameters.AddWithValue("@Addresse", newItem.Addresse);
                cmd.Parameters.AddWithValue("@AbonnomentNr", newItem.AbonnomentNr);
                cmd.Parameters.AddWithValue("@Nyhedsbrev", newItem.Nyhedsbrev);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }

        public Kunde Delete(int id)
        {
            Kunde deletedKunde = GetById(id);

            string query = "Delete From Kunde Where Id=@ID";

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

                return deletedKunde;
            }
        }

        public List<Kunde> GetAll()
        {
            List<Kunde> liste = new List<Kunde>();

            string query = "Select * From Kunde";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Kunde k = ReadKunde(reader);
                    liste.Add(k);
                }
            }

            return liste;
        }

        public Kunde GetById(int id)
        {
            string query = "Select * from Kunde where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Kunde k = ReadKunde(reader);
                    return k;
                }
            }

            return null;
        }

        public Kunde Modify(Kunde modifiedItem)
        {
            string query =
                "Update Kunde set ForNavn=@ForNavn, EfterNavn=@EfterNavn, TelefonNr=@TelefonNr, Email=@Email, Addresse=@Addresse, AbonnomentNr=@AbonnomentNr, Nyhedsbrev=@Nyhedsbrev where Id=@UpdateId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ForNavn", modifiedItem.ForNavn);
                cmd.Parameters.AddWithValue("@EfterNavn", modifiedItem.EfterNavn);
                cmd.Parameters.AddWithValue("@TelefonNr", modifiedItem.TelefonNr);
                cmd.Parameters.AddWithValue("@Email", modifiedItem.EMail);
                cmd.Parameters.AddWithValue("@Addresse", modifiedItem.Addresse);
                cmd.Parameters.AddWithValue("@AbonnomentNr", modifiedItem.AbonnomentNr);
                cmd.Parameters.AddWithValue("@Nyhedsbrev", modifiedItem.Nyhedsbrev);
                cmd.Parameters.AddWithValue("@UpdateId", modifiedItem.Id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedItem;
            }
        }

        private Kunde FindLastInserted()
        {
            string query = "Select Top 1 * From Kunde Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Kunde k = ReadKunde(reader);
                    return k;
                }
            }

            return null;
        }

        private Kunde ReadKunde(SqlDataReader reader)
        {
            Kunde k = new Kunde();
            k.Id = reader.GetInt32(0);
            k.ForNavn = reader.GetString(1);
            k.EfterNavn= reader.GetString(2);
            k.TelefonNr = reader.GetInt32(3);
            k.EMail = reader.GetString(4);
            k.Addresse = reader.GetString(5);
            k.AbonnomentNr = reader.GetInt32(6);
            k.Nyhedsbrev = reader.GetString(7);

            return k;
        }
    }
}
