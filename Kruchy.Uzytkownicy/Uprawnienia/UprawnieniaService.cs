using System;
using System.Collections.Generic;
using System.Linq;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    class UprawnieniaService : IUprawnieniaService
    {
        private readonly IList<IDefiniowaneUprawnienia> definiowaneUprawnienia;

        public UprawnieniaService(
            IList<IDefiniowaneUprawnienia> definiowaneUprawnienia)
        {
            this.definiowaneUprawnienia = definiowaneUprawnienia;
        }

        public bool SprawdzCzyPosiada(int uzytkownikID, string uprawnienie)
        {
            throw new NotImplementedException();
        }

        public IList<Uprawnienie> Szukaj()
        {
            return definiowaneUprawnienia.SelectMany(o => o.Daj()).ToList();
        }
    }
}
