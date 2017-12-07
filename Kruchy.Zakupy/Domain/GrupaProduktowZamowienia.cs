using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruchy.Zakupy.Domain
{
    public class GrupaProduktowZamowienia
    {
        public virtual int ID { get; set; }

        public virtual string Nazwa { get; set; }

        public virtual int? LimitIlosciowy { get; set; }

        public virtual DefinicjaZamowienia DefinicjaZamowienia { get; set; }
        //public virtual int DefinicjaZamowieniaID { get; set; }
    }
}
