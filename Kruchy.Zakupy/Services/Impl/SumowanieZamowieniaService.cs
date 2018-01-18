using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services.Impl
{
    class SumowanieZamowieniaService : ISumowanieZamowieniaService
    {
        private readonly IPozycjaZamawianaRepository pozycjaZamawianaRepository;
        private readonly IProduktRepository produktRepository;

        public SumowanieZamowieniaService(
            IPozycjaZamawianaRepository pozycjaZamawianaRepository,
            IProduktRepository produktRepository)
        {
            this.pozycjaZamawianaRepository = pozycjaZamawianaRepository;
            this.produktRepository = produktRepository;
        }

        public ZsumowaneZamowienie Sumuj(int definicjaID)
        {
            var zamowionePozycje = pozycjaZamawianaRepository.SumaZamowienieWgDefinicji(definicjaID);

            var podsumowanie =
                zamowionePozycje
                    .Select(o => new PozycjaZSumowana(o, produktRepository.Get(o.ProduktID)))
                        .ToList();

            var wynik = new ZsumowaneZamowienie();

            foreach (var grupa in podsumowanie.GroupBy(o => o.Produkt.GrupaProduktow.ID))
            {
                wynik.ZamowioneGrupy.Add(PrzygotujGrupe(grupa));
            }

            return wynik;
        }

        private ZamowionaGrupa PrzygotujGrupe(IGrouping<int, PozycjaZSumowana> grupa)
        {
            var pierwszyProdukt = grupa.First();

            var grupaProduktow = pierwszyProdukt.Produkt.GrupaProduktow;
            var zamowionaGrupa = new ZamowionaGrupa(grupaProduktow);
            zamowionaGrupa.SumaIlosci = grupa.Sum(o => o.ProduktWZamowieniach.Ilosc);

            zamowionaGrupa.ZamowioneProdukty.AddRange(
                PrzygotujPodsumowanieProduktow(grupa));

            return zamowionaGrupa;
        }

        private IEnumerable<ZamowionyProdukt> PrzygotujPodsumowanieProduktow(
            IGrouping<int, PozycjaZSumowana> grupa)
        {
            return grupa.Select(o => DajZamowionyProdukt(o));
        }

        private ZamowionyProdukt DajZamowionyProdukt(PozycjaZSumowana o)
        {
            var zamowionyProdukt = new ZamowionyProdukt();
            zamowionyProdukt.Nazwa = o.Produkt.Nazwa;
            zamowionyProdukt.Cena = o.Produkt.Cena;
            zamowionyProdukt.Ilosc = o.ProduktWZamowieniach.Ilosc;
            zamowionyProdukt.ProduktID = o.Produkt.ID;
            zamowionyProdukt.SumaKwot = zamowionyProdukt.Cena * zamowionyProdukt.Ilosc;
            zamowionyProdukt.IlosciUzytkownikow =
                DajIlosciUzytkownikowWgProduktu(o.Produkt.ID).ToList();
            return zamowionyProdukt;
        }

        private IList<IloscUzytkownika> DajIlosciUzytkownikowWgProduktu(
            int produktID)
        {
            return pozycjaZamawianaRepository.SzukajIlosciWgProduktu(produktID);
        }

        private class PozycjaZSumowana
        {
            public ProduktWZamowieniach ProduktWZamowieniach { get; set; }

            public Produkt Produkt { get; set; }

            public PozycjaZSumowana(
                ProduktWZamowieniach produktWZamowieniu,
                Produkt produkt)
            {
                Produkt = produkt;
                ProduktWZamowieniach = produktWZamowieniu;
            }
        }
    }
}