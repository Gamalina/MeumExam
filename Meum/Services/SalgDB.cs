using MeumLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Meum.Services
{
    public class SalgDB : ISalgDB
    {
        private const string ConnectionString = @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Salg Create(Salg newItem)
        {
            string query =
                "Insert Into Salg (Varenummer, Antal, Date, Shipped) values(@VareNummer, @Antal, @Date, @Shipped)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@VareNummer", newItem.VareNummer);
                cmd.Parameters.AddWithValue("@Antal", newItem.Antal);
                cmd.Parameters.AddWithValue("@Date", newItem.DateTime);
                cmd.Parameters.AddWithValue("@Shipped", newItem.Shipped);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }

        public Salg Delete(int id)
        {
            Salg deletedSalg = GetById(id);

            string query = "Delete From Salg Where Id=@ID";

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

                return deletedSalg;
            }
        }

        public List<Salg> GetAll()
        {
            List<Salg> liste = new List<Salg>();

            string query = "Select * From Salg";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Salg s = ReadSalg(reader);
                    liste.Add(s);
                }
            }

            return liste;
        }

        public Salg GetById(int id)
        {
            string query = "Select * from Salg where Id=@ID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Salg s = ReadSalg(reader);
                    return s;
                }
            }

            return null;
        }

        public Salg Modify(Salg modifiedItem)
        {
            string query =
                "Update Salg set Varenummer=@Varenummer, Antal=@Antal, Date=@Date, Shipped=@Shipped where Id=@UpdateId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Varenummer", modifiedItem.VareNummer);
                cmd.Parameters.AddWithValue("@Antal", modifiedItem.Antal);
                cmd.Parameters.AddWithValue("@Date", modifiedItem.DateTime);
                cmd.Parameters.AddWithValue("@Shipped", modifiedItem.Shipped);
                
                cmd.Parameters.AddWithValue("@UpdateId", modifiedItem.Id);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedItem;
            }
        }

        private Salg FindLastInserted()
        {
            string query = "Select Top 1 * From Salg Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Salg s = ReadSalg(reader);
                    return s;
                }
            }

            return null;
        }

        private Salg ReadSalg(SqlDataReader reader)
        {
            Salg s = new Salg();
            s.Id = reader.GetInt32(0);
            s.VareNummer = reader.GetInt32(1);
            s.Antal = reader.GetInt32(2);
            s.DateTime = reader.GetString(3);
            s.Shipped = reader.GetString(4);
           
            return s;
        }
    }
}
