using System.Linq;
using FluentAssertions;

namespace Kruchy.Testy.Walidacja
{
    public static class MockListeneraWalidacjiExtension
    {
        public static void ZawieraBlad(
            this MockListeneraWalidacji listener,
            string komunikat)
        {
            listener.Bledy.SingleOrDefault(o => o.Item1 == komunikat)
                .Should().NotBeNull(string.Format("Brak błędu: \"{0}\"", komunikat));
        }

        public static void ZawieraBladDlaWlasciwosci(
            this MockListeneraWalidacji listener,
            string komunikat,
            string wlasciwosc)
        {
            listener
                .Bledy
                .SingleOrDefault(o => o.Item1 == komunikat && o.Item2 == wlasciwosc)
                .Should().NotBeNull(string.Format(
                    "Brak błędu \"{0}\" dla właściwości \"{1}\"", komunikat, wlasciwosc));
        }

        public static void NieZawieraBledu(this MockListeneraWalidacji listener)
        {
            listener.Bledy.Should().BeEmpty();
        }
    }
}