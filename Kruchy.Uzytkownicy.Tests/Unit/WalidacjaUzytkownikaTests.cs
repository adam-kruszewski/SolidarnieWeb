using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.Szablony;
using Kruchy.Testy.Walidacja;
using Kruchy.Uzytkownicy.Tests.Builders;
using Kruchy.Uzytkownicy.Walidacja.Impl;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests.Unit
{
    [TestFixture]
    public class WalidacjaUzytkownikaTests : TestyZSqlitemInMemory
    {
        WalidacjaUzytkownika walidacja;

        [SetUp]
        public override void SetUpEachTest()
        {
            base.SetUpEachTest();
            walidacja = Injector.Instancja.Pobierz<WalidacjaUzytkownika>();
        }

        [Test]
        public void PrzepuszczaJesliNieIstniejeUzytkownikOPodanejNazwie()
        {
            //arrange
            new UzytkownikBuilder().ZNazwa("nazwa1").Save();
            var uzytkownik = new UzytkownikBuilder().ZNazwa("nazwa2").Build();

            var listenerWalidacji = new MockListeneraWalidacji();
            //act
            walidacja.Waliduj(uzytkownik, listenerWalidacji);

            //assert
            listenerWalidacji.NieZawieraBledu();
        }

        [Test]
        public void BladGdyIstniejeUzytkownikOTakiejSamejNazwie()
        {
            new UzytkownikBuilder().ZNazwa("nazwa").Save();
            var uzytkownik = new UzytkownikBuilder().ZNazwa("nazwa").Build();

            var listenerWalidacji = new MockListeneraWalidacji();
            //act
            walidacja.Waliduj(uzytkownik, listenerWalidacji);

            //assert
            listenerWalidacji.ZawieraBladDlaWlasciwosci(
                "Użytkownik o takiej nazwie już istnieje",
                "Nazwa");
        }
    }
}