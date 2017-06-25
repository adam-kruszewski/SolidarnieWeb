using System.Web.Mvc;
using Kruchy.NHibernate.Provider;
using SolidarnieWebApp.Authentication;

namespace SolidarnieWebApp.Controllers
{
    //[Authorize(Roles = "User")]
    [WymagaLogowania]
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