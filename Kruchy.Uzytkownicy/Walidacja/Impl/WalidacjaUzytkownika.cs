﻿using System;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Repositories;

namespace Kruchy.Uzytkownicy.Walidacja.Impl
{
    class WalidacjaUzytkownika : IWalidacjaUzytkownika
    {
        private readonly IUzytkownikRepository uzytkownikRepository;

        public WalidacjaUzytkownika(
            IUzytkownikRepository uzytkownikRepository)
        {
            this.uzytkownikRepository = uzytkownikRepository;
        }

        public bool Waliduj(Uzytkownik uzytkownik, IWalidacjaListener listener)
        {
            return
                new ZbiorRegulWalidacji()
                    .DodajReguleBledu(
                        () => IstniejeWgNazwy(uzytkownik.Nazwa),
                        "Użytkownik o takiej nazwie już istnieje",
                        "Nazwa")
                    .Wykonaj(listener);
        }

        private bool IstniejeWgNazwy(string nazwa)
        {
            return uzytkownikRepository.IstniejeWgNazwy(nazwa);
        }
    }
}