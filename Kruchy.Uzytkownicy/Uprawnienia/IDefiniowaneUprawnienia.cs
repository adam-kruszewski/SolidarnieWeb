using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    public interface IDefiniowaneUprawnienia
    {
        IEnumerable<Uprawnienie> Daj();
    }
}
