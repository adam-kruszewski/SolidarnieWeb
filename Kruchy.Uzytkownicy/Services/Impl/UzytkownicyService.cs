using System.Collections.Generic;
using Kruchy.NHibernate.Provider;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        private static List<Uzytkownik> wszystkie = new List<Uzytkownik>();

        private readonly IHibernateSessionProvider sessionProvider;

        public UzytkownicyService(
            IHibernateSessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public UzytkownikView DajWgID(int id)
        {
            var sesja = sessionProvider.DajSesje();
            var uzytkwownik = sesja.Get<Uzytkownik>(id);

            var view = new UzytkownikView
            {
                Email = uzytkwownik.Email,
                Nazwa = uzytkwownik.Nazwa
            };

            return view;
        }

        public IList<Uzytkownik> SzukajWszystkich()
        {
            var sesja = sessionProvider.DajSesje();
            return sesja.QueryOver<Uzytkownik>().List();
        }

        public Uzytkownik Dodaj(DodanieUzytkownikaRequest request)
        {
            var sesja = sessionProvider.DajSesje();

            var nowy = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                Haslo = request.Haslo
            };

            sesja.Save(nowy);
            return nowy;
        }

        public bool Zmien(ModyfikacjaUzytkownikaRequest request)
        {
            using (var sesja = sessionProvider.DajSesje())
            {
                var uzytkownik = sesja.Get<Uzytkownik>(request.ID);

                uzytkownik.Nazwa = request.Nazwa;
                uzytkownik.Email = request.Email;

                sesja.Update(uzytkownik);
                sesja.Flush();
                return true;
            }
        }
    }
}