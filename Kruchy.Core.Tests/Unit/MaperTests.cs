using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kruchy.Core.Mapowanie;
using NUnit.Framework;

namespace Kruchy.Core.Tests.Unit
{
    [TestFixture]
    public class MaperTests
    {
        [Test]
        public void MapujeProsteAtrybuty()
        {
            //arrange
            var obiektA = new MapowanaKlasa();
            obiektA.A = "aa";
            obiektA.B = 123;

            //act
            var obiektB = new Maper().Mapuj<MapowanaKlasa>(obiektA);

            //assert
            obiektB.A.Should().Be(obiektA.A);
            obiektB.B.Should().Be(obiektA.B);
        }

        [Test]
        public void MapujeTakzeKolekcje()
        {
            //arrange
            var obiektA = new KlasaD();
            obiektA.A = 12;
            obiektA.Lista.Add(new KlasaC(134));
            obiektA.Lista.Add(new KlasaC(54));

            //act
            var obiektB = new Maper().Mapuj<KlaseE>(obiektA);

            //assert
            obiektB.A.Should().Be(obiektA.A);
            obiektB.Lista.Select(o => o.K).Should().BeEquivalentTo(
                obiektA.Lista.Select(o => o.K));

            foreach (var obiektCWynik in obiektB.Lista)
                obiektA.Lista.Any(o => o == obiektCWynik).Should().BeFalse();
        }

        private class MapowanaKlasa
        {
            public string A { get; set; }

            public int B { get; set; }
        }

        private class KlasaC
        {
            private static int sekwencja = 10;
            public int K { get; set; }
            public int ID { get; private set; }

            public KlasaC()
            {
                ID = sekwencja++;
            }

            public KlasaC(int k) : this()
            {
                K = k;
            }
        }

        private class KlasaD
        {
            public int A { get; set; }

            public List<KlasaC> Lista { get; set; }

            public KlasaD()
            {
                Lista = new List<KlasaC>();
            }
        }

        private class KlaseE
        {
            public int A { get; set; }
            public int B { get; set; }
            public List<KlasaC> Lista { get; set; }

            public KlaseE()
            {
                Lista = new List<KlasaC>();
            }
        }
    }
}