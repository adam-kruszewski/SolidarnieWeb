using System.Collections.Generic;
using System.Linq;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class UzytkownicyService : IUzytkownicyService
    {
        private static List<Uzytkownik> wszystkie = new List<Uzytkownik>();

        public Uzytkownik Dodaj(DodanieUzytkownikaRequest request)
        {
            var nowy = new Uzytkownik
            {
                Nazwa = request.Nazwa,
                Email = request.Email,
                Haslo = request.Haslo
            };

            if (wszystkie.Any())
                nowy.ID = wszystkie.Max(o => o.ID) + 1;
            else
                nowy.ID = 1;

            wszystkie.Add(nowy);

            return nowy;
        }

        public IList<Uzytkownik> SzukajWszystkich()
        {
            return wszystkie;
        }
    }
}
