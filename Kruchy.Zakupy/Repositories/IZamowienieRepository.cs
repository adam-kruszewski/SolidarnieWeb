using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories
{
    interface IZamowienieRepository : INHibernateRepository<Zamowienie>
    {
        Zamowienie SzukajWgUzytkownikaDefinicji(int uzytkownikID, int definicjaID);
    }
}
