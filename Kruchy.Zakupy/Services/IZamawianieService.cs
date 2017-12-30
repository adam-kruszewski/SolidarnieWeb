
using System.Collections.Generic;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services
{
    public interface IZamawianieService
    {
        DefinicjaZamowieniaPelnaView PrzygotujDlaUzytkownika(
            int definicjaID,
            int uzytkownikID);

        bool Zamow(
            int definicjaID,
            int uzytkownikID,
            IEnumerable<ZamawianaPozycja> pozycje);
    }
}