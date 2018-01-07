using System.Collections.Generic;
using System.Linq;
using Kruchy.NHibernate.Extensions;
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

        public IList<PozycjaZamawiana> SzukajWgDefinicjiUzytkownika(
            int definicjaID,
            int uzytkownikID)
        {
            return
            Session.QueryOver<PozycjaZamawiana>()
                .JoinQueryOver(pz => pz.Zamowienie)
                    .Where(o => o.Uzytkownik.ID == uzytkownikID)
                .Clone()
                .JoinQueryOver(pz => pz.Produkt)
                    .JoinQueryOver(pr => pr.GrupaProduktow)
                        .Where(gp => gp.DefinicjaZamowienia.ID == definicjaID)
                .List();
        }

        public IList<ProduktWZamowieniach> SumaZamowienieWgDefinicji(
            int definicjaID)
        {
            var obiekty =
                Session.QueryOver<PozycjaZamawiana>()
                    .JoinQueryOver(pz => pz.Zamowienie)
                    .Where(o => o.Definicja.ID == definicjaID)
                    .SelectList(list =>
                            list.SelectGroup(o => o.Produkt.ID)
                            .SelectSum(o => o.Ilosc))
                    .List<object[]>()
                        .Select(o => o.To<ProduktWZamowieniach>())
                            .ToList();

            return obiekty;
        }

    }
}