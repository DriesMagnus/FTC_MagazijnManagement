using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    public class Apparaat : Entity
    {
        public List<Levering> _leveringen;

        public int LeveringAmount
        {
            get { return _leveringen.Count; }
        }

        public string Naam { get; set; }

        public string Type { get; set; }

        internal Apparaat(int id, string naam, string type) : base(id)
        {
            Naam = naam;
            Type = type;
            _leveringen = new List<Levering>();
        }

        public Levering NieuweLevering(string locatie, int aantal = 0)
        {
            var levering = new Levering(Id, locatie, aantal);
            _leveringen.Add(levering);

            return levering;
        }

        public void Load(List<Levering> lijst)
        {
            _leveringen.AddRange(lijst);
        }

        public int TotaleVoorraad()
        {
            var voorraad = 0;
            foreach (var levering in _leveringen) voorraad += levering.Aantal;

            return voorraad;
        }

        public override string ToString()
        {
            return $"Totale voorraad: {TotaleVoorraad()}";
        }
    }
}