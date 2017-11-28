using System.Collections.Generic;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Repositories
{
    interface IDefinicjaZamowieniaRepository
        : INHibernateRepository<DefinicjaZamowienia>
    {
    }
}
