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

        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var uzytkownik =
                uzytkownicyService
                    .SzukajWgNazwyHasla(model.Uzytkownik, model.Haslo);

            if (uzytkownik != null)
            {
                //var ident = new ClaimsIdentity(
                //      PrzygotujClaims(model),
                //    DefaultAuthenticationTypes.ApplicationCookie);
                //var ident = new ClaimsIdentity(PrzygotujClaims(model));

                //HttpContext.GetOwinContext().Authentication.SignIn(
                //   new AuthenticationProperties { IsPersistent = false }, ident);
                HttpContext.Response.Cookies.Add(
                    new HttpCookie("solidarnie", PrzygotujTrescCookie(uzytkownik)));
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Błędna nazwa użytkownika lub hasło");
            return View(model);
        }

        private string PrzygotujTrescCookie(ZalogowanyUzytkownikView uzytkownik)
        {
            var writer = new StringWriter();
            new JsonSerializer().Serialize(writer, uzytkownik);

            return writer.ToString();
        }

        public PartialViewResult ButtonLogowania()
        {
            if (Request.Cookies["solidarnie"] != null)
                return PartialView("ButtonWyloguj");
            else
                return PartialView("ButtonZaloguj");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["solidarnie"] != null)
            {
                var user = new HttpCookie("solidarnie")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Response.Cookies.Add(user);
            }
            return RedirectToAction("Login");
        }

        private static Claim[] PrzygotujClaims(LoginModel model)
        {
            return new[] { 
                // adding following 2 claim just for supporting default antiforgery provider
                new Claim(ClaimTypes.NameIdentifier, model.Uzytkownik),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

                new Claim(ClaimTypes.Name, model.Uzytkownik),

                // optionally you could add roles if any
                new Claim(ClaimTypes.Role, "User"),
                //new Claim(ClaimTypes.Role, "AnotherRole"),
          };
        }
    }
}