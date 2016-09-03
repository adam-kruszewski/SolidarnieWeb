using System.Web.Mvc;
using Kruchy.Uzytkownicy.Konfiguracja;

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
            sessionProvider.UtworzBaze();

            ViewBag.Komunikat = "Utworzono bazę danych";
            return View();
        }

    }
}