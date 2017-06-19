using System.Collections.Generic;
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

        public UzytkownicyService(
            IUzytkownikRepository repository,
            IWalidacjaUzytkownika walidacjaUzytkownika)
        {
            this.repository = repository;
            this.walidacjaUzytkownika = walidacjaUzytkownika;
        }

        public UzytkownikView DajWgID(int id)
        {
            var uzytkownik = repository.Get(id);

            var view = new UzytkownikView
            {
                Email = uzytkownik.Email,
                Nazwa = uzytkownik.Nazwa
            };

            return view;
        }

        public IList<Uzytkownik> SzukajWszystkich()
        {
            return repository.GetAll();
        }

        public Uzytkownik Dodaj(
            DodanieUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            var uzytkownik = DajUzytkownikaWgRequestDodawania(request);
            if (!walidacjaUzytkownika.Waliduj(uzytkownik, listener))
                return null;

            var nowy = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                Haslo = request.Haslo
            };

            return repository.Save(nowy);
        }

        private Uzytkownik DajUzytkownikaWgRequestDodawania(
            DodanieUzytkownikaRequest request)
        {
            return new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                ID = default(int),
                Haslo = request.Haslo
            };
        }

        public bool Zmien(
            ModyfikacjaUzytkownikaRequest request,
            IWalidacjaListener listener)
        {
            var uzytkownik = repository.Get(request.ID);

            uzytkownik.Nazwa = request.Nazwa;
            uzytkownik.Email = request.Email;
            if (!walidacjaUzytkownika.Waliduj(uzytkownik, listener))
                return false;

            repository.Update(uzytkownik);
            repository.Flush();
            return true;
        }
    }
}