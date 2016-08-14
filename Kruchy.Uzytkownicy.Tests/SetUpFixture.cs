using Kruchy.Uzytkownicy.Tests.NInjectTestUtils;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Injector.Instance.LoadOnce<UzytkownicyModule>();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}