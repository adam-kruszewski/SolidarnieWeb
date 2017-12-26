using System.Collections.Generic;
namespace Kruchy.Zakupy.Services.Impl
{
    class ZamawianieService : IZamawianieService
    {

        public bool Zamow(int uzytkownikID, IEnumerable<ZamawianaPozycja> pozycje)
        {
            return true;
        }
    }
}