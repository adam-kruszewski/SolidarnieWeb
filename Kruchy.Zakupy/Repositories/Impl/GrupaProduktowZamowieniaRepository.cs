using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories.Impl
{
    class GrupaProduktowZamowieniaRepository
        : NHibernateRepository<GrupaProduktowZamowienia>,
            IGrupaProduktowZamowieniaRepository
    {
        public GrupaProduktowZamowieniaRepository(
            IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}
