using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
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
                    if (ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                            .ConnectionStrings.ConnectionStrings.Count ==
                        0) throw new Exception("Connection string not configured");

                    _connectionString = ConfigurationManager
                        .OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).ConnectionStrings
                        .ConnectionStrings["Database"].ConnectionString;
                }

                return _connectionString;
            }
        }

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
        internal static List<Levering> GetLeveringenFromDb()
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            return leveringmapper.GetLeveringen();
        }

        internal static void AddLeveringToDb(Levering levering, int apparaatid)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.AddLevering(levering, apparaatid);
        }

        internal static void UpdateLeveringToDb(Levering levering)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.UpdateLevering(levering);
        }

        internal static void RemoveLeveringFromDb(Levering levering)
        {
            var leveringmapper = new LeveringMapper(ConnectionString);
            leveringmapper.RemoveLevering(levering);
        }
        #endregion
    }
}