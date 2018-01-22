using System.Collections.Generic;
using System.Linq;
using Kruchy.Core.Mapowanie;
using Kruchy.Uzytkownicy.Repositories;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    class UprawnieniaService : IUprawnieniaService
    {
        private readonly IList<IDefiniowaneUprawnienia> definiowaneUprawnienia;
        private readonly IUprawnienieUzytkownikaRepository uprawnienieUzytkownikaRepository;

        public UprawnieniaService(
            IList<IDefiniowaneUprawnienia> definiowaneUprawnienia,
            IUprawnienieUzytkownikaRepository uprawnienieUzytkownikaRepository)
        {
            this.definiowaneUprawnienia = definiowaneUprawnienia;
            this.uprawnienieUzytkownikaRepository = uprawnienieUzytkownikaRepository;
        }

        public bool SprawdzCzyPosiada(int uzytkownikID, string uprawnienie)
        {
            return uprawnienieUzytkownikaRepository
                .PosiadaWgUzytkownikaUprawnienia(
                    uzytkownikID,
                    uprawnienie);
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
