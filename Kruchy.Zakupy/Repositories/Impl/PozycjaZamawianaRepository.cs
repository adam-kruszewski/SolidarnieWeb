using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories.Impl
{
    class PozycjaZamawianaRepository
         : NHibernateRepository<PozycjaZamawiana>
         , IPozycjaZamawianaRepository
    {
        public PozycjaZamawianaRepository(IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {

        }
    }
}