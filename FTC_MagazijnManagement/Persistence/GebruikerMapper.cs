using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTC_MagazijnManagement.Business;
using MySql.Data.MySqlClient;

namespace FTC_MagazijnManagement.Persistence
{
    class GebruikerMapper
    {
        private string _conString = "";
        internal GebruikerMapper(string connectionString)
        {
            _conString = connectionString;
        }

        internal void AddGebruikerToDb(Gebruiker gebruiker)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO gebruiker (id, username, password)" +
                " VALUES (@id, @usernaam, @paswoord)"
                , con);
            cmd.Parameters.AddWithValue("id", gebruiker.Id);
            cmd.Parameters.AddWithValue("usernaam", gebruiker.Gebruikersnaam);
            cmd.Parameters.AddWithValue("paswoord", gebruiker.Paswoord);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal List<Gebruiker> GetGebruikersFromDb()
        {
            List<Gebruiker> _gebruikers = new List<Gebruiker>();
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                "SELECT * FROM gebruiker"
                , con);
            
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Gebruiker _gebruiker = new Gebruiker(
                    Convert.ToInt32(dr["id"]),
                    Convert.ToString(dr["username"]),
                    Convert.ToString(dr["password"])
                );
                _gebruikers.Add(_gebruiker);
            }
            con.Close();
            return _gebruikers;
        }
    }
}