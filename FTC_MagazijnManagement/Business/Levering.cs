namespace FTC_MagazijnManagement.Business
{
    public class Levering
    {
        public int Aantal;

        public int ApparaatId;

        public string Locatie;

        internal Levering(int apparaatId, string locatie, int aantal)
        {
            ApparaatId = apparaatId;
            Locatie = locatie;
            Aantal = aantal;
        }
    }
}