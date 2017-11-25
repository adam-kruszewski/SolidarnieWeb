using System;
using FluentAssertions;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.Szablony;
using Kruchy.Testy.Walidacja;
using Kruchy.Zakupy.Resources;
using Kruchy.Zakupy.Services;
using Kruchy.Zakupy.Walidacja;
using NUnit.Framework;

namespace Kruchy.Zakupy.Tests.Unit
{
    [TestFixture]
    public class WalidacjaDefinicjiZamowieniaTests : TestyZSqlitemInMemory
    {
        IWalidacjaDefinicjiZamowienia walidacja;
        private MockListeneraWalidacji mockListeneraWalidacji;

        [SetUp]
        public void SetUpEachTests()
        {
            walidacja = Injector.Instancja.Pobierz<IWalidacjaDefinicjiZamowienia>();
            mockListeneraWalidacji = new MockListeneraWalidacji();
        }

        [Test]
        public void PoprawnieJakWszystkoWypelnione()
        {
            //arrange
            var request = PrzygotujPoprawnyRequest();

            //act
            var wynik = walidacja.Waliduj(request, mockListeneraWalidacji);

            //assert
            wynik.Should().BeTrue();
        }

        [Test]
        public void BladGdyNieMaPodanejNazwy()
        {
            //arrange
            var request = PrzygotujPoprawnyRequest();
            request.Nazwa = "";

            //act
            var wynik = walidacja.Waliduj(request, mockListeneraWalidacji);

            //assert
            mockListeneraWalidacji.ZawieraBladDlaWlasciwosci(
                Napisy.BrakNazwyZamowienia,
                "Nazwa");
        }

        [Test]
        public void BladGdyNieMaPodanegoPliku()
        {
            //arrange
            var request = PrzygotujPoprawnyRequest();
            request.NazwaPliku = "";

            //act
            var wynik = walidacja.Waliduj(request, mockListeneraWalidacji);

            //assert
            mockListeneraWalidacji.ZawieraBladDlaWlasciwosci(
                Napisy.BrakPlikuZamowienia,
                "Plik");
        }

        [Test]
        public void BladGdyPlikNieJestXslx()
        {
            //arrange
            var request = PrzygotujPoprawnyRequest();
            request.NazwaPliku = "e:\\temp\\a.doc";

            //act
            var wynik = walidacja.Waliduj(request, mockListeneraWalidacji);

            //assert
            mockListeneraWalidacji.ZawieraBladDlaWlasciwosci(
                Napisy.NiepoprawnyFormatPlikuZamowienia,
                "Plik");
        }

        private WstawienieDefinicjiZamowieniaRequest PrzygotujPoprawnyRequest()
        {
            return new WstawienieDefinicjiZamowieniaRequest
            {
                DataKoncaZamawiania = DateTime.Now.AddDays(1),
                Nazwa = "Listopad",
                NazwaPliku = "a:\\temp\\przyklad.xlsx",
                ZawartoscPliku = PrzygotujZawartoscPliku()
            };
        }

        private static byte[] PrzygotujZawartoscPliku()
        {
            var wynik = new byte[10];
            for (int i = 0; i < wynik.Length; i++)
                wynik[i] = (byte)(10 + i);
            return wynik;
        }
    }
}