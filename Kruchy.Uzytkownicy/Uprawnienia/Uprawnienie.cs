using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    public class Uprawnienie
    {
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public bool Administracyjne { get; internal set; }
    }
}
