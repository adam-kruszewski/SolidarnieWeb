using System;
using System.Collections.Generic;

namespace Kruchy.Uzytkownicy.Services
{
    public interface IUprawnieniaUzytkownikaService
    {
        bool ZapiszUprawnienia(
            int uzytkownikID,
            List<Tuple<string, bool>> uprawnienia);
    }
}