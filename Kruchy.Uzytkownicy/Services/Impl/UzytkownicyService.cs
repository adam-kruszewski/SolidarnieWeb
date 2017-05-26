using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        private readonly NHibernateRepository<Uzytkownik> repository;

        public UzytkownicyService(
            NHibernateRepository<Uzytkownik> repository)
        {
            this.repository = repository;
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
            var nowy = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                Haslo = request.Haslo
            };

            return repository.Save(nowy);
        }

        public bool Zmien(ModyfikacjaUzytkownikaRequest request)
        {
            var uzytkownik = repository.Get(request.ID);

            uzytkownik.Nazwa = request.Nazwa;
            uzytkownik.Email = request.Email;

            repository.Update(uzytkownik);
            repository.Flush();
            return true;
        }
    }
}