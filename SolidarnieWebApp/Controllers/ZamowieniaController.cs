using System.Web.Mvc;
using Kruchy.Core.Autentykacja;
using Kruchy.Core.Mapowanie;
using Kruchy.Uzytkownicy.Uprawnienia;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Extensions;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly IDefinicjeZamowieniaService definicjeService;
        private readonly ISumowanieZamowieniaService sumowanieService;
        private readonly IUzytkownikProvider uzytkownikProvider;
        private readonly IUprawnieniaService uprawnieniaService;

        public ZamowieniaController(
            IDefinicjeZamowieniaService definicjeService,
            ISumowanieZamowieniaService sumowanieService,
            IUzytkownikProvider uzytkownikProvider,
            IUprawnieniaService uprawnieniaService)
        {
            this.definicjeService = definicjeService;
            this.sumowanieService = sumowanieService;
            this.uzytkownikProvider = uzytkownikProvider;
            this.uprawnieniaService = uprawnieniaService;
        }

        public ActionResult Index()
        {
            var model = new ListaDefinicjiZamowieniaModel(
                definicjeService.SzukajWszystkich());
            uprawnieniaService.UstawCzyAdministrator(
                uzytkownikProvider,
                o => model.Administrator = o);

            ViewBag.Administrator = model.Administrator;

            return View(model);
        }

        public ActionResult Sumuj(int definicjaID)
        {
            var zsumowaneZamowienie = sumowanieService.Sumuj(definicjaID);
            var model = zsumowaneZamowienie.Mapuj<ZsumowaneZamowienieModel>();
            return View(model);
        }
    }
}