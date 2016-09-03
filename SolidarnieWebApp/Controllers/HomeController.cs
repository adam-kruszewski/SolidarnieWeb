using System.Web.Mvc;
using Kruchy.Uzytkownicy.Konfiguracja;
using SolidarnieWebApp.Tmp;

namespace SolidarnieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITest test;
        private readonly IHibernateSessionProvider sessionProvider;

        public HomeController(
            ITest test,
            IHibernateSessionProvider sessionProvider)
        {
            this.test = test;
            this.sessionProvider = sessionProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Tytuł " + test.DajStringa() + " drugi " + test.DajStringa();
            return View();
        }
    }
}