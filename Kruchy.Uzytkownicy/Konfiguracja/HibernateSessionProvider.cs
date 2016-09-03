using System;
using Kruchy.Uzytkownicy.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Kruchy.Uzytkownicy.Konfiguracja
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
                konfiguracja.AddAssembly(typeof(Uzytkownik).Assembly);
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