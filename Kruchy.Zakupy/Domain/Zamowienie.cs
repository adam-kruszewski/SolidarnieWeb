using System;
using System.Collections.Generic;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Zakupy.Domain
{
    public class Zamowienie
    {
        public virtual int ID { get; set; }

        public virtual int UzytkownikID { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }

        public virtual DateTime DataOstatniejAktualizacji { get; set; }

        public virtual DefinicjaZamowienia Definicja { get; set; }

        public virtual int DefinicjaID { get; set; }

        public virtual ISet<PozycjaZamawiana> Pozycje { get; set; }

        public Zamowienie()
        {
            Pozycje = new HashSet<PozycjaZamawiana>();
        }
    }
}
