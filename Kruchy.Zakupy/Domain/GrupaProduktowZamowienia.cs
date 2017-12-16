using System.Collections.Generic;

namespace Kruchy.Zakupy.Domain
{
    public class GrupaProduktowZamowienia
    {
        public virtual int ID { get; set; }

        public virtual string Nazwa { get; set; }

        public virtual int? LimitIlosciowy { get; set; }

        public virtual DefinicjaZamowienia DefinicjaZamowienia { get; set; }

        public virtual ISet<Produkt> Produkty { get; set; }

        public GrupaProduktowZamowienia()
        {
            Produkty = new HashSet<Produkt>();
        }
    }
}
