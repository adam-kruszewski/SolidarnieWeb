using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Testy;

namespace Kruchy.Testy.Buildery
{
    public class NHibernateBuilder<T>
        where T : new()
    {
        protected T Obiekt;

        public NHibernateBuilder()
        {
            Obiekt = new T();
        }

        public T Build()
        {
            return Obiekt;
        }

        public T Save()
        {
            var obiektDoZapisania = Build();

            var sessionProvider =
                Injector.Instancja.Pobierz<IHibernateSessionProvider>();

            sessionProvider.DajSesje().Save(obiektDoZapisania);

            return obiektDoZapisania;
        }
    }
}