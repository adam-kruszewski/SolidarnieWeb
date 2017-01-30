using System;
using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;

namespace Kruchy.Testy.Walidacja
{
    public class MockListeneraWalidacji : IWalidacjaListener
    {
        public List<Tuple<string, string>> Bledy { get; private set; }
        public List<Tuple<string, string>> Ostrzezenia { get; private set; }

        public MockListeneraWalidacji()
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