using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTC_MagazijnManagement.Business
{
    class GebruikersRepository
    {
        private static List<Gebruiker> _items = new List<Gebruiker>();

        internal static List<Gebruiker> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
            }
        }

        internal static Gebruiker GetItem(int id) => Items.Find(l => l.Id == id);
      
        internal static Int32 GetNextId()
        {
            return Items.Count == 0 ? 1 : Items.Max(l => l.Id) + 1;
        }

        internal static void AddItem(Gebruiker lid)
        {
            Items.Add(lid);
            Persistence.Controller.AddGebruiker(lid);
        }

        internal static void Load(List<Gebruiker> items)
        {
            if (items != null)
                Items = items;
            else
                Items = new List<Gebruiker>();
        }
    }
}