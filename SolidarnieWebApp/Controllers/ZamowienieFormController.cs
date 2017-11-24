using System.Web.Mvc;
using SolidarnieWebApp.Authentication;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    [WymagaLogowania]
    public class ZamowienieFormController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ZamowienieModel());
        }

        [HttpPost]
        public ActionResult Create(ZamowienieModel form)
        {
            return View(form);
        }
    }
}