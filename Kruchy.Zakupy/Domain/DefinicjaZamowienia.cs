using System;

namespace Kruchy.Zakupy.Domain
{
    public class DefinicjaZamowienia
    {
        public virtual int ID { get; set; }

        public virtual string Nazwa { get; set; }

        public virtual DateTime CzasKoncaZamawiania { get; set; }

        public virtual bool Zamkniete { get; set; }

        public virtual byte[] Plik { get; set; }
    }
}