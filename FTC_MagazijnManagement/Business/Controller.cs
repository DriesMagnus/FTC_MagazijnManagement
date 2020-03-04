using System;
using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    public class Controller
    {
        private readonly ApparaatRepository _apparaatRepository;

        public Controller()
        {
            //_apparaatRepository.Load(Persistence.Controller.GetApparaten());
        }

        public Apparaat AddApparaat(string naam, string type)
        {
            var toAdd = new Apparaat(_apparaatRepository.GetNextId(), naam, type);
            _apparaatRepository.AddItem(toAdd);
            return toAdd;
        }

        public Apparaat Updateapparaat(Apparaat apparaat)
        {
            var toUpdate = _apparaatRepository.GetItem(apparaat.Id);
            if (toUpdate != null)
            {
                return _apparaatRepository.UpdateItem(toUpdate);
            }
            throw new Exception("Apparaat met id: " + apparaat.Id + " niet gevonden.");
        }

        public Apparaat Getapparaat(int id)
        {
            var toGet = _apparaatRepository.GetItem(id);
            if (toGet != null)
                return toGet;
            throw new Exception("apparaat met id: " + id + " niet gevonden.");
        }

        public void Removeapparaat(int id)
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

        public List<Apparaat> GetapparaatList()
        {
            return _apparaatRepository.GetAll();
        }
    }
}