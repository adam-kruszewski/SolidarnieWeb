using System.Collections.Generic;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Zakupy.Domain;
using NHibernate.Criterion;

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

        public IList<PozycjaZamawiana> SzukajWgDefinicjiUzytkownika(
            int definicjaID,
            int uzytkownikID)
        {
            //Zamowienie zam = null;

            return
            Session.QueryOver<PozycjaZamawiana>()
                .JoinQueryOver(pz => pz.Zamowienie)
                    .Where(o => o.Uzytkownik.ID == uzytkownikID)
                .Clone()
                .JoinQueryOver(pz => pz.Produkt)
                    .JoinQueryOver(pr => pr.GrupaProduktow)
                        .Where(gp => gp.DefinicjaZamowienia.ID == definicjaID)
                .List();

            //.JoinAlias<Zamowienie>(pz => pz.Zamowienie, () => zam);

            //throw new System.NotImplementedException();
            //return
            //    Session.QueryOver<PozycjaZamawiana>()
            //        .JoinQueryOver(pz => pz.Produkt)
            //        .JoinQueryOver(produkt => produkt.GrupaProduktow)
            //        .Where(p => p.DefinicjaZamowienia.ID == definicjaID)
            //            .List();
        }
    }
}