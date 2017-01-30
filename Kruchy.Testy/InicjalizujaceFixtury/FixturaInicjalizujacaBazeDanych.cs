using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Testy;
using Kruchy.Testy.NHibernateProvider;
using NUnit.Framework;

namespace Kruchy.Testy.InicjalizujaceFixtury
{
    class FixturaInicjalizujacaBazeDanych : IInicjalizujacaFixtura
    {
        public void Wykonaj()
        {
            Injector.Instancja.Unbind<IHibernateSessionProvider>();
            Injector
                .Instancja
                    .Bind<IHibernateSessionProvider>()
                        .To<NHibernateTestowyProvider>()
                            .InScope(ctx => TestContext.CurrentContext.Test.FullName);
        }
    }
}