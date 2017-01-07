using System.Web.Mvc;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(model: new UzytkownikEditModel());
        }
    }
}