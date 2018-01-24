using System.Web.Mvc;
using Kruchy.Core.Autentykacja;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Uprawnienia;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;
        private readonly IUprawnieniaService uprawnieniaService;
        private readonly IUzytkownikProvider uzytkownikProvider;

        public HomeController(
            IUzytkownicyService uzytkownicyService,
            IUprawnieniaService uprawnieniaService,
            IUzytkownikProvider uzytkownikProvider)
        {
            this.uzytkownicyService = uzytkownicyService;
            this.uprawnieniaService = uprawnieniaService;
            this.uzytkownikProvider = uzytkownikProvider;
        }

        public ActionResult Index()
        {
            return View(model: new UzytkownikEditModel());
        }

        public PartialViewResult ButtonLogowania()
        {
            if (Request.Cookies["solidarnie"] != null)
                return PartialView("ButtonWyloguj");
            else
                return PartialView("ButtonZaloguj");
        }

        public ActionResult Menu()
        {
            var model = new MenuModel();
            var u = uzytkownikProvider.SzukajZalogowanego();
            if (u != null)
                model.Administrator =
                    uprawnieniaService
                        .SprawdzCzyPosiada(
                            u.ID,
                            "Administrator");
            return PartialView(model);
        }
    }
}