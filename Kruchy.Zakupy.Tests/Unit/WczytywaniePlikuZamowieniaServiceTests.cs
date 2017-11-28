using System.IO;
using FluentAssertions;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Zakupy.Services.Impl;
using Kruchy.Zakupy.Tests.Przyklady;
using NUnit.Framework;

namespace Kruchy.Zakupy.Tests.Unit
{
    [TestFixture]
    public class WczytywaniePlikuZamowieniaServiceTests
    {
        private IWczytywaniePlikuZamowieniaService service;

        [SetUp]
        public void SetUpEachTests()
        {
            service = Injector.Instancja.Pobierz<IWczytywaniePlikuZamowieniaService>();
        }

        [Test]
        public void PoprawnieWczytujeZamowienie()
        {
            //arrange
            var przykladowyPlik = DajPrzykladowyPlik();

            //act
            var zamowienie = service.Wczytaj(przykladowyPlik);

            //assert
            zamowienie.GrupyProduktow.Count.Should().Be(15);
        }


        private byte[] DajPrzykladowyPlik()
        {
            var bufor = new byte[1024];

            using (var streamZasobow =
                this.GetType().Assembly.GetManifestResourceStream(
                    NazwyPrzykladow.TestoweZamowienie))
            using (var ms = new MemoryStream())
            {
                int liczbaPrzeczytanychBajtow = streamZasobow.Read(bufor, 0, bufor.Length);
                do
                {
                    ms.Write(bufor, 0, liczbaPrzeczytanychBajtow);
                    liczbaPrzeczytanychBajtow = streamZasobow.Read(bufor, 0, bufor.Length);
                } while (liczbaPrzeczytanychBajtow > 0);

                return ms.ToArray();
            }
        }


    }
}