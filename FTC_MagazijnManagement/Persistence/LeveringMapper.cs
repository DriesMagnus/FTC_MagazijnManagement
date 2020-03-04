using System.Collections.Generic;
using FTC_MagazijnManagement.Business;
using MySql.Data.MySqlClient;

namespace FTC_MagazijnManagement.Persistence
{
    internal class LeveringMapper
    {

        private readonly string _connectionString = "";

        internal LeveringMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Apparaat GetApparaatFromLevering(Levering levering)
        {
            var apparaten = new List<Apparaat>();
            apparaten = ApparaatRepository.Items;


            Apparaat returnapparaat = null;

            foreach (var apparaat in apparaten)
                if (apparaat._leveringen.Contains(levering))
                    returnapparaat = apparaat;
            return returnapparaat;
        }
        
        public void UpdateLevering(Levering levering)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE levering SET Locatie = @locatie, Aantal = @aantal, Apparaat_Id = @apparaat_id" + 
                " WHERE Id=@id"
                , connection);
            command.Parameters.AddWithValue("locatie", levering.Locatie);
            command.Parameters.AddWithValue("id", levering.ApparaatId);
            command.Parameters.AddWithValue("aantal", levering.Aantal);
            
            var apparaat = GetApparaatFromLevering(levering);
            if (apparaat != null) command.Parameters.AddWithValue("apparaat_id", apparaat.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}