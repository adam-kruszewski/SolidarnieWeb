using System;

namespace Kruchy.Model.DataTypes.Walidacja
{
    class RegulaWalidacji
    {
        private readonly Func<bool> funkcjaWarunku;
        private readonly string komunikat;
        private readonly string wlasciwosc;

        public RegulaWalidacji(
            Func<bool> funkcjaWarunku,
            string komunikat,
            string wlasciwosc)
        {
            this.funkcjaWarunku = funkcjaWarunku;
            this.komunikat = komunikat;
            this.wlasciwosc = wlasciwosc;
        }

        public bool Sprawdz(Action<string, string> handlerPrawdziwosciFunkcji)
        {
            if (funkcjaWarunku())
            {
                handlerPrawdziwosciFunkcji(komunikat, wlasciwosc);
                return false;
            }
            else
                return true;

        }
    }
}