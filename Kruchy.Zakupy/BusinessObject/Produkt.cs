using System;

namespace Kruchy.Zakupy.BusinessObject
{
    class Produkt
    {
        public string Nazwa { get; set; }

        public string Cena { get; set; }

        public decimal CenaDecimal
        {
            get
            {
                var doParsowania = Cena.Replace(".", ",");
                if (string.IsNullOrEmpty(doParsowania))
                    return 0;
                return Convert.ToDecimal(double.Parse(doParsowania));
            }
        }

        public int? Ilosc { get; set; }

        public int NumerPozycjiWExcelu { get; set; }

        public Produkt()
        {
        }

        private Produkt(Produkt pozycja)
        {
            Nazwa = pozycja.Nazwa;
            Cena = pozycja.Cena;
            Ilosc = pozycja.Ilosc;
            NumerPozycjiWExcelu = pozycja.NumerPozycjiWExcelu;
        }

        public void ZwiekszIlosc(int oIle)
        {
            if (Ilosc.HasValue)
                Ilosc += oIle;
            else
                Ilosc = oIle;
        }

        public virtual Produkt Klonuj()
        {
            return new Produkt(this);
        }
    }
}
