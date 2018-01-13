using System.Web.Mvc;
using Kruchy.Core.Mapowanie;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly IDefinicjeZamowieniaService definicjeService;
        private readonly ISumowanieZamowieniaService sumowanieService;

        public ZamowieniaController(
            IDefinicjeZamowieniaService definicjeService,
            ISumowanieZamowieniaService sumowanieService)
        {
            this.definicjeService = definicjeService;
            this.sumowanieService = sumowanieService;
        }

        public ActionResult Index()
        {
            var model = new ListaDefinicjiZamowieniaModel(
                definicjeService.SzukajWszystkich());
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