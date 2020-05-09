using System;
using System.Collections.Generic;
using System.Linq;

namespace FTC_MagazijnManagement.Business
{
    public class Controller
    {
        private static readonly ApparaatRepository _apparaatRepository = new ApparaatRepository();
        private static bool _loaded = false;
        
        public Controller()
        {
            if (!_loaded)
            {
                List<Levering> _leveringen = new List<Levering>();
                _apparaatRepository.Load(Persistence.Controller.GetApparatenFromDb());
                _leveringen = Persistence.Controller.GetAllLeveringenFromDb();
                GebruikersRepository.Load(Persistence.Controller.GetGebruikers());
                foreach (var apparaat in _apparaatRepository.GetAll())
                {
                    apparaat.Load(_leveringen.Where(x => x.ApparaatId == apparaat.Id).ToList());
                }

                _loaded = true;
            }
        }

        #region Gebruiker
        public Gebruiker CurrentUser { get; private set; }

        public bool Aanmelden(string gebruikersnaam, string paswoord)
        {
            var gebruikers = GebruikersRepository.Items;

            var gebruiker = gebruikers.Find(x =>
                x.Gebruikersnaam.Equals(gebruikersnaam, StringComparison.CurrentCultureIgnoreCase));
            if (gebruiker == null) return false;
            var aangemeld = gebruiker.Aanmelden(paswoord);
            if (aangemeld) CurrentUser = gebruiker;
            return aangemeld;
        }

        public void Afmelden()
        {
            CurrentUser = null;
        }

        public Gebruiker Registreer(string gebruikersnaam, string paswoord)
        {
            var gList = GebruikersRepository.Items;

            var gebruiker = gList.Find(g => g.Gebruikersnaam.Equals(gebruikersnaam,
                StringComparison.CurrentCultureIgnoreCase));

            if (gebruiker != null)

            {
                throw new ArgumentException("Deze gebruikersnaam bestaat reeds");
            }

            var id = GebruikersRepository.GetNextId();

            gebruiker = new Gebruiker(id, gebruikersnaam, paswoord);

            GebruikersRepository.AddItem(gebruiker);

            return gebruiker;
        }
        #endregion

        #region Apparaat
        public Apparaat GetApparaat(int id)
        {
            var toGet = _apparaatRepository.GetItem(id);
            if (toGet != null)
            {
                return toGet;
            }
            else
            {
                throw new Exception("apparaat met id: " + id + " niet gevonden.");
            }
        }
        public Apparaat AddApparaat(string naam, string type)
        {
            var toAdd = new Apparaat(_apparaatRepository.GetNextId(), naam, type);
            _apparaatRepository.AddItem(toAdd);
            return toAdd;
        }

        public Apparaat UpdateApparaat(int id, string newName, string newType)
        {
            var toUpdate = _apparaatRepository.GetItem(id);
            toUpdate.Naam = newName;
            toUpdate.Type = newType;

            return _apparaatRepository.UpdateItem(toUpdate);
        }

        public void RemoveApparaat(int id)
        {
            var toRemove = _apparaatRepository.GetItem(id);
            if (toRemove != null)
            {
                _apparaatRepository.RemoveItem(id);
            }
            else
            {
                throw new Exception("apparaat with id: " + id + " not found.");
            }
        }

        public List<Apparaat> GetApparaatList()
        {
            return _apparaatRepository.GetAll();
        }
        #endregion

        #region Levering
        public List<Levering> GetAllLeveringen(Apparaat apparaat)
        {
            return apparaat._leveringen;
        }


        public Levering GetLevering(int apparaatid, string locatie)
        {
            var leveringen = GetAllLeveringen(GetApparaat(apparaatid));
            return leveringen.Find(levering => levering.Locatie == locatie);
        }

        public Levering AddLevering(int apparaatid, string locatie, int aantal)
        {
            var toAdd = new Levering(apparaatid, locatie, aantal);
            var item = _apparaatRepository.GetItem(apparaatid);
            item._leveringen.Add(toAdd);
            Persistence.Controller.AddLeveringToDb(toAdd, apparaatid);
            return toAdd;
        }

        public Levering UpdateLevering(int apparaatid, int aantal, string locatie)
        {
            var toUpdate = GetLevering(apparaatid, locatie);
            toUpdate.Aantal = aantal;
            toUpdate.Locatie = locatie;
            Persistence.Controller.UpdateLeveringInDb(toUpdate);
            return toUpdate;
        }


        public void RemoveLevering(int apparaatid, string locatie)
        {
            var levering = GetLevering(apparaatid, locatie);
            Persistence.Controller.RemoveLeveringInDb(levering);

            GetApparaat(apparaatid)._leveringen.Remove(levering); //bruh
        }
        #endregion
    }
}