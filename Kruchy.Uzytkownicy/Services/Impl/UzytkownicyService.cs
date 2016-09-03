using System.Collections.Generic;
using Kruchy.NHibernate.Provider;
using Kruchy.Uzytkownicy.Domain;

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

        public IList<Uzytkownik> SzukajWszystkich()
        {
            var sesja = sessionProvider.DajSesje();
            return sesja.QueryOver<Uzytkownik>().List();
        }
    }
}