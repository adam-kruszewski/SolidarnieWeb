using Kruchy.Uzytkownicy.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Kruchy.Uzytkownicy.Tests.Unit
{
    [TestFixture]
    public class GenerujSchematTests
    {
        [Test]
        public void GenerujeSchemat()
        {
            var cfg = new Configuration();

            cfg.Configure();

            cfg.AddAssembly(typeof(Uzytkownik).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);
                //.Execute(false, true, false, false);
        }
    }
}
