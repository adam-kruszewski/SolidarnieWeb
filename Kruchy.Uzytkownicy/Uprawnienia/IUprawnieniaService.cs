using System.Collections.Generic;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    public interface IUprawnieniaService
    {
        bool SprawdzCzyPosiada(int uzytkownikID, string uprawnienie);

        IList<DefiniowanieUprawnieniaUzytkownikaView> SzukajWgUzytkownika(int uzytkownikID);
    }
}
