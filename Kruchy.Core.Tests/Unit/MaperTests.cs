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

        private class MapowanaKlasa
        {
            public string A { get; set; }

            public int B { get; set; }
        }
    }
}