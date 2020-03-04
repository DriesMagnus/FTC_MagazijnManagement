using System.Collections.Generic;
using FTC_MagazijnManagement.Business;

namespace FTC_MagazijnManagement.Business
{
    internal abstract class Repository<T> where T : Entity
    {
        internal static List<T> Items;

        internal abstract void AddItem(T entity);

        internal abstract T GetItem(int id);

        internal abstract List<T> GetAll();

        internal abstract void RemoveItem(int id);

        internal abstract void Load(List<T> list);

        internal abstract T UpdateItem(T entity);

        internal int GetNextId()
        {
            var maxId = 0;
            foreach (Entity e in Items)
                if (e.Id > maxId)
                    maxId = e.Id;
            return maxId + 1;
        }
    }
}