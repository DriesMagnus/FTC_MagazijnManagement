using System;
using System.Collections.Generic;
using System.Linq;

namespace FTC_MagazijnManagement.Business
{
    public class Controller
    {
        private readonly ApparaatRepository _apparaatRepository = new ApparaatRepository();

        public Controller()
        {
            _apparaatRepository.Load(Persistence.Controller.GetApparatenFromDb());
            List<Levering> leveringen = Persistence.Controller.GetLeveringenFromDb();
            foreach (var apparaat in _apparaatRepository.GetAll())
            {
                apparaat.Load(leveringen.Where(x => x.ApparaatId == apparaat.Id).ToList());
            }
        }

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

        public Apparaat UpdateApparaat(Apparaat apparaat)
        {
            var toUpdate = _apparaatRepository.GetItem(apparaat.Id);
            if (toUpdate != null)
            {
                return _apparaatRepository.UpdateItem(toUpdate);
            }
            else
            {
                throw new Exception("Apparaat met id: " + apparaat.Id + " niet gevonden.");
            }
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
            return Persistence.Controller.GetLeveringenFromDb();
        }

        public Levering AddLevering(int apparaatid, string locatie, int aantal)
        {
            var toAdd = new Levering(apparaatid, locatie, aantal);
            var item = _apparaatRepository.GetItem(apparaatid);
            item._leveringen.Add(toAdd);
            Persistence.Controller.AddLeveringToDb(toAdd, apparaatid);
            return toAdd;
        }

        public Levering UpdateLevering(Levering levering)
        {
            Persistence.Controller.UpdateLeveringInDb(levering);
            return levering;
        }

        public void RemoveLevering(Levering levering)
        {
            Persistence.Controller.RemoveLeveringInDb(levering);
        }
        #endregion
    }
}