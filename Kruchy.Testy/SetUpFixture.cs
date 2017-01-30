using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.NHibernateProvider;
using NUnit.Framework;

namespace Kruchy.Testy
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Injector.Instancja.Unbind<IHibernateSessionProvider>();
            Injector
                .Instancja
                    .Bind<IHibernateSessionProvider>()
                        .To<NHibernateTestowyProvider>()
                            .InScope(ctx => TestContext.CurrentContext.Test.FullName);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}