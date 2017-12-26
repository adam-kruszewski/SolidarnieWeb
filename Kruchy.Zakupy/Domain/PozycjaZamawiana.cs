using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruchy.Zakupy.Domain
{
    public class PozycjaZamawiana
    {
        public virtual int ID { get; set; }

        public virtual Produkt Produkt { get; set; }

        public virtual int Ilosc { get; set; }

        public virtual Zamowienie Zamowienie { get; set; }
    }
}
