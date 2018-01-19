using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Core.Mapowanie;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    class UprawnieniaService : IUprawnieniaService
    {
        private readonly IList<IDefiniowaneUprawnienia> definiowaneUprawnienia;

        public UprawnieniaService(
            IList<IDefiniowaneUprawnienia> definiowaneUprawnienia)
        {
            this.definiowaneUprawnienia = definiowaneUprawnienia;
        }

        public bool SprawdzCzyPosiada(int uzytkownikID, string uprawnienie)
        {
            return false;
        }

        public IList<DefiniowanieUprawnieniaUzytkownikaView> SzukajWgUzytkownika(
            int uzytkownikID)
        {
            return SzukajUprawnien()
                .Select(o => DajDefiniowaneUprawnienieUzytkownika(o, uzytkownikID))
                    .ToList();
        }

        private DefiniowanieUprawnieniaUzytkownikaView DajDefiniowaneUprawnienieUzytkownika(
            Uprawnienie uprawnienie,
            int uzytkownikID)
        {
            var wynik = uprawnienie.Mapuj<DefiniowanieUprawnieniaUzytkownikaView>();

            wynik.Posiada = SprawdzCzyPosiada(uzytkownikID, uprawnienie.Nazwa);
            return wynik;
        }

        private IList<Uprawnienie> SzukajUprawnien()
        {
            return definiowaneUprawnienia.SelectMany(o => o.Daj()).ToList();
        }

    }
}
