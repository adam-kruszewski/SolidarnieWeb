using System;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Walidacja.Impl
{
    class WalidacjaUzytkownika : IWalidacjaUzytkownika
    {
        public bool Waliduj(Uzytkownik uzytkownik, IWalidacjaListener listener)
        {
            return true;
        }
    }
}