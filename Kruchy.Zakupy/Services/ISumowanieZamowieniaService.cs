using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services
{
    public interface ISumowanieZamowieniaService
    {
        ZsumowaneZamowienie Sumuj(int definicjaID);
    }
}