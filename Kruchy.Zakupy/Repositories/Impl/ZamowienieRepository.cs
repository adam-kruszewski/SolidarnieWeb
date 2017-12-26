using System.Linq;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Zakupy.Domain;
using NHibernate.Criterion;

namespace Kruchy.Zakupy.Repositories.Impl
{
    class ZamowienieRepository
        : NHibernateRepository<Zamowienie>
            , IZamowienieRepository
    {
        public ZamowienieRepository(IHibernateSessionProvider sessionProvider)
             : base(sessionProvider)
        {
        }

        public override Zamowienie Save(Zamowienie o)
        {
            o.Definicja = Session.Load<DefinicjaZamowienia>(o.DefinicjaID);
            o.Uzytkownik = Session.Load<Uzytkownik>(o.UzytkownikID);
            return base.Save(o);
        }

        public Zamowienie SzukajWgUzytkownikaDefinicji(int uzytkownikID, int definicjaID)
        {
            return
                Session.CreateCriteria<Zamowienie>()
                    .Add(Restrictions.Eq("Definicja.ID", definicjaID))
                    .Add(Restrictions.Eq("Uzytkownik.ID", uzytkownikID))
                    .SetMaxResults(1)
                    .List<Zamowienie>()
                    .FirstOrDefault();
                
            //throw new System.NotImplementedException();
        }
    }
}
