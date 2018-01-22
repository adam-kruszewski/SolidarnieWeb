using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Core.Aspects;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Repositories;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    [Transakcyjna]
    class UprawnieniaUzytkownikaService : IUprawnieniaUzytkownikaService
    {
        private readonly IUprawnienieUzytkownikaRepository uprawnieniaRepository;
        private readonly IUzytkownikRepository uzytkownikRepository;

        public UprawnieniaUzytkownikaService(
            IUprawnienieUzytkownikaRepository uprawnieniaRepository,
            IUzytkownikRepository uzytkownikRepository)
        {
            this.uprawnieniaRepository = uprawnieniaRepository;
            this.uzytkownikRepository = uzytkownikRepository;
        }

        public bool ZapiszUprawnienia(
            int uzytkownikID,
            List<Tuple<string, bool>> uprawnienia)
        {
            var aktualne = uprawnieniaRepository.SzukajWgUzytkownika(uzytkownikID);

            var doUsuniecia = uprawnienia.Where(o => !o.Item2);

            foreach (var uprawnienieDoUsuniecia in doUsuniecia)
                UsunUprawnienie(uprawnienieDoUsuniecia.Item1, aktualne);

            foreach (var uprawnienieDoDodania in uprawnienia.Where(o => o.Item2).Select(o => o.Item1))
            {
                var aktualneUprawnienie =
                    SzukajAktualnegoWgUprawnienia(uprawnienieDoDodania, aktualne);

                if (aktualneUprawnienie == null)
                {
                    var noweUprawnienie = new UprawnienieUzytkownika
                    {
                        Uprawnienie = uprawnienieDoDodania,
                        DataOd = DateTime.Now,
                        Uzytkownik = uzytkownikRepository.Load(uzytkownikID)
                    };
                    uprawnieniaRepository.Save(noweUprawnienie);
                }
            }

            return true;
        }

        private void UsunUprawnienie(
            string uprawnienieDoUsuniecia,
            IList<UprawnienieUzytkownika> aktualne)
        {
            var aktualneUprawnienie =
                SzukajAktualnegoWgUprawnienia(uprawnienieDoUsuniecia, aktualne);

            if (aktualneUprawnienie != null)
            {
                aktualneUprawnienie.DataDo = DateTime.Now;
                uprawnieniaRepository.Update(aktualneUprawnienie);
            }
        }

        private UprawnienieUzytkownika SzukajAktualnegoWgUprawnienia(
            string uprawnienieDoUsuniecia,
            IList<UprawnienieUzytkownika> aktualne)
        {
            return aktualne.SingleOrDefault(o => o.Uprawnienie == uprawnienieDoUsuniecia);
        }
    }
}