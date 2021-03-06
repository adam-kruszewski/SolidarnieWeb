﻿using System.Collections.Generic;
using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Repositories
{
    interface IPozycjaZamawianaRepository : INHibernateRepository<PozycjaZamawiana>
    {
        IList<IloscUzytkownika> SzukajIlosciWgProduktu(int produktID);

        IList<PozycjaZamawiana> SzukajWgDefinicjiUzytkownika(
            int definicjaID,
            int uzytkownikID);

        IList<ProduktWZamowieniach> SumaZamowienieWgDefinicji(
            int definicjaID);
    }

    public class ProduktWZamowieniach
    {
        public int ProduktID { get; set; }

        public int Ilosc { get; set; }
    }
}
