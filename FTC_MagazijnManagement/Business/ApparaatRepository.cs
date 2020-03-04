using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    internal class ApparaatRepository : Repository<Apparaat>
    {
        internal override void AddItem(Apparaat apparaat)
        {
            Items.Add(apparaat);
        }

        internal override Apparaat GetItem(int id)
        {
            return Items.Find(apparaat => apparaat.Id == id);
        }

        internal override List<Apparaat> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            Apparaat item = GetItem(id);

            Items.Remove(item);
            Persistence.Controller.RemoveApparaatFromDb(item);
            foreach (var levering in item._leveringen)
            {
                Persistence.Controller.RemoveLeveringFromDb(levering);
            }
        }

        internal override Apparaat UpdateItem(Apparaat apparaat)
        {
            Apparaat item = GetItem(apparaat.Id);
            item._leveringen = apparaat._leveringen;
            item.Naam = apparaat.Naam;
            item.Type = apparaat.Type;

            Persistence.Controller.UpdateApparaatToDb(item);
            foreach (var levering in item._leveringen)
            {
                Persistence.Controller.UpdateLeveringToDb(levering);
            }

            return item;
        }

        internal override void Load(List<Apparaat> list)
        {
            Items = list ?? new List<Apparaat>();
        }
    }
}