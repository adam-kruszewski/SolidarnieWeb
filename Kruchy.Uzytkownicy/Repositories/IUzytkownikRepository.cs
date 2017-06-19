using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Repositories
{
    interface IUzytkownikRepository :INHibernateRepository<Uzytkownik>
    {
        Uzytkownik SzukajWgNazwy(string nazwa);
    }
}