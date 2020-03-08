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

            return ApparaatRepository.Items.Find(x => x.Id == levering.ApparaatId);

        }

        internal List<Levering> GetLeveringenFromDb()
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

        internal void AddLeveringToDb(Levering levering, int apparaatid)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO levering (Apparaat_Id, Aantal, Locatie)" +
                " VALUES (@apparaat_id, @aantal, @locatie)"
                , connection);

            command.Parameters.AddWithValue("apparaat_id", apparaatid);
            command.Parameters.AddWithValue("aantal", levering.Aantal);
            command.Parameters.AddWithValue("locatie", levering.Locatie);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdateLeveringInDb(Levering levering)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE levering SET Locatie = @locatie, Aantal = @aantal, Apparaat_Id = @apparaat_id" +
                " WHERE Apparaat_Id=@apparaat_id"
                , connection);
            command.Parameters.AddWithValue("locatie", levering.Locatie);
            command.Parameters.AddWithValue("apparaat_id", levering.ApparaatId);
            command.Parameters.AddWithValue("aantal", levering.Aantal);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void RemoveLeveringInDb(Levering levering)
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