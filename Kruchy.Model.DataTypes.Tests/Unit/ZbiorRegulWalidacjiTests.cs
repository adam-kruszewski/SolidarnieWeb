using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kruchy.Model.DataTypes.Walidacja;
using NUnit.Framework;

namespace Kruchy.Model.DataTypes.Tests.Unit
{
    [TestFixture, Category("Unit")]
    public class ZbiorRegulWalidacjiTests
    {
        private TestowyListenerWalidacji listener;

        [SetUp]
        public void SetUpEachTest()
        {
            listener = new TestowyListenerWalidacji();
        }

        [Test]
        public void DlaSpelnionychWarunkowZwracaTrueINieWolaListenera()
        {
            //arrange
            var zbior = new ZbiorRegulWalidacji();
            zbior.DodajReguleBledu(() => false, "komunikat błędu", null);
            zbior.DodajReguleOstrzezenia(() => false, "komunikat ostrzeżenia", null);

            //act
            var wynik = zbior.Wykonaj(listener);

            //assert
            wynik.Should().BeTrue();
            listener.Bledy.Count.Should().Be(0);
            listener.Ostrzezenia.Count.Should().Be(0);
        }

        [Test]
        public void DlaNiespelnionegoWarunkuDlaBleduZwracaTylkoJedenBlad()
        {
            //arrange
            var zbior = new ZbiorRegulWalidacji();
            zbior.DodajReguleBledu(() => true, "komunikat błędu", null);
            zbior.DodajReguleOstrzezenia(() => false, "komunikat ostrzeżenia", null);

            //act
            var wynik = zbior.Wykonaj(listener);

            //assert
            wynik.Should().BeFalse();
            listener.Bledy.Count.Should().Be(1);
            var t = listener.Bledy.Single();
            t.Item1.Should().Be("komunikat błędu");
            t.Item2.Should().BeNull();
            listener.Ostrzezenia.Count.Should().Be(0);
        }

        [Test]
        public void DlaNiespelnionegoWarunkuDlaOstrzezeniaZwracaTylkoJednoOstrzezenie()
        {
            //arrange
            var zbior = new ZbiorRegulWalidacji();
            zbior.DodajReguleBledu(() => false, "komunikat błędu", null);
            zbior.DodajReguleOstrzezenia(() => true, "komunikat ostrzeżenia", null);

            //act
            var wynik = zbior.Wykonaj(listener);

            //assert
            wynik.Should().BeFalse();
            listener.Bledy.Count.Should().Be(0);
            listener.Ostrzezenia.Count.Should().Be(1);
            var t = listener.Ostrzezenia.Single();
            t.Item1.Should().Be("komunikat ostrzeżenia");
            t.Item2.Should().BeNull();
        }

        private class TestowyListenerWalidacji : IWalidacjaListener
        {
            public List<Tuple<string, string>> Bledy { get; private set; }
            public List<Tuple<string, string>> Ostrzezenia { get; private set; }

            public TestowyListenerWalidacji()
            {
                Bledy = new List<Tuple<string, string>>();
                Ostrzezenia = new List<Tuple<string, string>>();
            }

            public void Blad(string komunikat, string wlasciwosc)
            {
                Bledy.Add(new Tuple<string, string>(komunikat, wlasciwosc));
            }

            public void Ostrzezenie(string komunikat, string wlasciwosc)
            {
                Ostrzezenia.Add(new Tuple<string, string>(komunikat, wlasciwosc));
            }
        }
    }
}