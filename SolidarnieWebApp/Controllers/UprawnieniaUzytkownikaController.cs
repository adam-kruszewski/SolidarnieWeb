using System.Linq;
using System.Web.Mvc;
using Kruchy.Core.Mapowanie;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Uprawnienia;
using SolidarnieWebApp.Models;
using SolidarnieWebApp.Models.Uprawnienia;

namespace SolidarnieWebApp.Controllers
{
    public class UprawnieniaUzytkownikaController : Controller
    {
        private readonly IUprawnieniaService uprawnieniaService;
        private readonly IUzytkownicyService uzytkownicyService;

        public UprawnieniaUzytkownikaController(
            IUprawnieniaService uprawnieniaService,
            IUzytkownicyService uzytkownicyService)
        {
            this.uprawnieniaService = uprawnieniaService;
            this.uzytkownicyService = uzytkownicyService;
        }

        public ActionResult Index(int uzytkownikID)
        {
            var model = new DefiniowanieUprawnienUzytkownikaModel
            {
                UzytkownikID = uzytkownikID
            };
            model.NazwaUzytkownika = uzytkownicyService.DajWgID(uzytkownikID).Nazwa;

            return View(model);
        }

        public ActionResult Form(int uzytkownikID)
        {
            var definiowaneUprawnienia =
                uprawnieniaService.SzukajWgUzytkownika(uzytkownikID);

            var model = new UprawnieniaUzytkownikaFormModel
            {
                UzytkownikID = uzytkownikID
            };
            model.Uprawnienia =
                definiowaneUprawnienia
                    .Select(o => o.Mapuj<UprawnienieUzytkownikaModel>())
                        .ToList();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Form(UprawnieniaUzytkownikaFormModel form)
        {
            return RedirectToAction("Index", new { uzytkownikID = form.UzytkownikID });
        }
    }
}