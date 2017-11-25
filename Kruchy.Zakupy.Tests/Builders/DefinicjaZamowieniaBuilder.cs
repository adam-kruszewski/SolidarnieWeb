using System;
using Kruchy.Testy.Buildery;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Tests.Builders
{
    class DefinicjaZamowieniaBuilder : NHibernateBuilder<DefinicjaZamowienia>
    {
        public DefinicjaZamowieniaBuilder ZNazwa(string nazwa)
        {
            Obiekt.Nazwa = nazwa;
            return this;
        }

        public DefinicjaZamowieniaBuilder ZCzasemKoncaZamawiania(DateTime czas)
        {
            Obiekt.CzasKoncaZamawiania = czas;
            return this;
        }

        public DefinicjaZamowieniaBuilder ZPlikiem(byte[] plik)
        {
            Obiekt.Plik = plik;
            return this;
        }
    }
}