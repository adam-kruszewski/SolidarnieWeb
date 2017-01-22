using System.Collections.Generic;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services
{
    public interface IUzytkownicyService
    {
        UzytkownikView DajWgID(int id);

        Uzytkownik Dodaj(DodanieUzytkownikaRequest request);
        bool Zmien(ModyfikacjaUzytkownikaRequest request);
        IList<Uzytkownik> SzukajWszystkich();
    }
}