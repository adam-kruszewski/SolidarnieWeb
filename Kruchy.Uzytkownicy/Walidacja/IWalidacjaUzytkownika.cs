using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Walidacja
{
    interface IWalidacjaUzytkownika
    {
        bool Waliduj(Uzytkownik uzytkownik, IWalidacjaListener listener);
    }
}