namespace SolidarnieWebApp.Models
{
    public class KomorkaTabeliModel
    {
        public dynamic Wartosc { get; set; }

        public object Wiersz { get; set; }

        public int NumerWiersza { get; set; }

        public string NazwaWlasciwosci { get; set; }

        public KomorkaTabeliModel(
            object wiersz,
            string nazwaWlasciwosci,
            int numerWiersza)
        {
            Wiersz = wiersz;
            NazwaWlasciwosci = nazwaWlasciwosci;
            NumerWiersza = numerWiersza;
        }
    }
}