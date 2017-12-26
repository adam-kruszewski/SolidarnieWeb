using System;
using System.Collections.Generic;
using Kruchy.Core.Mapowanie;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;

namespace Kruchy.Zakupy.Services.Impl
{
    class ZamawianieService : IZamawianieService
    {
        private readonly IZamowienieRepository zamowienieRepository;
        private readonly IProduktRepository produktRepository;

        public ZamawianieService(
            IZamowienieRepository zamowienieRepository,
            IProduktRepository produktRepository)
        {
            this.zamowienieRepository = zamowienieRepository;
            this.produktRepository = produktRepository;
        }

        public bool Zamow(
            int definicjaID,
            int uzytkownikID,
            IEnumerable<ZamawianaPozycja> pozycje)
        {
            var zamowienie = zamowienieRepository.SzukajWgUzytkownikaDefinicji(uzytkownikID, definicjaID);

            if (zamowienie == null)
            {
                zamowienie = new Domain.Zamowienie()
                {
                    UzytkownikID = uzytkownikID,
                    DefinicjaID = definicjaID,
                    DataOstatniejAktualizacji = DateTime.Now,
                };
                DodajPozycje(zamowienie, pozycje);
                zamowienieRepository.Save(zamowienie);
            }
            else
            {
                zamowienieRepository.Update(zamowienie);
            }

            return true;
        }

        private void DodajPozycje(
            Zamowienie zamowienie,
            IEnumerable<ZamawianaPozycja> pozycje)
        {
            foreach (var p in pozycje)
            {
                var pozycjaDomain = DajPozycjeZamawiana(p);
                pozycjaDomain.Zamowienie = zamowienie;
                zamowienie.Pozycje.Add(pozycjaDomain);
            }
        }

        private PozycjaZamawiana DajPozycjeZamawiana(ZamawianaPozycja p)
        {
            var wynik = new PozycjaZamawiana();
            wynik.Produkt = produktRepository.Load(p.ProduktID);
            wynik.Ilosc = p.Ilosc;
            return wynik;
        }
    }
}