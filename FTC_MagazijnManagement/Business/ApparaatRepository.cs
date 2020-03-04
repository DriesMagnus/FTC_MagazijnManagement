using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    internal class ApparaatRepository : Repository<Apparaat>
    {
        internal override void AddItem(Apparaat entity)
        {
            Items.Add(entity);
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
            //Persistence.Controller.RemoveApparaatInDb(item);
            //foreach (var levering in item.GetLeveringen())
            //{
            //    Persistence.Controller.RemoveLeveringInDb(levering);
            //}
        }

        internal override Apparaat UpdateItem(Apparaat apparaat)
        {
            Apparaat item = GetItem(apparaat.Id);
            //verander alle waarden van item.waarde naar apparaat.waarde
            //zet item.levering naar de nieuwe levering lijst
            //voor elke levering in item.levering doe persistence.controller.UpdateLevering
            return item;
        }

        internal override void Load(List<Apparaat> list)
        {
            Items = list ?? new List<Apparaat>();
        }
    }
}