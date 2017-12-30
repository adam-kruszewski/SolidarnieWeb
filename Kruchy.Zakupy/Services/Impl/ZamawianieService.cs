using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services.Impl
{
    class ZamawianieService : IZamawianieService
    {
        private readonly IDefinicjeZamowieniaService definicjeService;
        private readonly IZamowienieRepository zamowienieRepository;
        private readonly IProduktRepository produktRepository;
        private readonly IPozycjaZamawianaRepository pozycjeZamawianeRepository;

        public ZamawianieService(
            IDefinicjeZamowieniaService definicjeService,
            IZamowienieRepository zamowienieRepository,
            IProduktRepository produktRepository,
            IPozycjaZamawianaRepository pozycjeZamawianeRepository)
        {
            this.definicjeService = definicjeService;
            this.zamowienieRepository = zamowienieRepository;
            this.produktRepository = produktRepository;
            this.pozycjeZamawianeRepository = pozycjeZamawianeRepository;
        }

        public DefinicjaZamowieniaPelnaView PrzygotujDlaUzytkownika(
            int definicjaID,
            int uzytkownikID)
        {
            var pozycjeZamowione =
                pozycjeZamawianeRepository
                    .SzukajWgDefinicjiUzytkownika(definicjaID, uzytkownikID);

            var definicja = definicjeService.DajWgID(definicjaID);
            var wszystkieProdukty = definicja.GrupyProduktow.SelectMany(o => o.Produkty);

            foreach (var zamowione in pozycjeZamowione)
            {
                wszystkieProdukty.Single(o => o.ID == zamowione.Produkt.ID)
                    .Ilosc = zamowione.Ilosc;
            }

            return definicja;

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
                AktualizujPozycje(zamowienie, pozycje);
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

        private void AktualizujPozycje(
            Zamowienie zamowienie,
            IEnumerable<ZamawianaPozycja> zamawianePozycje)
        {
            zamowienie.Pozycje.Clear();
            DodajPozycje(zamowienie, zamawianePozycje);
        }

        private PozycjaZamawiana SzukajPozycjiWgProduktu(
            Zamowienie zamowienie,
            int produktID)
        {
            return zamowienie.Pozycje.SingleOrDefault(o => o.Produkt.ID == produktID);
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