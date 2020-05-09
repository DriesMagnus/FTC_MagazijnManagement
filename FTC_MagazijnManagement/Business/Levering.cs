namespace FTC_MagazijnManagement.Business
{
    public class Levering
    {
        public int Aantal { get; set; }

        public int ApparaatId;

        public string Locatie { get; set; }

        internal Levering(int apparaatId, string locatie, int aantal)
        {
            ApparaatId = apparaatId;
            Locatie = locatie;
            Aantal = aantal;
        }



        public void wijzigLevering(int aantal, string locatie)
        {
            Locatie = locatie;
            Aantal = aantal;
        }





    }
}