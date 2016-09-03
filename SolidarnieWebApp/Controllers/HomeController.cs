using System.Web.Mvc;
using SolidarnieWebApp.Tmp;

namespace SolidarnieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITest test;

        public HomeController(
            ITest test)
        {
            this.test = test;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Tytuł " + test.DajStringa() + " drugi " + test.DajStringa();
            return View();
        }
    }
}