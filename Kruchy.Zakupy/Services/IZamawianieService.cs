
using System.Collections.Generic;

namespace Kruchy.Zakupy.Services
{
    public interface IZamawianieService
    {
        bool Zamow(int uzytkownikID, IEnumerable<ZamawianaPozycja> pozycje);
    }
}