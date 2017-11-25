using System;
using FluentAssertions;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.Szablony;
using Kruchy.Testy.Walidacja;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;
using Kruchy.Zakupy.Services;
using NUnit.Framework;

namespace Kruchy.Zakupy.Tests.Unit
{
    [TestFixture]
    public class DefinicjeZamowieniaServiceTests : TestyZSqlitemInMemory
    {
        private IDefinicjeZamowieniaService definicjaZamowieniaService;

        [SetUp]
        public void SetUpEachTests()
        {
            definicjaZamowieniaService =
                Injector.Instancja.Pobierz<IDefinicjeZamowieniaService>();
        }

        [Test]
        public void WstawionyRekordZapisujeSieWBazie()
        {
            //arrange
            var request = new WstawienieDefinicjiZamowieniaRequest
            {
                Nazwa = "Listopad",
                NazwaPliku = "a.xlsx",
                ZawartoscPliku = new byte[10],
                DataKoncaZamawiania = DateTime.Now.AddDays(2)
            };

            //act
            var id =
                definicjaZamowieniaService
                    .Wstaw(request, new MockListeneraWalidacji());

            //assert
            var repository = Injector.Instancja.Pobierz<IDefinicjaZamowieniaRepository>();
            var definicja = repository.Get(id) as DefinicjaZamowienia;
            definicja.CzasKoncaZamawiania.Should().Be(request.DataKoncaZamawiania);
            definicja.Nazwa.Should().Be(request.Nazwa);
            definicja.Plik.Should().BeSameAs(request.ZawartoscPliku);

        }
    }
}