using System;
using System.IO;
using System.Web.Mvc;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Authentication;
using SolidarnieWebApp.Models;
using SolidarnieWebApp.Walidacja;

namespace SolidarnieWebApp.Controllers
{
    [WymagaLogowania]
    public class ZamowienieFormController : Controller
    {
        private readonly IDefinicjeZamowieniaService definicjeService;

        public ZamowienieFormController(
            IDefinicjeZamowieniaService definicjeService)
        {
            this.definicjeService = definicjeService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ZamowienieModel());
        }

        [HttpPost]
        public ActionResult Create(ZamowienieModel form)
        {
            var listenerWalidacji = this.DajListeneraWalidacji();
            var wynikWstawienia =
                definicjeService.Wstaw(DajRequestWstawienia(form), listenerWalidacji);
            if (wynikWstawienia.HasValue)
            {
                return RedirectToAction("Index", "Zamowienia");
            }
            return View(form);
        }

        private WstawienieDefinicjiZamowieniaRequest DajRequestWstawienia(
            ZamowienieModel form)
        {
            return new WstawienieDefinicjiZamowieniaRequest
            {
                DataKoncaZamawiania = form.CzasKoncaZamawiania,
                Nazwa = form.Nazwa,
                NazwaPliku = form?.Plik?.FileName,
                ZawartoscPliku = DajZawartoscPliku(form?.Plik?.InputStream)
            };
        }

        private byte[] DajZawartoscPliku(Stream inputStream)
        {
            if (inputStream == null)
                return null;

            using (var ms = new MemoryStream())
            {
                inputStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}