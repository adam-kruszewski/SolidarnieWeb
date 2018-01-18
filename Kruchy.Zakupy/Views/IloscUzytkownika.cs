namespace Kruchy.Zakupy.Views
{
    public class IloscUzytkownika
    {
        public int UzytkownikID { get; set; }

        public int Ilosc { get; set; }

        public string NazwaUzytkownika { get; set; }

        public IloscUzytkownika()
        {

        }

        public IloscUzytkownika(
            int uzytkownikID,
            string nazwaUzytkownika,
            int ilosc)
        {
            UzytkownikID = uzytkownikID;
            NazwaUzytkownika = nazwaUzytkownika;
            Ilosc = ilosc;
        }
    }
}