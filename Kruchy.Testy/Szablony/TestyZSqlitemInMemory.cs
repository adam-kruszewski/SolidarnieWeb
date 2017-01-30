using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Testy;
using NUnit.Framework;

namespace Kruchy.Testy.Szablony
{
    public class TestyZSqlitemInMemory
    {
        [SetUp]
        public virtual void SetUpEachTest()
        {
            var nhibernateProvide = Injector.Instancja.Pobierz<IHibernateSessionProvider>();
            nhibernateProvide.UtworzBaze();
        }
    }
}
