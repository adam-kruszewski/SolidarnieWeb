using Kruchy.NHibernate.RejestracjaAssembly;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Kruchy.NHibernate.Provider
{
    public class HibernateSessionProvider : IHibernateSessionProvider
    {
        private Configuration konfiguracja;
        private ISession sesja;
        private ISessionFactory fabrykaSesji;

        public void UtworzBaze()
        {
            var konfiguracja = DajKonfiguracje();

            new SchemaExport(konfiguracja).Execute(true, true, false);
        }

        public Configuration DajKonfiguracje()
        {
            if (konfiguracja == null)
            {
                konfiguracja = new Configuration();
                konfiguracja.Configure();
                foreach (var assembly in RejestratorAssembly.DajZarejestrowaneAssembly())
                    konfiguracja.AddAssembly(assembly);
                fabrykaSesji = konfiguracja.BuildSessionFactory();
            }
            return konfiguracja;
        }

        public ISession DajSesje()
        {
            if (sesja == null)
            {
                if (konfiguracja == null)
                    DajKonfiguracje();
                sesja = fabrykaSesji.OpenSession();
            }
            return sesja;
        }

        public void Dispose()
        {
            sesja.Dispose();
        }
    }
}
