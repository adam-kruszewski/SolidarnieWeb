using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Repositories.Impl
{
    class UzytkownikRepository : NHibernateRepository<Uzytkownik>, IUzytkownikRepository
    {
        public UzytkownikRepository(IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}