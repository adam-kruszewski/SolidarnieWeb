namespace SolidarnieWebApp.Models
{
    public class KomorkaTabeliModel
    {
        public dynamic Wartosc { get; set; }

        public object Wiersz { get; set; }

        public string NazwaWlasciwosci { get; set; }

        public KomorkaTabeliModel(object wiersz, string nazwaWlasciwosci)
        {
            Wiersz = wiersz;
            NazwaWlasciwosci = nazwaWlasciwosci;
        }
    }
}