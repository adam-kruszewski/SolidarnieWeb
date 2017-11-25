using FluentAssertions;
using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.Szablony;
using Kruchy.Testy.Walidacja;
using Kruchy.Uzytkownicy.Services;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests.Unit
{
    [TestFixture]
    public class UzytkownicyServiceTests : TestyZSqlitemInMemory
    {
        private IUzytkownicyService service;

        [SetUp]
        public override void SetUpEachTest()
        {
            base.SetUpEachTest();
            service = Injector.Instancja.Pobierz<IUzytkownicyService>();
        }

        [Test]
        public void DodanyUzytkownikJestZwracanyNaLiscieWszystkich()
        {
            //arrange
            var request = new DodanieUzytkownikaRequest
            {
                Email = "a@b.pl",
                Haslo = "haslo1",
                PowtorzenieHasla = "haslo1",
                Nazwa = "nazwa"
            };

            //act
            var listenerWalidacji = new MockListeneraWalidacji();
            var uzytkownikID = service.Dodaj(request, listenerWalidacji);

            //assert
            var uzytkownik = service.DajWgID(uzytkownikID.Value);
            uzytkownik.ID.Should().BeGreaterThan(0);
            uzytkownik.Nazwa.Should().Be(request.Nazwa);
            uzytkownik.Email.Should().Be(request.Email);

            service.SzukajWszystkich().Should().ContainSingle(o => o.ID == uzytkownik.ID);
        }
    }
}