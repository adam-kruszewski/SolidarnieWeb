using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Views;

namespace Kruchy.Uzytkownicy.Services
{
    public interface IUzytkownicyService
    {
        UzytkownikView DajWgID(int id);

        ZalogowanyUzytkownikView SzukajWgNazwyHasla(string nazwa, string haslo);

        Uzytkownik Dodaj(
            DodanieUzytkownikaRequest request,
            IWalidacjaListener listener);
        bool Zmien(
            ModyfikacjaUzytkownikaRequest request,
            IWalidacjaListener listener);
        IList<Uzytkownik> SzukajWszystkich();
    }
}