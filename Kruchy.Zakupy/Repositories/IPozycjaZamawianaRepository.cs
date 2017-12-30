using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Repositories
{
    interface IPozycjaZamawianaRepository : INHibernateRepository<PozycjaZamawiana>
    {
        IList<PozycjaZamawiana> SzukajWgDefinicjiUzytkownika(
            int definicjaID,
            int uzytkownikID);
    }
}
