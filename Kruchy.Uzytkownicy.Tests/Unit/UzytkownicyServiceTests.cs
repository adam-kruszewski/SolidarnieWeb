using FluentAssertions;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Services;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests.Unit
{
    [TestFixture]
    public class UzytkownicyServiceTests
    {
        private IUzytkownicyService service;

        [SetUp]
        public void SetUpEachTest()
        {
            service = Injector.Instancja.Pobierz<IUzytkownicyService>();

            var cfg = new Configuration();

            cfg.Configure();

            cfg.AddAssembly(typeof(Uzytkownik).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);
        }

        [Test]
        public void DodanyUzytkownikJestZwracanyNaLiscieWszystkich()
        {
            //arrange
            var request = new DodanieUzytkownikaRequest
            {
                Email = "a@b.pl",
                Haslo = "haslo1",
                Nazwa = "nazwa"
            };

            //act
            var uzytkownik = service.Dodaj(request);

            //assert
            uzytkownik.ID.Should().BeGreaterThan(0);
            uzytkownik.Nazwa.Should().Be(request.Nazwa);
            uzytkownik.Email.Should().Be(request.Email);
            uzytkownik.Haslo.Should().Be(request.Haslo);

            service.SzukajWszystkich().Should().ContainSingle(o => o.ID == uzytkownik.ID);
        }
    }
}