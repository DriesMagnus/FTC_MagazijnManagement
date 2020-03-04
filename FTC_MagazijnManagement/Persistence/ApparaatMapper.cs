using System;
using System.Collections.Generic;
using FTC_MagazijnManagement.Business;
using MySql.Data.MySqlClient;

namespace FTC_MagazijnManagement.Persistence
{
    internal class ApparaatMapper
    {
        private readonly string _connectionString = "";

        internal ApparaatMapper(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        internal List<Apparaat> GetApparaatFromDb()
        {
            var _apparaten = new List<Apparaat>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * from apparaat", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var _apparaat = new Apparaat(
                    Convert.ToInt32(dataReader["Id"]),
                    Convert.ToString(dataReader["Naam"]),
                    Convert.ToString(dataReader["Type"])
                );
                _apparaten.Add(_apparaat);
            }

            connection.Close();
            return _apparaten;
        }

        internal void AddApparaatToDb(Apparaat apparaat)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO apparaat (Id, Naam, Type)" +
                " VALUES (@id, @naam, @type)"
                , connection);

            command.Parameters.AddWithValue("id", apparaat.Id);
            command.Parameters.AddWithValue("naam", apparaat.Naam);
            command.Parameters.AddWithValue("type", apparaat.Type);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdateApparaatInDb(Apparaat apparaat)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE apparaat SET Naam = @naam, Type = @type" +
                " WHERE Id=@id"
                , connection);

            command.Parameters.AddWithValue("id", apparaat.Id);
            command.Parameters.AddWithValue("naam", apparaat.Naam);
            command.Parameters.AddWithValue("type", apparaat.Type);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void RemoveApparaatInDb(Apparaat apparaat)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM apparaat" +
                " WHERE Id=@id"
                , connection);

            command.Parameters.AddWithValue("id", apparaat.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}