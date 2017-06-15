using Kruchy.Testy.Buildery;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Tests.Builders
{
    class UzytkownikBuilder : NHibernateBuilder<Uzytkownik>
    {
        public UzytkownikBuilder ZNazwa(string nazwa)
        {
            Obiekt.Nazwa = nazwa;
            return this;
        }
    }
}