using System.Web.Mvc;
using Kruchy.Uzytkownicy.Konfiguracja;
using NHibernate.Tool.hbm2ddl;

namespace SolidarnieWebApp.Controllers
{
    public class AdministracjaController : Controller
    {
        private readonly IHibernateSessionProvider sessionProvider;

        public AdministracjaController(
            IHibernateSessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UtworzBaze()
        {
            var konfiguracja = sessionProvider.DajKonfiguracje();

            new SchemaExport(konfiguracja).Execute(true, true, false);

            ViewBag.Komunikat = "Utworzono bazę danych";
            return View();
        }

    }
}