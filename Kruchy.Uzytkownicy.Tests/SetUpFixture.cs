using Kruchy.NInject.Adapter.Ladowanie;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy;
using Kruchy.Testy.Utils;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Injector.Instancja.LoadOnce<UzytkownicyModule>();
            Injector.Instancja.LoadOnce<TestyModule>();

            InicjalizacjaSrodowiskaTestowego.Inicjuj(Injector.Instancja);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}