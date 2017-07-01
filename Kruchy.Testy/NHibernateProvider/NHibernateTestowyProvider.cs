using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Kruchy.NHibernate.Provider;
using Kruchy.NHibernate.RejestracjaAssembly;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Kruchy.Testy.NHibernateProvider
{
    public class NHibernateTestowyProvider : IHibernateSessionProvider
    {
        private int licznik = 0;
        ISession sesja = null;
        Configuration konfiguracja = null;

        public NHibernateTestowyProvider()
        {
            licznik++;
        }

        public ISession DajSesje()
        {
            if (sesja == null)
            {
                if (konfiguracja == null)
                    DajKonfiguracje();
                sesja = konfiguracja.BuildSessionFactory().OpenSession();
            }
            return sesja;
        }

        public void UtworzBaze()
        {
            var konfiguracja = DajKonfiguracje();
            var writer = new StringWriter();

            new SchemaExport(konfiguracja).Create(writer, false);

            foreach (var z in PodzielNaZapytania(writer.ToString()))
            {
                var c = DajSesje().GetSessionImplementation().Connection.CreateCommand();
                c.CommandText = z;
                c.ExecuteNonQuery();
            }
        }

        private IEnumerable<string> PodzielNaZapytania(string polaczoneZapytania)
        {
            const string separatorZapytan = "\r\n";
            var aktualny = polaczoneZapytania;

            while (aktualny.IndexOf(separatorZapytan) >= 0)
            {
                var indeks = aktualny.IndexOf(separatorZapytan);
                yield return aktualny.Substring(0, indeks);
                aktualny = aktualny.Substring(indeks + (separatorZapytan.Length - 1));
            }
            yield return aktualny;
        }

        private Configuration DajKonfiguracje()
        {
            var builder =
                Fluently
                    .Configure()
                        .Database(SQLiteConfiguration.Standard.InMemory().ShowSql);

            foreach (var assembly in RejestratorAssembly.DajZarejestrowaneAssembly())
                builder.Mappings(m => m.HbmMappings.AddFromAssembly(assembly));

            konfiguracja = builder.BuildConfiguration();

            return konfiguracja;
        }

        public void AktualizujBaze()
        {
            throw new NotImplementedException();
        }
    }
}