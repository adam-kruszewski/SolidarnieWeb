using System.Collections.Generic;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;

namespace Kruchy.Uzytkownicy.Repositories.Impl
{
    class UprawnienieUzytkownikaRepository
        : NHibernateRepository<UprawnienieUzytkownika>
            , IUprawnienieUzytkownikaRepository
    {
        public UprawnienieUzytkownikaRepository(
            IHibernateSessionProvider sessionProvider)
            : base(sessionProvider)
        {

        }

        public bool PosiadaWgUzytkownikaUprawnienia(
            int uzytkownikID,
            string uprawnienie)
        {
            return
                Session
                    .QueryOver<UprawnienieUzytkownika>()
                        .Where(o => o.Uzytkownik.ID == uzytkownikID)
                        .Where(o => o.Uprawnienie == uprawnienie)
                        .Where(o => o.DataDo == null)
                        .RowCount() > 0;
        }

        public IList<UprawnienieUzytkownika> SzukajWgUzytkownika(int uzytkownikID)
        {
            return Session
                .QueryOver<UprawnienieUzytkownika>()
                    .Where(o => o.Uzytkownik.ID == uzytkownikID)
                    .Where(o => o.DataDo == null)
                        .List<UprawnienieUzytkownika>();
        }
    }
}