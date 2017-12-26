using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories.Impl
{
    class ProduktRepository : NHibernateRepository<Produkt>, IProduktRepository
    {
        public ProduktRepository(IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {

        }
    }
}
