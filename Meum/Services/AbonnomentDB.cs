using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MeumLibrary.Model;

namespace Meum.Services
{
    public class AbonnomentDB : IAbonnomentDB
    {
        private const string ConnectionString = @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Abonnoment Create(Abonnoment newItem)
        {
            string query =
                "Insert Into Abonnoment (AbonnomentNr, AbonnomentNavn, Pris, Løbetid, Beskrivelse) values(@AbonnomentNr, @AbonnomentNavn, @Pris, @Løbetid, @Beskrivelse)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@AbonnomentNr", newItem.AbonnomentNr);
                cmd.Parameters.AddWithValue("@AbonnomentNavn", newItem.AbonnomentNavn);
                cmd.Parameters.AddWithValue("@Pris", newItem.Pris);
                cmd.Parameters.AddWithValue("@Løbetid", newItem.Løbetid);
                cmd.Parameters.AddWithValue("@Beskrivelse", newItem.Beskrivelse);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }

        public Abonnoment Delete(int id)
        {
            Abonnoment deletedAbonnoment = GetById(id);

            string query = "Delete From Abonnoment Where Id=@ID";

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

                return deletedAbonnoment;
            }
        }

        public List<Abonnoment> GetAll()
        {
            List<Abonnoment> liste = new List<Abonnoment>();

            string query = "Select * From Abonnoment";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Abonnoment a = ReadAbonnoment(reader);
                    liste.Add(a);
                }
            }

            return liste;
        }

        public Abonnoment GetById(int id)
        {
            string query = "Select * from Abonnoment where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Abonnoment a = ReadAbonnoment(reader);
                    return a;
                }
            }

            return null;
        }

        public Abonnoment Modify(Abonnoment modifiedItem)
        {
            string query =
                "Update Abonnoment set AbonnomentNr=@AbonnomentNr, AbonnomentNavn=@AbonnomentNavn, Pris=@Pris, Løbetid=@Løbetid, Beskrivelse=@Beskrivelse where Id=@UpdateId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@AbonnomentNr", modifiedItem.AbonnomentNr);
                cmd.Parameters.AddWithValue("@AbonnomentNavn", modifiedItem.AbonnomentNavn);
                cmd.Parameters.AddWithValue("@Pris", modifiedItem.Pris);
                cmd.Parameters.AddWithValue("@Løbetid", modifiedItem.Løbetid);
                cmd.Parameters.AddWithValue("@Beskrivelse", modifiedItem.Beskrivelse);
                cmd.Parameters.AddWithValue("@UpdateId", modifiedItem.Id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedItem;
            }
        }

        private Abonnoment FindLastInserted()
        {
            string query = "Select Top 1 * From Abonnoment Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Abonnoment a = ReadAbonnoment(reader);
                    return a;
                }
            }

            return null;
        }

        private Abonnoment ReadAbonnoment(SqlDataReader reader)
        {
            Abonnoment a = new Abonnoment();
            a.Id = reader.GetInt32(0);
            a.AbonnomentNr = reader.GetInt32(1);
            a.AbonnomentNavn = reader.GetString(2);
            a.Pris = reader.GetInt32(3);
            a.Løbetid = reader.GetInt32(4);
            a.Beskrivelse = reader.GetString(5);
            return a;
        }
    }
}
