using System;
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
        private readonly IUprawnieniaUzytkownikaService uprawnieniaUzytkownikaService;

        public UprawnieniaUzytkownikaController(
            IUprawnieniaService uprawnieniaService,
            IUzytkownicyService uzytkownicyService,
            IUprawnieniaUzytkownikaService uprawnieniaUzytkownikaService)
        {
            this.uprawnieniaService = uprawnieniaService;
            this.uzytkownicyService = uzytkownicyService;
            this.uprawnieniaUzytkownikaService = uprawnieniaUzytkownikaService;
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

            uprawnieniaUzytkownikaService.ZapiszUprawnienia(
                form.UzytkownikID,
                form.Uprawnienia.Select(o => Tuple.Create(o.Nazwa, o.Posiada)).ToList());
            return View("Index", form);
        }
    }
}