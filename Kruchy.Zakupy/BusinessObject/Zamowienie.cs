using System.Collections.Generic;
using System.Linq;

namespace Kruchy.Zakupy.BusinessObject
{
    class Zamowienie
    {
        public IList<GrupaProduktow> GrupyProduktow { get; set; }
        public string Nazwa { get; set; }

        public Zamowienie()
        {
            GrupyProduktow = new List<GrupaProduktow>();
        }

        public Zamowienie(Zamowienie zamowienie)
            : this()
        {
            foreach (var grupa in zamowienie.GrupyProduktow)
                GrupyProduktow.Add(new GrupaProduktow(grupa));
        }

        public void WyczyscIlosci()
        {
            foreach (var grupa in GrupyProduktow)
                foreach (var pozycja in grupa.Pozycje)
                    pozycja.Ilosc = null;
        }

        public decimal Wartosc
        {
            get
            {
                return
                    GrupyProduktow
                        .SelectMany(o => o.Pozycje)
                            .Where(o => o.Ilosc.HasValue)
                                .Sum(o => o.Ilosc.Value * o.CenaDecimal);
            }
        }

    }
}
