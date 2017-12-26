namespace Kruchy.Zakupy.Domain
{
    public class Produkt
    {
        public virtual int ID { get; set; }

        public virtual string Nazwa { get; set; }

        public virtual decimal Cena { get; set; }

        public virtual GrupaProduktowZamowienia GrupaProduktow { get; set; }

        public virtual int NumerWierszaWExcelu { get; set; }
    }
}
