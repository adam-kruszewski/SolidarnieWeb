using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Repositories
{
    interface IUzytkownikRepository :INHibernateRepository<Uzytkownik>
    {
        bool IstniejeWgNazwy(string nazwa);
    }
}
