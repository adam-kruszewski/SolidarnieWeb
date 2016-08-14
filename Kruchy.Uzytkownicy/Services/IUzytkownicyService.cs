using System.Collections.Generic;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Services
{
    public interface IUzytkownicyService
    {
        Uzytkownik Dodaj(DodanieUzytkownikaRequest request);

        IList<Uzytkownik> SzukajWszystkich();
    }
}