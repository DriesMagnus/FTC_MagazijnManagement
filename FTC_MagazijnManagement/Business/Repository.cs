using System.Collections.Generic;
using System.Linq;
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
            var maxId = (from Entity e in Items select e.Id).Concat(new[] {0}).Max(); //yes Dries 5HEad

            return maxId + 1;
        }
    }
}