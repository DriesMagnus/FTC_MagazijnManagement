﻿using System.Collections.Generic;

namespace FTC_MagazijnManagement.Business
{
    public class Apparaat : Entity
    {
        /// <summary>
        /// De reden waarom we deze publiek maken is wegens we de gegevens moeten updaten in de database.
        /// </summary>
        public List<Levering> _leveringen;

        public string Naam;

        public string Type;

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

        public int TotaleVoorraad()
        {
            var voorraad = 0;
            foreach (var levering in _leveringen) voorraad += levering.Aantal;

            return voorraad;
        }

      
    }
}