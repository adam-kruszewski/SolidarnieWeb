using System.Linq;
using System.Web.Mvc;
using Kruchy.Core.Mapowanie;
using Kruchy.Uzytkownicy.Uprawnienia;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class UprawnieniaUzytkownikaController : Controller
    {
        private readonly IUprawnieniaService uprawnieniaService;

        public UprawnieniaUzytkownikaController(
            IUprawnieniaService uprawnieniaService)
        {
            this.uprawnieniaService = uprawnieniaService;
        }

        public ActionResult Index(int uzytkownikID)
        {
            var definiowaneUprawnienia =
                uprawnieniaService.SzukajWgUzytkownika(uzytkownikID);

            var model =
                definiowaneUprawnienia
                    .Select(o => o.Mapuj<UprawnienieUzytkownikaModel>())
                        .ToList();

            return View(model);
        }
    }
}