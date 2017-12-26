using System;
using System.Linq;
using System.Web.Mvc;
using Kruchy.Core.Autentykacja;
using Kruchy.Core.Mapowanie;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Authentication;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    [WymagaLogowania]
    public class ZamowienieUzytkownikaController : Controller
    {
        private readonly IUzytkownikProvider uzytkownikProvider;
        private readonly IDefinicjeZamowieniaService definicjeService;
        private readonly IZamawianieService zamawianieService;

        public ZamowienieUzytkownikaController(
            IUzytkownikProvider uzytkownikProvider,
            IDefinicjeZamowieniaService definicjeService,
            IZamawianieService zamawianieService)
        {
            this.uzytkownikProvider = uzytkownikProvider;
            this.definicjeService = definicjeService;
            this.zamawianieService = zamawianieService;
        }

        public ActionResult Index(int definicjaID)
        {
            var definicja = definicjeService.DajWgID(definicjaID);

            var editModel = definicja.Mapuj<ZamowienieEditModel>();
            editModel.DefinicjaID = definicjaID;
            editModel.Uzytkownik = uzytkownikProvider.DajZalogowanego();
            return View(editModel);
        }

        public ActionResult Zamow(ZamowienieEditPostModel form)
        {
            var zamawianePozycje =
                form.Pozycje.Where(o => o.Ilosc > 0).Select(o => DajZamawanaPozycje(o)).ToList();

            if (!zamawianieService.Zamow(
                form.DefinicjaID,
                uzytkownikProvider.DajZalogowanego().ID,
                zamawianePozycje))
                throw new ApplicationException("Coś poszło nie tak");

            return RedirectToAction("Index", new { definicjaID = form.DefinicjaID });
            //return View();
        }

        private ZamawianaPozycja DajZamawanaPozycje(PozycjaZamowieniaModel o)
        {
            return new ZamawianaPozycja
            {
                PozycjaID = o.ID,
                Ilosc = o.Ilosc
            };
        }
    }
}