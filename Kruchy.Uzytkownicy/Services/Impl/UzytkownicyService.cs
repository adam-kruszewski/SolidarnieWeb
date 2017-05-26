using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        private static List<Uzytkownik> wszystkie = new List<Uzytkownik>();

        private readonly IHibernateSessionProvider sessionProvider;
        private readonly NHibernateRepository<Uzytkownik> repository;

        public UzytkownicyService(
            IHibernateSessionProvider sessionProvider,
            NHibernateRepository<Uzytkownik> repository)
        {
            this.sessionProvider = sessionProvider;
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
            var sesja = sessionProvider.DajSesje();
            return sesja.QueryOver<Uzytkownik>().List();
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