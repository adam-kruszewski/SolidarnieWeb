using System.Collections.Generic;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Repositories
{
    interface IUprawnienieUzytkownikaRepository
        : INHibernateRepository<UprawnienieUzytkownika>
    {
        bool PosiadaWgUzytkownikaUprawnienia(int uzytkownikID, string uprawnienie);

        IList<UprawnienieUzytkownika> SzukajWgUzytkownika(int uzytkownikID);
    }
}
