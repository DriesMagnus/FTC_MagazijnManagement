using System;
using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    public class Controller
    {
        private readonly ApparaatRepository _apparaatRepository;

        public Controller()
        {
            _apparaatRepository.Load(Persistence.Controller.GetApparatenFromDb());
        }
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

        public Levering AddLevering(int apparaatid, string locatie, int aantal)
        {
            var toAdd = new Levering(apparaatid, locatie, aantal);
            var item = _apparaatRepository.GetItem(apparaatid);
            item._leveringen.Add(toAdd);
            _apparaatRepository.UpdateItem(item);
            return toAdd;
        }
    }
}