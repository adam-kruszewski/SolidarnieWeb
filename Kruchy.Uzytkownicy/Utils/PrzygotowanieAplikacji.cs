using System;
using Kruchy.Core.Aspects;
using Kruchy.Core.Konfiguracja;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Repositories;
using Kruchy.Uzytkownicy.Services;

namespace Kruchy.Uzytkownicy.Utils
{
    [Transakcyjna]
    class PrzygotowanieAplikacji : IPrzygotowanieAplikacji
    {
        private readonly ISkrotHaslaService skrotService;
        private readonly IUzytkownikRepository uzytkownikRepository;
        private readonly IUzytkownicyService uzytkownicyService;

        public PrzygotowanieAplikacji(
            ISkrotHaslaService skrotService,
            IUzytkownikRepository uzytkownikRepository,
            IUzytkownicyService uzytkownicyService)
        {
            this.skrotService = skrotService;
            this.uzytkownikRepository = uzytkownikRepository;
            this.uzytkownicyService = uzytkownicyService;
        }

        public void PrzygotujPoAktualizacjiBazy()
        {
            var uzytkownicy = uzytkownikRepository.GetAll();

            //if (uzytkownicy.Count == 0)
            //{
            //    DodanieUzytkownikaRequest request = new DodanieUzytkownikaRequest
            //    {
            //        Nazwa = "adam",
            //        Haslo = "adam",
            //        Email = "kruchy.jr@wp.pl",
            //        PowtorzenieHasla = "adam"
            //    };
            //    uzytkownicyService.Dodaj(request, new Walidacja());
            //}

            //foreach (var u in uzytkownicy)
            //{
            //    if (!string.IsNullOrEmpty(u.Haslo) && string.IsNullOrEmpty(u.SkrotHasla))
            //    {
            //        u.SkrotHasla = skrotService.Wylicz(u.Haslo);
            //        uzytkownikRepository.Update(u);
            //    }
            //}
            //uzytkownikRepository.Flush();
        }

        public void PrzygotujPrzedAktualizacjaBazy()
        {
        }

        private class Walidacja : IWalidacjaListener
        {
            public void Blad(string komunikat, string wlasciwosc)
            {
            }

            public void Ostrzezenie(string komunikat, string wlasciwosc)
            {
            }
        }
    }
}
