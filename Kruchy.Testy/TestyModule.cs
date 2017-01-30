using Kruchy.Testy.InicjalizujaceFixtury;
using Ninject.Modules;

namespace Kruchy.Testy
{
    public class TestyModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<IInicjalizujacaFixtura>()
                    .To<FixturaInicjalizujacaBazeDanych>();
        }
    }
}