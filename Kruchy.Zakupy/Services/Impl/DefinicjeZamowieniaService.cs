using System;
using System.Collections.Generic;
using System.Linq;
using Kruchy.Core.Aspects;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.BusinessObject;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;
using Kruchy.Zakupy.Views;
using Kruchy.Zakupy.Walidacja;

namespace Kruchy.Zakupy.Services.Impl
{
    [Transakcyjna]
    class DefinicjeZamowieniaService : IDefinicjeZamowieniaService
    {
        private readonly IWalidacjaDefinicjiZamowienia walidacja;
        private readonly IDefinicjaZamowieniaRepository definicjaZamowieniaRepository;
        private readonly IGrupaProduktowZamowieniaRepository grupyRepository;
        private readonly IWczytywaniePlikuZamowieniaService wczytywanieService;

        public DefinicjeZamowieniaService(
            IWalidacjaDefinicjiZamowienia walidacja,
            IDefinicjaZamowieniaRepository definicjaZamowieniaRepository,
            IGrupaProduktowZamowieniaRepository grupyRepository,
            IWczytywaniePlikuZamowieniaService wczytywanieService)
        {
            this.walidacja = walidacja;
            this.definicjaZamowieniaRepository = definicjaZamowieniaRepository;
            this.grupyRepository = grupyRepository;
            this.wczytywanieService = wczytywanieService;
        }

        public int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji)
        {
            if (!walidacja.Waliduj(request, listenerWalidacji))
                return null;

            var definicja = new DefinicjaZamowienia
            {
                Nazwa = request.Nazwa,
                Plik = request.ZawartoscPliku,
                CzasKoncaZamawiania = request.DataKoncaZamawiania
            };


            var zamowienie = wczytywanieService.Wczytaj(request.ZawartoscPliku);
            foreach (var grupa in zamowienie.GrupyProduktow)
            {
                var g = PrzygotujGrupeProduktow(definicja, grupa);
                definicja.GrupyProduktow.Add(g);
            }
            var wstawiony = definicjaZamowieniaRepository.Save(definicja);

            return wstawiony.ID;
        }

        private GrupaProduktowZamowienia PrzygotujGrupeProduktow(
            DefinicjaZamowienia definicja,
            GrupaProduktow grupa)
        {
            var grupaProduktowZamowienia =

            new GrupaProduktowZamowienia
            {
                DefinicjaZamowienia = definicja,
                LimitIlosciowy = grupa.MinimalneIlosci,
                Nazwa = grupa.Nazwa,
            };
            grupaProduktowZamowienia.Produkty =
                PrzygotujGrupeProduktow(grupa.Pozycje, grupaProduktowZamowienia);
            return grupaProduktowZamowienia;
        }

        private ISet<Domain.Produkt> PrzygotujGrupeProduktow(
            IList<BusinessObject.Produkt> pozycje,
            GrupaProduktowZamowienia grupa)
        {
            var wynik = new HashSet<Domain.Produkt>();

            foreach (var p in pozycje)
            {
                var produkt = new Domain.Produkt
                {
                    Cena = p.CenaDecimal,
                    Nazwa = p.Nazwa,
                    GrupaProduktow = grupa
                };
                wynik.Add(produkt);
            }

            return wynik;
        }

        public IList<DefinicjaZamowieniaView> SzukajWszystkich()
        {
            var wynik = definicjaZamowieniaRepository.GetAll()
                .Select(o => DajDefinicjeZamowieniaView(o)).ToList();

            return wynik;
        }

        private DefinicjaZamowieniaView DajDefinicjeZamowieniaView(
            DefinicjaZamowienia definicja)
        {
            return new DefinicjaZamowieniaView
            {
                ID = definicja.ID,
                Nazwa = definicja.Nazwa,
                CzasKoncaZamawiania = definicja.CzasKoncaZamawiania
            };
        }
    }
}
