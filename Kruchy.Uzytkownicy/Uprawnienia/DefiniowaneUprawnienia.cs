using System.Collections.Generic;

namespace Kruchy.Uzytkownicy.Uprawnienia
{
    class DefiniowaneUprawnienia : IDefiniowaneUprawnienia
    {
        public IEnumerable<Uprawnienie> Daj()
        {
            var uprawnienieAdministrator =
                new Uprawnienie()
                {
                    Administracyjne = true,
                    Nazwa = "Administrator",
                    Opis = "Administrator systemu"
                };
            yield return uprawnienieAdministrator;
        }
    }
}