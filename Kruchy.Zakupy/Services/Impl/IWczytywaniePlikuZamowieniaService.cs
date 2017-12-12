using Kruchy.Zakupy.BusinessObject;

namespace Kruchy.Zakupy.Services.Impl
{
    public interface IWczytywaniePlikuZamowieniaService
    {
        Zamowienie Wczytaj(byte[] zawartoscPliku);
    }
}