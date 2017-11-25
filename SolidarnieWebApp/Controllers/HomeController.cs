using System;
using System.IO;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Views;
using Newtonsoft.Json;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;

        public HomeController(
            IUzytkownicyService uzytkownicyService)
        {
            this.uzytkownicyService = uzytkownicyService;
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
    }
}