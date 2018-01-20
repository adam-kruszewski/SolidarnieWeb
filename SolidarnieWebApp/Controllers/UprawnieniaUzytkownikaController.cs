using System.Linq;
using System.Web.Mvc;
using Kruchy.Core.Mapowanie;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Uprawnienia;
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
            var definiowaneUprawnienia =
                uprawnieniaService.SzukajWgUzytkownika(uzytkownikID);
            model.Uprawnienia =
                definiowaneUprawnienia
                    .Select(o => o.Mapuj<UprawnienieUzytkownikaModel>())
                        .ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Form(DefiniowanieUprawnienUzytkownikaModel form)
        {
            return View("Index", form);
        }
    }
}