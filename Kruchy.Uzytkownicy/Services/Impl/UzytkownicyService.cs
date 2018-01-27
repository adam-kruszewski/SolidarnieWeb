using System.Collections.Generic;
using System.Linq;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Repositories;
using Kruchy.Uzytkownicy.Views;
using Kruchy.Uzytkownicy.Walidacja;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        private readonly IUzytkownikRepository repository;
        private readonly IWalidacjaUzytkownika walidacjaUzytkownika;
        private readonly ISkrotHaslaService skrotHasla;

        public UzytkownicyService(
            IUzytkownikRepository repository,
            IWalidacjaUzytkownika walidacjaUzytkownika,
            ISkrotHaslaService skrotHasla)
        {
            this.repository = repository;
            this.walidacjaUzytkownika = walidacjaUzytkownika;
            this.skrotHasla = skrotHasla;
        }

        public UzytkownikView DajWgID(int id)
        {
            var uzytkownik = repository.Get(id);

            var view = new UzytkownikView
            {
                ID = id,
                Email = uzytkownik.Email,
                Nazwa = uzytkownik.Nazwa
            };

            return view;
        }

        public IList<UzytkownikView> SzukajWszystkich()
        {
            return repository.GetAll().Select(o => new UzytkownikView
            {
                ID = o.ID,
                Nazwa = o.Nazwa,
                Email = o.Email
            }).ToList();
        }

        public UzytkownikView SzukajWgNazwyHasla(
            string nazwa,
            string haslo)
        {
            var uzytkownik = repository.SzukajWgNazwy(nazwa);
            if (uzytkownik == null || uzytkownik.SkrotHasla != skrotHasla.Wylicz(haslo))
                return null;

            return new UzytkownikView
            {
                ID = uzytkownik.ID,
                Nazwa = uzytkownik.Nazwa,
                Email = uzytkownik.Email
            };
        }

        public int? Dodaj(
            DodanieUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            var uzytkownik = DajUzytkownikaWgRequestDodawania(request);
            if (!walidacjaUzytkownika.Waliduj(uzytkownik, listener))
                return null;
            if (!ZgodneHasla(request, listener))
                return null;

            var nowy = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                SkrotHasla = skrotHasla.Wylicz(request.Haslo)
            };

            return repository.Save(nowy).ID;
        }

        private Uzytkownik DajUzytkownikaWgRequestDodawania(
            DodanieUzytkownikaRequest request)
        {
            return new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                ID = default(int),
            };
        }

        public bool Zmien(
            ModyfikacjaUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            var uzytkownik = repository.Get(request.ID);

            uzytkownik.Nazwa = request.Nazwa;
            uzytkownik.Email = request.Email;
            uzytkownik.SkrotHasla = skrotHasla.Wylicz(request.Haslo);
            if (!walidacjaUzytkownika.Waliduj(uzytkownik, listener))
                return false;
            if (!ZgodneHasla(request, listener))
                return false;

            repository.Update(uzytkownik);
            repository.Flush();
            return true;
        }

        private bool ZgodneHasla(
            DodanieUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            return
                new ZbiorRegulWalidacji()
                    .DodajReguleBledu(() =>
                    request.Haslo != request.PowtorzenieHasla, "Niezgodne hasła", "Haslo")
                        .Wykonaj(listener);
        }
    }
}