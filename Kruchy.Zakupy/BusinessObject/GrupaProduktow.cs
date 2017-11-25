using System.Collections.Generic;
using System.Linq;

namespace Kruchy.Zakupy.BusinessObject
{
    class GrupaProduktow
    {
        public string Nazwa { get; set; }

        public IList<Produkt> Pozycje { get; set; }

        public int? MinimalneIlosci
        {
            get
            {
                return SzukajMinimalnychIlosciWNazwie();
            }
        }

        public GrupaProduktow()
        {
            Pozycje = new List<Produkt>();
        }

        public GrupaProduktow(GrupaProduktow grupa)
            : this()
        {
            Nazwa = grupa.Nazwa;
            foreach (var pozycja in grupa.Pozycje)
                Pozycje.Add(pozycja.Klonuj());
        }

        private int? SzukajMinimalnychIlosciWNazwie()
        {
            string miedzyNawiasami = SzukajAdnotacjiWNawiasie();
            if (miedzyNawiasami == null || !miedzyNawiasami.ToLower().Contains("min"))
                return null;

            return SzukajLiczbyWTekscie(miedzyNawiasami);
        }

        private int? SzukajLiczbyWTekscie(string miedzyNawiasami)
        {
            bool wLiczbie = false;
            int wynik = 0;
            foreach (char akt in miedzyNawiasami)
            {
                if (char.IsDigit(akt))
                {
                    wLiczbie = true;

                    var wartoscCyfry = (int)akt - (int)'0';
                    wynik = 10 * wynik + wartoscCyfry;
                }
                else
                {
                    if (wLiczbie)
                        return wynik;
                }
            }
            return null;
        }

        private string SzukajAdnotacjiWNawiasie()
        {
            int pozNawiasOtwierajacy = Nazwa.IndexOf('(');
            if (pozNawiasOtwierajacy >= 0)
            {
                var pozNawiasZamykajacy = Nazwa.IndexOf(')', pozNawiasOtwierajacy + 1);
                if (pozNawiasZamykajacy < 0)
                    return null;
                return Nazwa.Substring(
                    pozNawiasOtwierajacy,
                    pozNawiasZamykajacy - pozNawiasOtwierajacy - 1);
            }
            return null;
        }

        public bool IstniejePozycjaZPodanaIloscia()
        {
            return Pozycje.Any(o => JestPodanaIlosc(o));
        }

        public int LiczbaPozycji()
        {
            var zIlosciami = Pozycje.Where(o => JestPodanaIlosc(o));
            return zIlosciami.Sum(o => o.Ilosc.Value);
        }

        private static bool JestPodanaIlosc(Produkt o)
        {
            return o.Ilosc.HasValue && o.Ilosc > 0;
        }
    }
}
