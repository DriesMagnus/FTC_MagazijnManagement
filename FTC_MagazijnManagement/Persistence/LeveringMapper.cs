using System;
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

        internal Apparaat GetApparaatFromLevering(Levering levering)
        {
            var apparaten = ApparaatRepository.Items;
            Apparaat returnapparaat = null;

            foreach (var apparaat in apparaten)
                if (apparaat._leveringen.Contains(levering))
                    returnapparaat = apparaat;
            return returnapparaat;
        }

        internal List<Levering> GetLeveringen()
        {
            var _leveringen = new List<Levering>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from levering", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var _levering = new Levering(
                    Convert.ToInt32(dataReader["Apparaat_Id"]),
                    Convert.ToString(dataReader["Locatie"]),
                    Convert.ToInt32(dataReader["Aantal"])
                );
                _leveringen.Add(_levering);
            }

            connection.Close();
            return _leveringen;
        }

        internal void AddLevering(Levering levering, int apparaatid)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO levering (Apparaat_Id, Aantal, Locatie)" +
                " VALUES (@apparaat_id, @aantal, locatie)"
                , connection);

            command.Parameters.AddWithValue("apparaat_id", apparaatid);
            command.Parameters.AddWithValue("aantal", levering.Aantal);
            command.Parameters.AddWithValue("locatie", levering.Locatie);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdateLevering(Levering levering)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE levering SET Locatie = @locatie, Aantal = @aantal" +
                " WHERE Apparaat_Id=@apparaat_id"
                , connection);
            command.Parameters.AddWithValue("locatie", levering.Locatie);
            command.Parameters.AddWithValue("apparaat_id", levering.ApparaatId);
            command.Parameters.AddWithValue("aantal", levering.Aantal);

            var apparaat = GetApparaatFromLevering(levering);
            if (apparaat != null)
            {
                var index = command.CommandText.IndexOf("WHERE", StringComparison.Ordinal);
                command.CommandText = command.CommandText.Insert(index - 1, ", Apparaat_id = @apparaat_id");
                command.Parameters.AddWithValue("apparaat_id", apparaat.Id);
            }

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void RemoveLevering(Levering levering)
        {
            var apparaat = GetApparaatFromLevering(levering);
            
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM levering" +
                " WHERE Apparaat_Id=@apparaat_id"
                , connection);

            command.Parameters.AddWithValue("apparaat_id", apparaat.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}