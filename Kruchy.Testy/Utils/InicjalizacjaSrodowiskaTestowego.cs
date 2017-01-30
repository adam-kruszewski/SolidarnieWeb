using Kruchy.Testy.InicjalizujaceFixtury;
using Ninject;

namespace Kruchy.Testy.Utils
{
    public static class InicjalizacjaSrodowiskaTestowego
    {
        public static void Inicjuj(IKernel kernel)
        {
            foreach (var fixtura in kernel.GetAll<IInicjalizujacaFixtura>())
                fixtura.Wykonaj();
        }
    }
}