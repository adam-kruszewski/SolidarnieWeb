using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories.Impl
{
    class DefinicjaZamowieniaRepository
        : NHibernateRepository<DefinicjaZamowienia>
            , IDefinicjaZamowieniaRepository
    {
        public DefinicjaZamowieniaRepository(
            IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}