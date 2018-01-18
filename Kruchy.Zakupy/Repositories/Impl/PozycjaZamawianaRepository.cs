using System.Collections.Generic;
using System.Linq;
using Kruchy.NHibernate.Extensions;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.Repositories;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Views;

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

        public IList<IloscUzytkownika> SzukajIlosciWgProduktu(int produktID)
        {
            PozycjaZamawiana pozycjaZamawianaAlias = null;
            Zamowienie zamowienie = null;
            Uzytkownik uzytkownikAlias = null;

            var pozycjeZamawiane =
                Session.QueryOver<PozycjaZamawiana>(() => pozycjaZamawianaAlias)
                    .Where(pz => pz.Produkt.ID == produktID)
                    .JoinQueryOver(pz => pz.Zamowienie, () => zamowienie)
                    .JoinQueryOver(z => z.Uzytkownik, () => uzytkownikAlias)
                    .SelectList(
                        list => list
                            .Select(() => zamowienie.Uzytkownik.ID)
                            .Select(() => uzytkownikAlias.Nazwa)
                            .Select(() => pozycjaZamawianaAlias.Ilosc))
                    .List<object[]>()
                    .Select(o => new IloscUzytkownika((int)o[0], (string)o[1], (int)o[2]));
            return pozycjeZamawiane.ToList();
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