using Kruchy.NInject.Adapter.Ladowanie;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy;
using Kruchy.Testy.Utils;
using NUnit.Framework;

namespace Kruchy.Zakupy.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Injector.Instancja.LoadOnce<ZakupyModule>();
            Injector.Instancja.LoadOnce<TestyModule>();

            InicjalizacjaSrodowiskaTestowego.Inicjuj(Injector.Instancja);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}
