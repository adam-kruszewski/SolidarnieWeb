using Kruchy.Zakupy.BusinessObject;

namespace Kruchy.Zakupy.Services.Impl
{
    interface IWczytywaniePlikuZamowieniaService
    {
        Zamowienie Wczytaj(byte[] zawartoscPliku);
    }
}