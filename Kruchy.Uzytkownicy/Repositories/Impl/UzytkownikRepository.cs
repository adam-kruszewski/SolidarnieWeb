using System.Linq;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using NHibernate.Criterion;

namespace Kruchy.Uzytkownicy.Repositories.Impl
{
    class UzytkownikRepository : NHibernateRepository<Uzytkownik>, IUzytkownikRepository
    {
        public UzytkownikRepository(IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public Uzytkownik SzukajWgNazwy(string nazwa)
        {
            return
                Session
                    .CreateCriteria<Uzytkownik>()
                    .Add(Restrictions.Eq("Nazwa", nazwa).IgnoreCase())
                    .List<Uzytkownik>()
                    .SingleOrDefault();
        }
    }
}