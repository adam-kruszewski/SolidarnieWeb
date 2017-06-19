using System;
using System.Collections.Generic;

namespace Kruchy.Model.DataTypes.Walidacja
{
    public class ZbiorRegulWalidacji
    {
        private readonly IList<RegulaWalidacji> regulyBledow;
        private readonly IList<RegulaWalidacji> regulyOstrzezen;

        public ZbiorRegulWalidacji()
        {
            regulyBledow = new List<RegulaWalidacji>();
            regulyOstrzezen = new List<RegulaWalidacji>();
        }

        public ZbiorRegulWalidacji DodajReguleBledu(
            Func<bool> funkcjaWarunku,
            string komunikat,
            string wlasciwosc)
        {
            regulyBledow.Add(
                new RegulaWalidacji(funkcjaWarunku, komunikat, wlasciwosc));
            return this;
        }

        public ZbiorRegulWalidacji DodajReguleOstrzezenia(
            Func<bool> funkcjaWarunku,
            string komunikat,
            string wlasciwosc)
        {
            regulyOstrzezen.Add(
                new RegulaWalidacji(funkcjaWarunku, komunikat, wlasciwosc));
            return this;
        }

        public bool Wykonaj(IWalidacjaListener listener)
        {
            var wynik = true;

            foreach (var regula in regulyBledow)
                wynik = wynik & regula.Sprawdz((k, w) => listener.Blad(k, w));

            foreach (var regula in regulyOstrzezen)
                wynik = wynik & regula.Sprawdz((k, w) => listener.Ostrzezenie(k, w));

            return wynik;
        }
    }
}