using Kruchy.NInject.Adapter.Ladowanie;
using Kruchy.NInject.Adapter.Testy;
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
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}