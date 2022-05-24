using MeumLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; // <--- Install package for SQLConnection
using System.Linq;
using System.Threading.Tasks;

namespace Meum.Services
{
    public class BrugerServiceDB : IBrugerServiceDB
    {
        private const string ConnectionString =
            @"Data Source=datamatiker-daniel.database.windows.net;Initial Catalog=daniel-zealand.db;User ID=DanielAdmin;Password=AdminDaniel1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Bruger Create(Bruger newUser)
        {
            string query =
                "Insert into Bruger (Fornavn, Efternavn, TelefonNr, Email, Brugernavn, Adgangskode, Role) values(@Fornavn, @Efternavn, @TelefonNr, @Email, @Brugernavn, @Adgangskode, @Role)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Fornavn", newUser.ForNavn);
                cmd.Parameters.AddWithValue("@Efternavn", newUser.EfterNavn);
                cmd.Parameters.AddWithValue("@TelefonNr", newUser.TelefonNr);
                cmd.Parameters.AddWithValue("@Email", newUser.EMail);
                cmd.Parameters.AddWithValue("@Brugernavn", newUser.BrugerNavn);
                cmd.Parameters.AddWithValue("@Adgangskode", newUser.Adgangskode);
                cmd.Parameters.AddWithValue("@Role", newUser.Role);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Create Unsuccesful");
                }

                return FindLastInserted();
            }
        }

        public Bruger Delete(string userName)
        {
            Bruger deletedUser = GetByBruger(userName);

            string query = "Delete From Bruger Where Brugernavn=@UserName";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@UserName", userName);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Error, did not delete");
                }

                return deletedUser;
            }
        }

        public List<Bruger> GetAll()
        {
            List<Bruger> liste = new List<Bruger>();

            string query = "Select * From Bruger";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bruger u = ReadUser(reader);
                    liste.Add(u);
                }
            }

            return liste;
        }

        public Bruger GetByBruger(string userName)
        {
            string query = "Select * from Bruger where Brugernavn=@UserName";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@UserName", userName);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bruger u = ReadUser(reader);
                    return u;
                }
            }

            return null;
        }

        public Bruger Modify(Bruger modifiedUser)
        {
            string query =
                "Update Bruger set Fornavn=@Fornavn, Efternavn=@Efternavn, TelefonNr=@TelefonNr, Email=@Email, Brugernavn=@Brugernavn, Adgangskode=@Adgangskode, Role=@Role";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Fornavn", modifiedUser.ForNavn);
                cmd.Parameters.AddWithValue("@Efternavn", modifiedUser.EfterNavn);
                cmd.Parameters.AddWithValue("@TelefonNr", modifiedUser.TelefonNr);
                cmd.Parameters.AddWithValue("@Email", modifiedUser.EMail);
                cmd.Parameters.AddWithValue("@Brugernavn", modifiedUser.BrugerNavn);
                cmd.Parameters.AddWithValue("@Adgangskode", modifiedUser.Adgangskode);
                cmd.Parameters.AddWithValue("@Role", modifiedUser.Role);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Could not update with new ID");
                }

                return modifiedUser;
            }
        }

        private Bruger FindLastInserted()
        {
            string query = "Select Top 1 * From Bruger Order By Id DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Bruger u = ReadUser(reader);
                    return u;
                }
            }

            return null;
        }

        private Bruger ReadUser(SqlDataReader reader)
        {
            Bruger u = new Bruger();
            u.Id = reader.GetInt32(0);
            u.ForNavn = reader.GetString(1);
            u.EfterNavn = reader.GetString(2);
            u.TelefonNr = reader.GetInt32(3);
            u.EMail = reader.GetString(4);
            u.BrugerNavn = reader.GetString(5);
            u.Adgangskode = reader.GetString(6);
            u.Role = reader.GetString(7);

            return u;
        }
    }
}