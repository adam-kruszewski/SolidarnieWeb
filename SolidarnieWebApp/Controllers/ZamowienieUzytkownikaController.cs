using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kruchy.Core.Autentykacja;

namespace SolidarnieWebApp.Controllers
{
    public class ZamowienieUzytkownikaController : Controller
    {
        private readonly IUzytkownikProvider uzytkownikProvider;

        public ZamowienieUzytkownikaController(
            IUzytkownikProvider uzytkownikProvider)
        {
            this.uzytkownikProvider = uzytkownikProvider;
        }

        public ActionResult Index()
        {
            var u = uzytkownikProvider.DajZalogowanego();
            return View();
        }
    }
}