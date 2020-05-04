using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagement.Persistence
{
    internal class Controller
    {
        private static string _connectionString = "";

        private static string ConnectionString
        {
            get
            {
                if (_connectionString == "")
                {
                    if (ConfigurationManager.ConnectionStrings.Count ==
                        0) throw new Exception("Connection string not configured");

                    _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                }

                return _connectionString;
            }
        }

        #region Gebruiker
        internal static List<Gebruiker> GetGebruikers()
        {
            GebruikerMapper mapper = new GebruikerMapper(ConnectionString);
            return mapper.GetGebruikersFromDb();
        }

        internal static void AddGebruiker(Gebruiker gebruiker)
        {
            GebruikerMapper mapper = new GebruikerMapper(ConnectionString);
            mapper.AddGebruikerToDb(gebruiker);
        }
        #endregion

        #region Apparaat
        internal static List<Apparaat> GetApparatenFromDb()
        {
            var apparaatmapper = new ApparaatMapper(ConnectionString);
            return apparaatmapper.GetApparaatFromDb();
        }

        internal static void AddApparaatToDb(Apparaat apparaat)
        {
            var apparaatmapper = new ApparaatMapper(ConnectionString);
            apparaatmapper.AddApparaatToDb(apparaat);
        }

        internal static void UpdateApparaatToDb(Apparaat apparaat)
        {
            var apparaatmapper = new ApparaatMapper(ConnectionString);
            apparaatmapper.UpdateApparaatInDb(apparaat);
        }

        internal static void RemoveApparaatFromDb(Apparaat apparaat)
        {
            var apparaatmapper = new ApparaatMapper(ConnectionString);
            apparaatmapper.RemoveApparaatInDb(apparaat);
        }
        #endregion

        #region Levering

        internal static List<Levering> GetAllLeveringenFromDb()
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            return leveringmapper.GetAllLeveringenFromDb();
        }
        
        internal static List<Levering> GetLeveringenFromDb(int apparaatid)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            return leveringmapper.GetLeveringenFromDb(apparaatid);
        }

        internal static void AddLeveringToDb(Levering levering, int apparaatid)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.AddLeveringToDb(levering, apparaatid);
        }

        internal static void UpdateLeveringInDb(Levering levering)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.UpdateLeveringInDb(levering);
        }

        internal static void RemoveLeveringInDb(Levering levering)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.RemoveLeveringInDb(levering);
        }
        #endregion
    }
}